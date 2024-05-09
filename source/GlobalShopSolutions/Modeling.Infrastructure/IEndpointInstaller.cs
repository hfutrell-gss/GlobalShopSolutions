namespace Modeling.Infrastructure;

public interface IEndpointInstaller
{
    public void InstallEndpoints(
        EndpointAggregator endpointAggregator
    );   
}