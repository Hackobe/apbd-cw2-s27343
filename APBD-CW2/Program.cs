using APBD_CW2.Models;
using APBD_CW2.Services;

namespace APBD_CW2;

class Program
{
    static void Main(string[] args)
    {
        EquipmentService equipmentService = new();
        UserService userService = new();
        RentalService rentalService = new();
        ReportService reportService = new();

        Laptop laptop1 = new("Dell Latitude", "Intel i7", 16);
        Laptop laptop2 = new("Lenovo ThinkPad", "Intel i5", 8);
        Projector projector1 = new("Epson X1", 3200, "1920x1080");
        Camera camera1 = new("Canon EOS", 24, true);

        equipmentService.AddEquipment(laptop1);
        equipmentService.AddEquipment(laptop2);
        equipmentService.AddEquipment(projector1);
        equipmentService.AddEquipment(camera1);

        Student student1 = new("Jan", "Kowalski", "s12345", "Computer Science");
        Student student2 = new("Anna", "Nowak", "s54321", "Management");
        Employee employee1 = new("Piotr", "Wiśniewski", "e100", "IT Department");

        userService.AddUser(student1);
        userService.AddUser(student2);
        userService.AddUser(employee1);

        Console.WriteLine("=== ALL EQUIPMENT ===");
        foreach (Equipment equipment in equipmentService.GetAllEquipment())
        {
            Console.WriteLine(equipment);
        }

        Console.WriteLine();
        Console.WriteLine("=== AVAILABLE EQUIPMENT ===");
        foreach (Equipment equipment in equipmentService.GetAvailableEquipment())
        {
            Console.WriteLine(equipment);
        }

        Console.WriteLine();
        Console.WriteLine("=== CORRECT RENTAL ===");
        rentalService.RentEquipment(student1, laptop1, 7);
        Console.WriteLine($"{student1.FirstName} rented {laptop1.Name}");

        Console.WriteLine();
        Console.WriteLine("=== INVALID OPERATION ===");
        try
        {
            rentalService.RentEquipment(student2, laptop1, 3);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }

        Console.WriteLine();
        Console.WriteLine("=== USER LIMIT TEST ===");
        rentalService.RentEquipment(student1, laptop2, 5);
        try
        {
            rentalService.RentEquipment(student1, projector1, 2);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }

        Console.WriteLine();
        Console.WriteLine("=== ACTIVE RENTALS OF STUDENT 1 ===");
        foreach (Rental rental in rentalService.GetActiveRentalsByUser(student1.Id))
        {
            Console.WriteLine(rental);
        }

        Console.WriteLine();
        Console.WriteLine("=== RETURN ON TIME ===");
        Rental firstRental = rentalService.GetAllRentals().First();
        decimal penalty1 = rentalService.ReturnEquipment(firstRental.Id, firstRental.DueDate);
        Console.WriteLine($"Returned with penalty: {penalty1} PLN");

        Console.WriteLine();
        Console.WriteLine("=== LATE RETURN ===");
        rentalService.RentEquipment(employee1, projector1, 2);
        Rental lastRental = rentalService.GetAllRentals().Last();
        decimal penalty2 = rentalService.ReturnEquipment(lastRental.Id, lastRental.DueDate.AddDays(3));
        Console.WriteLine($"Returned with penalty: {penalty2} PLN");

        Console.WriteLine();
        Console.WriteLine("=== MARK EQUIPMENT AS UNAVAILABLE ===");
        equipmentService.MarkAsUnavailable(camera1.Id);
        Console.WriteLine($"{camera1.Name} marked as unavailable");

        Console.WriteLine();
        Console.WriteLine("=== OVERDUE RENTALS ===");
        foreach (Rental rental in rentalService.GetOverdueRentals())
        {
            Console.WriteLine(rental);
        }

        Console.WriteLine();
        reportService.PrintSummary(
            equipmentService.GetAllEquipment(),
            userService.GetAllUsers(),
            rentalService.GetAllRentals());
    }
}