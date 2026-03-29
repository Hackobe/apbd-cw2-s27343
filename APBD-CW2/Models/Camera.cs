namespace APBD_CW2.Models;

public class Camera : Equipment
{
    public int Megapixels { get; private set; }
    public bool HasOpticalZoom { get; private set; }

    public Camera(string name, int megapixels, bool hasOpticalZoom) : base(name)
    {
        if (megapixels <= 0)
            throw new ArgumentException("Megapixels must be greater than 0.");

        Megapixels = megapixels;
        HasOpticalZoom = hasOpticalZoom;
    }

    public override string ToString()
    {
        return $"{base.ToString()}, Type: Camera, Megapixels: {Megapixels}, Optical zoom: {HasOpticalZoom}";
    }
}