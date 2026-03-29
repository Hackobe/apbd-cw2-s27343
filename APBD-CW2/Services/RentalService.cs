using APBD_CW2.Enums;
using APBD_CW2.Models;

namespace APBD_CW2.Services;

public class RentalService
{
    private readonly List<Rental> _rentals = new();
    private const decimal PenaltyPerDay = 15m;

    public void RentEquipment(User user, Equipment equipment, int rentalDays)
    {
        if (user == null)
            throw new ArgumentNullException(nameof(user));

        if (equipment == null)
            throw new ArgumentNullException(nameof(equipment));

        if (rentalDays <= 0)
            throw new ArgumentException("Rental days must be greater than 0.");

        if (equipment.Status == EquipmentStatus.Unavailable)
            throw new InvalidOperationException("Equipment is unavailable and cannot be rented.");

        if (equipment.Status == EquipmentStatus.Rented)
            throw new InvalidOperationException("Equipment is already rented.");

        int activeRentalsCount = GetActiveRentalsByUser(user.Id).Count;

        if (activeRentalsCount >= user.GetRentalLimit())
            throw new InvalidOperationException("User has reached the rental limit.");

        Rental rental = new Rental(user, equipment, DateTime.Now, rentalDays);
        _rentals.Add(rental);

        equipment.MarkAsRented();
    }

    public decimal ReturnEquipment(int rentalId, DateTime returnDate)
    {
        Rental? rental = _rentals.FirstOrDefault(r => r.Id == rentalId);

        if (rental == null)
            throw new InvalidOperationException("Rental not found.");

        if (!rental.IsActive)
            throw new InvalidOperationException("This rental is already closed.");

        decimal penalty = CalculatePenalty(rental, returnDate);

        rental.ReturnEquipment(returnDate, penalty);
        rental.Equipment.MarkAsAvailable();

        return penalty;
    }

    public List<Rental> GetAllRentals()
    {
        return _rentals;
    }

    public List<Rental> GetActiveRentalsByUser(int userId)
    {
        return _rentals
            .Where(r => r.User.Id == userId && r.IsActive)
            .ToList();
    }

    public List<Rental> GetOverdueRentals()
    {
        return _rentals
            .Where(r => r.IsOverdue)
            .ToList();
    }

    private decimal CalculatePenalty(Rental rental, DateTime returnDate)
    {
        if (returnDate <= rental.DueDate)
            return 0;

        int lateDays = (returnDate.Date - rental.DueDate.Date).Days;
        return lateDays * PenaltyPerDay;
    }
}