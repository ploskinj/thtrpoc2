using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace THTR.Common.HttpClients;

public class PersistHttpClient
{
    private readonly HttpClient _http_client;
    private readonly string _base_url;

    public PersistHttpClient(HttpClient http_client, string base_url)
    {
        _base_url = base_url.TrimEnd('/');
        _http_client = http_client;
        _http_client.BaseAddress = new Uri(_base_url);
    }

    public async Task<string> health_check()
    {
        var response = await _http_client.GetAsync("/Persist/HealthCheck");
        response.EnsureSuccessStatusCode();

        var content = await response.Content.ReadAsStringAsync();
        return content;
    }
}