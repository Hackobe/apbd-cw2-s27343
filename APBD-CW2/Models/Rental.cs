namespace APBD_CW2.Models;

public class Rental
{
    private static int _nextId = 1;

    public int Id { get; }
    public User User { get; }
    public Equipment Equipment { get; }
    public DateTime RentDate { get; }
    public DateTime DueDate { get; }
    public DateTime? ReturnDate { get; private set; }
    public decimal PenaltyAmount { get; private set; }

    public bool IsActive => ReturnDate == null;
    public bool IsOverdue => IsActive && DateTime.Now > DueDate;

    public Rental(User user, Equipment equipment, DateTime rentDate, int rentalDays)
    {
        if (user == null)
            throw new ArgumentNullException(nameof(user));
        if (equipment == null)
            throw new ArgumentNullException(nameof(equipment));
        if (rentalDays <= 0)
            throw new ArgumentException("Rental days must be greater than 0.");

        Id = _nextId++;
        User = user;
        Equipment = equipment;
        RentDate = rentDate;
        DueDate = rentDate.AddDays(rentalDays);
        PenaltyAmount = 0;
    }

    public void ReturnEquipment(DateTime returnDate, decimal penaltyAmount)
    {
        if (ReturnDate != null)
            throw new InvalidOperationException("Equipment has already been returned.");

        if (returnDate < RentDate)
            throw new ArgumentException("Return date cannot be earlier than rent date.");

        ReturnDate = returnDate;
        PenaltyAmount = penaltyAmount;
    }

    public override string ToString()
    {
        return $"Rental ID: {Id}, User: {User.FirstName} {User.LastName}, Equipment: {Equipment.Name}, Rent date: {RentDate:yyyy-MM-dd}, Due date: {DueDate:yyyy-MM-dd}, Return date: {(ReturnDate.HasValue ? ReturnDate.Value.ToString("yyyy-MM-dd") : "Not returned")}, Penalty: {PenaltyAmount} PLN";
    }
}