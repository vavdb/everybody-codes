/*
## CLI

Maak een programma of script dat de gebruiker in staat stelt om via de CLI te zoeken op een deel van een camera _name_, bijvoorbeeld:

```sh
# Of als je .NET Core hebt gebruikt
dotnet Search --name Neude
```

Verwachte output:

```none
501 | UTR-CM-501 Neude rijbaan voor Postkantoor | 52.093421 | 5.118278
503 | UTR-CM-503 Neude plein | 52.093448 | 5.118536
504 | UTR-CM-504 Neude / Schoutenstraat | 52.092995 | 5.119088
505 | UTR-CM-505 Neude / Drakenburgstraat / Vinkenurgstraat | 52.092843 | 5.118351
506 | UTR-CM-506 Vinkenburgstraat / Neude | 52.092378 | 5.117902
507 | UTR-CM-507 Vinkenburgstraat richting Neude | 52.092234 | 5.117766
```
*/
using CsvHelper;
using System.Globalization;

const string dataFile = @"..\..\data\cameras-defb.csv";


// Do some validation
const string readmeText = "Use [Search --name {your name}] to search for a camera.";
// Normally we'd use a commandline parser library like System.CommandLine, but here we'll do it manually 
if (args.Length < 2)
{
    Console.WriteLine("Specify a name to search for it." + Environment.NewLine + readmeText);
    return;
}

if (!args.First().StartsWith("--name"))
{
    Console.WriteLine("Invalid argument received." + Environment.NewLine + readmeText);
    return;
}

var name = args[1];


var csvConfig = new CsvHelper.Configuration.CsvConfiguration(CultureInfo.InvariantCulture)
{
    Delimiter = ";",
    MissingFieldFound = null
};
using var reader = new StreamReader(dataFile);
using var csv = new CsvReader(reader, csvConfig);
foreach (var resultRow in csv.GetRecords<CameraRecord>().Where(r => r.Camera.Contains(name, StringComparison.OrdinalIgnoreCase)))
{
    Console.WriteLine($"{resultRow.Camera.Substring(7, 3)} | {resultRow.Camera} | {resultRow.Latitude.GetValueOrDefault().ToString(CultureInfo.InvariantCulture)} | {resultRow.Longitude.GetValueOrDefault().ToString(CultureInfo.InvariantCulture)}");
}

record CameraRecord(string Camera, double? Latitude, double? Longitude);