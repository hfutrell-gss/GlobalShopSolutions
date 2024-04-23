namespace GlobalShopSolutions.Sdk;

public abstract class PageControl : UserControl
{
    public abstract string PageName { get; }
    public abstract string Description { get; }
    
    public virtual Action? OnSave { get; } = null;
    

    private readonly List<NavigationControl> _navigationControls = new();
    public IReadOnlyCollection<NavigationControl> Navigations => _navigationControls;
    
    private readonly List<IFunction> _functions = new();
    public IReadOnlyCollection<IFunction> Functions => _functions;
    
    
    protected void RegisterNavigations(params NavigationControl[] navigationControls)
    {
        _navigationControls.AddRange(navigationControls);
    }
    
    protected void RegisterFunctions(params IFunction[] functions)
    {
        _functions.AddRange(functions);
    }
}