/*
## API
Serveer de data uit de csv vanuit een web-API, zodat een webapplicatie die data ergens kan ophalen.
*/

// Normally we'd parse and cleanup the file first. So we can reuse it in the CLI and the API project.
// In this case we just do what was requested and serve the file from a web api :)
const string dataFile = @"..\..\data\cameras-defb.csv";
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();
app.MapGet("/", async () =>  await System.IO.File.ReadAllTextAsync(dataFile));
app.Run();
