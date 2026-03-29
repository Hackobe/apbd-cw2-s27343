using APBD_CW2.Enums;
using APBD_CW2.Models;

namespace APBD_CW2.Services;

public class ReportService
{
    public void PrintSummary(
        List<Equipment> equipment,
        List<User> users,
        List<Rental> rentals)
    {
        int totalEquipment = equipment.Count;
        int availableEquipment = equipment.Count(e => e.Status == EquipmentStatus.Available);
        int rentedEquipment = equipment.Count(e => e.Status == EquipmentStatus.Rented);
        int unavailableEquipment = equipment.Count(e => e.Status == EquipmentStatus.Unavailable);
        int activeRentals = rentals.Count(r => r.IsActive);
        int overdueRentals = rentals.Count(r => r.IsOverdue);

        Console.WriteLine("===== RENTAL SYSTEM REPORT =====");
        Console.WriteLine($"Users: {users.Count}");
        Console.WriteLine($"Total equipment: {totalEquipment}");
        Console.WriteLine($"Available equipment: {availableEquipment}");
        Console.WriteLine($"Rented equipment: {rentedEquipment}");
        Console.WriteLine($"Unavailable equipment: {unavailableEquipment}");
        Console.WriteLine($"All rentals: {rentals.Count}");
        Console.WriteLine($"Active rentals: {activeRentals}");
        Console.WriteLine($"Overdue rentals: {overdueRentals}");
        Console.WriteLine("================================");
    }
}