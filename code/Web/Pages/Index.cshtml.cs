using System.Globalization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using CsvHelper;

namespace web.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;
    public IEnumerable<CameraRecord>? CameraData;

    public IndexModel(ILogger<IndexModel> logger)
    {
        _logger = logger;
    }

    public async Task OnGet()
    {
        //Normally the web-api would have sanitized this data and would return a json. 
        //In regular cases we'd register a typed http client when we configure services, here we just manually use a httpclient to fetch the result.
        HttpClient client = new HttpClient();
        var response = await client.GetAsync("https://localhost:5002/");
        using var pageContentStream = await response.Content.ReadAsStreamAsync();
        using TextReader reader = new StreamReader(pageContentStream);

        var csvConfig = new CsvHelper.Configuration.CsvConfiguration(CultureInfo.InvariantCulture)
        {
            Delimiter = ";",
            MissingFieldFound = null
        };
        using var csv = new CsvReader(reader, csvConfig);
        CameraData = csv.GetRecords<CameraRecord>().ToList(); //ToList this so we have the data 
        
        // Remove cameras without a valid latlon
        CameraData = CameraData.Where(c => c.Latitude.HasValue && c.Longitude.HasValue);
    }

    public record CameraRecord(string Camera, double? Latitude, double? Longitude)
    {
        public int CameraNumber
        {
            get
            {

                return int.Parse(Camera.Substring(7, 3));
            }
        }
    }
}