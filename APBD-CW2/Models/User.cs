using APBD_CW2.Enums;

namespace APBD_CW2.Models;

public abstract class User
{
    private static int _nextId = 1;

    public int Id { get; }
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public UserType UserType { get; }

    protected User(string firstName, string lastName, UserType userType)
    {
        if (string.IsNullOrWhiteSpace(firstName))
            throw new ArgumentException("First name cannot be empty.");
        if (string.IsNullOrWhiteSpace(lastName))
            throw new ArgumentException("Last name cannot be empty.");

        Id = _nextId++;
        FirstName = firstName;
        LastName = lastName;
        UserType = userType;
    }

    public abstract int GetRentalLimit();

    public override string ToString()
    {
        return $"ID: {Id}, {FirstName} {LastName}, Type: {UserType}, Limit: {GetRentalLimit()}";
    }
}