using Models;

public interface ICameraDataProvider{
    Task<IEnumerable<CameraRecord>> GetCameras();
}
