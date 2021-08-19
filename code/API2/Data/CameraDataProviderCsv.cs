using System.Globalization;
using CsvHelper;

class CameraDataProviderCsv : ICameraDataProvider
{
    private readonly ILogger<CameraDataProviderCsv> _logger;

    public CameraDataProviderCsv(ILogger<CameraDataProviderCsv> logger)
    {
        _logger = logger;
    }    

    public IEnumerable<CameraRecord> GetCameras()
    {
        const string dataFile = @"..\..\data\cameras-defb.csv";
        var csvConfig = new CsvHelper.Configuration.CsvConfiguration(CultureInfo.InvariantCulture)
        {
            Delimiter = ";",
            MissingFieldFound = null
        };
        using var reader = new StreamReader(dataFile);
        using var csv = new CsvReader(reader, csvConfig);
        return csv.GetRecords<CameraRecord>().Where(c => c.Latitude.HasValue && c.Longitude.HasValue).ToList();
    }
}