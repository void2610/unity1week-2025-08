using SyskenTLib.LicenseMaster;
using UnityEngine;
using VContainer;
using VContainer.Unity;

public class TitleLifetimeScope : LifetimeScope
{
    [SerializeField] private LicenseManager licenseManager;
    [SerializeField] private TextAsset creditTextAsset;
    protected override void Configure(IContainerBuilder builder)
    {
        builder.Register<CreditService>(Lifetime.Singleton).WithParameter(creditTextAsset);
        builder.Register<LicenseService>(Lifetime.Singleton).WithParameter(licenseManager);
        
        builder.RegisterComponentInHierarchy<TitlePresenter>();
    }
}
