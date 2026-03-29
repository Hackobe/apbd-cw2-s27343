namespace APBD_CW2.Models;

public class Projector : Equipment
{
    public int BrightnessLumens { get; private set; }
    public string Resolution { get; private set; }

    public Projector(string name, int brightnessLumens, string resolution) : base(name)
    {
        if (brightnessLumens <= 0)
            throw new ArgumentException("Brightness must be greater than 0.");
        if (string.IsNullOrWhiteSpace(resolution))
            throw new ArgumentException("Resolution cannot be empty.");

        BrightnessLumens = brightnessLumens;
        Resolution = resolution;
    }

    public override string ToString()
    {
        return $"{base.ToString()}, Type: Projector, Brightness: {BrightnessLumens} lm, Resolution: {Resolution}";
    }
}