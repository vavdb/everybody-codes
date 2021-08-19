using System.Globalization;
using System.Text.Json;
using CsvHelper;
using Models;

class CameraDataProviderApi : ICameraDataProvider
{
    private readonly ILogger<CameraDataProviderApi> _logger;
    private readonly IHttpClientFactory _clientFactory;

    public CameraDataProviderApi(ILogger<CameraDataProviderApi> logger, IHttpClientFactory clientFactory)
    {
        _logger = logger;
        _clientFactory = clientFactory;
    }

    public async Task<IEnumerable<CameraRecord>> GetCameras()
    {
        var client = _clientFactory.CreateClient();
        var response = await client.GetStreamAsync("https://localhost:5002/Cameras");
        if (response == null)
        {
            throw new Exception("Got no response while fetching Cameras from API");
        }
        var options = new JsonSerializerOptions()
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        };
        return await JsonSerializer.DeserializeAsync<IEnumerable<CameraRecord>>(response, options);
    }
}