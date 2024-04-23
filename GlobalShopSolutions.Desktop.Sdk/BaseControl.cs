namespace GlobalShopSolutions.Desktop.Sdk;

public abstract class BaseControl : UserControl
{
    public abstract List<NavigationControl> NavigationControls { get; }
    public abstract override string Text { get; }
}

