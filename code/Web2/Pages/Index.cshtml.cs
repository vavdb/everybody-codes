using System.Globalization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;
using Models;

namespace web.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;
    private readonly ICameraDataProvider _cameraDataProvider;
    public IEnumerable<CameraRecord>? CameraData;

    public IndexModel(ILogger<IndexModel> logger, ICameraDataProvider cameraDataProvider)
    {
        _logger = logger;
        _cameraDataProvider = cameraDataProvider;
    }

    public async Task OnGet()
    {
        CameraData = await _cameraDataProvider.GetCameras();
    }

}