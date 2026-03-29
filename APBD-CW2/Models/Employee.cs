using APBD_CW2.Enums;

namespace APBD_CW2.Models;

public class Employee : User
{
    public string EmployeeNumber { get; private set; }
    public string Department { get; private set; }

    public Employee(string firstName, string lastName, string employeeNumber, string department)
        : base(firstName, lastName, UserType.Employee)
    {
        if (string.IsNullOrWhiteSpace(employeeNumber))
            throw new ArgumentException("Employee number cannot be empty.");
        if (string.IsNullOrWhiteSpace(department))
            throw new ArgumentException("Department cannot be empty.");

        EmployeeNumber = employeeNumber;
        Department = department;
    }

    public override int GetRentalLimit() => 5;
}