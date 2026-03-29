using APBD_CW2.Enums;

namespace APBD_CW2.Models;

public abstract class Equipment
{
    private static int nextID = 1;
    
    public int Id { get; }
    public string Name { get; private set; }
    public EquipmentStatus Status { get; private set; }

    protected Equipment(string Name)
    {
        if (string.IsNullOrWhiteSpace(Name))
            throw new ArgumentException("Equipment name cannot be empty.", nameof(Name));
        
        Id = nextID++;
        this.Name = Name;
        Status = EquipmentStatus.Available;
    }
    
    public void MarkAsAvailable()
    {
        Status = EquipmentStatus.Available;
    }

    public void MarkAsRented()
    {
        Status = EquipmentStatus.Rented;
    }
    
    public void MarkAsUnavailable()
    {
        Status = EquipmentStatus.Unavailable;
    }

    public override string ToString()
    {
        return $"ID: {Id}, Name: {Name}, Status: {Status}";
    }
}