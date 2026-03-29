using APBD_CW2.Enums;
using APBD_CW2.Models;

namespace APBD_CW2.Services;

public class EquipmentService
{
    private readonly List<Equipment> _equipmentList = new();

    public void AddEquipment(Equipment equipment)
    {
        if (equipment == null)
            throw new ArgumentNullException(nameof(equipment));

        _equipmentList.Add(equipment);
    }

    public List<Equipment> GetAllEquipment()
    {
        return _equipmentList;
    }

    public List<Equipment> GetAvailableEquipment()
    {
        return _equipmentList
            .Where(e => e.Status == EquipmentStatus.Available)
            .ToList();
    }

    public Equipment? GetEquipmentById(int id)
    {
        return _equipmentList.FirstOrDefault(e => e.Id == id);
    }

    public void MarkAsUnavailable(int equipmentId)
    {
        Equipment? equipment = GetEquipmentById(equipmentId);

        if (equipment == null)
            throw new InvalidOperationException("Equipment not found.");

        equipment.MarkAsUnavailable();
    }
}