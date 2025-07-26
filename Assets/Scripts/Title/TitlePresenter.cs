using TMPro;
using UnityEngine;
using VContainer;

public class TitlePresenter : MonoBehaviour
{
    [SerializeField] private MainCreditData mainCreditData;
    [SerializeField] private TextMeshProUGUI creditText;
    [SerializeField] private TextMeshProUGUI licenseText;
    
    private CreditService _creditService;
    private LicenseService _licenseService;
    
    private MainCreditView _mainCreditView;
    
    [Inject]
    public void Construct(CreditService creditService, LicenseService licenseService)
    {
        _creditService = creditService;
        _licenseService = licenseService;
    }
    
    private void Awake()
    {
        _mainCreditView = FindAnyObjectByType<MainCreditView>();
    }
    
    public void Start()
    {
        Debug.Log("TitlePresenter started. Initializing title screen...");
        
        creditText.text = _creditService.GetCreditText();
        licenseText.text = _licenseService.GetLicenseText();
        
        _mainCreditView.Initialize(mainCreditData);
    }
}
