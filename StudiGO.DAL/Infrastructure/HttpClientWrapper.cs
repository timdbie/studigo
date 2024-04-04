using System.Net.Http;
using System.Threading.Tasks;

namespace StudiGO.DAL.Infrastructure;

public class HttpClientWrapper
{
    private readonly HttpClient _httpClient;

    public HttpClientWrapper()
    {
        _httpClient = new HttpClient();
    }

    public async Task<HttpResponseMessage> GetAsync(string requestUrl)
    {
        try
        {
            return await _httpClient.GetAsync(requestUrl);
        }
        catch (HttpRequestException ex)
        {
            throw ex;
        }
    }
}