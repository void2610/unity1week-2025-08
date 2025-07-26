using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using VContainer;

public class TitlePresenter : MonoBehaviour
{
    [SerializeField] private MainCreditData mainCreditData;
    [SerializeField] private TextMeshProUGUI creditText;
    [SerializeField] private TextMeshProUGUI licenseText;
    [SerializeField] private Button startButton;
    [SerializeField] private Button creditButton;
    [SerializeField] private Button licenseButton;
    [SerializeField] private Button closeCreditButton;
    [SerializeField] private Button closeLicenseButton;
    
    private CreditService _creditService;
    private LicenseService _licenseService;
    
    private MainCreditView _mainCreditView;
    private List<CanvasGroup> _canvasGroups = new ();
    
    [Inject]
    public void Construct(CreditService creditService, LicenseService licenseService)
    {
        _creditService = creditService;
        _licenseService = licenseService;
    }
    
    private void ToggleCanvasGroup(string canvasGroupName, bool isActive)
    {
        var canvasGroup = _canvasGroups.Find(cg => cg.name == canvasGroupName);
        if (!canvasGroup) return;
        
        canvasGroup.alpha = isActive ? 1f : 0f;
        canvasGroup.interactable = isActive;
        canvasGroup.blocksRaycasts = isActive;
    }
    
    private void StartGame()
    {
        SceneManager.LoadScene("MainScene");
    }
    
    private void UpdateContentSize(TextMeshProUGUI text)
    {
        var preferredHeight = text.GetPreferredValues().y;
        var content = text.GetComponent<RectTransform>();
        var parentRect = content.parent.GetComponent<RectTransform>();
        content.sizeDelta = new Vector2(content.sizeDelta.x, preferredHeight);
        parentRect.sizeDelta = new Vector2(parentRect.sizeDelta.x, preferredHeight);
    }
    
    private void Awake()
    {
        _mainCreditView = FindAnyObjectByType<MainCreditView>();
        
        _canvasGroups = new List<CanvasGroup>(FindObjectsByType<CanvasGroup>(FindObjectsSortMode.None));
        
        startButton.onClick.AddListener(StartGame);
        creditButton.onClick.AddListener(() => ToggleCanvasGroup("Credit", true));
        licenseButton.onClick.AddListener(() => ToggleCanvasGroup("License", true));
        closeCreditButton.onClick.AddListener(() => ToggleCanvasGroup("Credit", false));
        closeLicenseButton.onClick.AddListener(() => ToggleCanvasGroup("License", false));
    }
    
    public void Start()
    {
        Debug.Log("TitlePresenter started. Initializing title screen...");
        
        creditText.text = _creditService.GetCreditText();
        licenseText.text = _licenseService.GetLicenseText();
        UpdateContentSize(licenseText);
        
        _mainCreditView.Initialize(mainCreditData);
    }
}
