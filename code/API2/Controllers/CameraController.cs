using Microsoft.AspNetCore.Mvc;

namespace API2.Controllers;

[ApiController]
[Route("[controller]")]
public class CamerasController : ControllerBase
{
    private readonly ILogger<CamerasController> _logger;
    private readonly ICameraDataProvider _cameraDataProvider;

    public CamerasController(ILogger<CamerasController> logger, ICameraDataProvider cameraDataProvider)
    {
        _logger = logger;
        _cameraDataProvider = cameraDataProvider;
    }

    [HttpGet]
    public IEnumerable<CameraRecord> Get()
    {
        return _cameraDataProvider.GetCameras();
    }
}
