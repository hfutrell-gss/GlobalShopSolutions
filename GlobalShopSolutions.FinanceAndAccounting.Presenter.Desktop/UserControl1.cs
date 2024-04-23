using GlobalShopSolutions.Desktop.Sdk;

namespace GlobalShopSolutions.FinanceAndAccounting.Presenter.Desktop;

public partial class UserControl1 : BaseControl
{
    public override string Text { get; set; } = "Hi";
    
    public override List<NavigationControl> NavigationControls { get; }
    
    public UserControl1()
    {
        InitializeComponent();
    }
}