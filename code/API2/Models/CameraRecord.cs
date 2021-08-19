public class CameraRecord
{
    public int? CameraNumber
    {
        get
        {

            return (Camera == null || Camera.Length < 9) ? null : int.Parse(Camera.Substring(7, 3));
        }
    }
    public string? Camera { get; set; }
    public double? Latitude { get; set; }
    public double? Longitude { get; set; }
}
