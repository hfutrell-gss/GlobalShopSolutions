namespace GlobalShopSolutions.Server.Spec.Fixtures;

public sealed class ServerAdapter
{
    private readonly HttpClient _httpClient;

    public ServerAdapter(HttpClient client)
    {
        _httpClient = client;
    }
    
    public async Task<string> Get(string endpoint)
    {
        var baseAddress = _httpClient.BaseAddress;
        
        var request = new HttpRequestMessage 
        {
            RequestUri = baseAddress,
            Method = HttpMethod.Get,
        };

        var response = await _httpClient.SendAsync(request);
        

        var content = await response.Content.ReadAsStringAsync();
        
        return content;
    }
}