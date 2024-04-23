using GlobalShopSolutions.Sdk;

namespace GlobalShopSolutions.AccountsReceivable.Presenter.Desktop;

public partial class UserControl1 : PageControl
{
    public override string PageName => "Accounts Receivable";
    public override string Description => "Allows doing things with stuff";

    
    public UserControl1()
    {
        RegisterNavigations(
            new NavigationControl1(),
            new NavigationControl2()
        );
        
        RegisterFunctions();

        InitializeComponent();
    }
}
