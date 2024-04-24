namespace GlobalShopSolutions.Client.Sdk;

public interface IFunction
{
    public string Category { get; }
    public string Name { get; }
    public Action Function {get;}
}