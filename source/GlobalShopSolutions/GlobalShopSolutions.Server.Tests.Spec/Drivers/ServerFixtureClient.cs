namespace GlobalShopSolutions.Server.Tests.Spec.Drivers;

public sealed class ServerFixtureClient(HttpClient client)
{
    public async Task<string> Get(string endpoint)
    {
        var request = new HttpRequestMessage();
        request.Method = HttpMethod.Get;
        request.RequestUri = new Uri(endpoint);

        var response = await client.SendAsync(request);

        return await response.Content.ReadAsStringAsync();
    }
    
    public async Task<object> MakeRequest(string endpoint)
    {
        var request = new HttpRequestMessage();
        request.Method = HttpMethod.Post;
        
        var response = await client.SendAsync(request);

        return await response.Content.ReadAsStringAsync();
    }
}