namespace APBD_CW2.Models;

public class Laptop : Equipment
{
    public string Procesor { get; private set; }
    public int RamGB {get; private set;}

    public Laptop(string name, string procesor, int ramGB) : base(name)
    {
        if (string.IsNullOrWhiteSpace(procesor))
            throw new ArgumentException("Procesor cannot be empty");
        if (ramGB <= 0)
            throw new ArgumentException("RAM must be greater than zero");
        
        Procesor = procesor;
        RamGB = ramGB;
    }

    public override string ToString()
    {
        return $"{base.ToString()}, Type: Laptop, Procesor: {Procesor}, RAM: {RamGB} GB";
    }
}