using System.Net;
using System.Text;
using Newtonsoft.Json;

namespace GlobalShopSolutions.Server.Tests.Spec.Fixtures;

public sealed class ServerAdapter
{
    private readonly HttpClient _httpClient;

    public ServerAdapter(
        HttpClient client
    )
    {
        _httpClient = client;
    }
    
    public async Task<string> GetAsync(string endpoint)
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
    
    public async Task<TResponse> PostAsync<TRequest, TResponse>(
        string endpoint,
        TRequest request
    )
    {
        var baseAddress = _httpClient.BaseAddress;
        var uri = new Uri(baseAddress, endpoint);

        var content = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json");
        
        var message = new HttpRequestMessage
        {
            RequestUri = uri,
            Method = HttpMethod.Post,
            Content = content
        };

        return await SendAsync<TResponse>(message);
    }
    
    public async Task<TResponse> GetAsync<TRequest, TResponse>(
        string endpoint,
        TRequest request
    )
    {
        return await PostAsync<TRequest, TResponse>(endpoint, request);
    }
    
    private async Task<TResponse> SendAsync<TResponse>(HttpRequestMessage request)
    {
        var response = await _httpClient.SendAsync(request);
                
        if (
            response.StatusCode != HttpStatusCode.OK
            && response.StatusCode != HttpStatusCode.Created
            ) 
            throw new ApplicationException($"The request failed: {response.StatusCode}. {response.ReasonPhrase}");
        
        var responseContent = await response.Content.ReadAsStringAsync();
                
        var content = JsonConvert.DeserializeObject<TResponse>(responseContent);
        
        if (content is null) throw new ApplicationException("The response was empty");
        
        return content;
    }
}