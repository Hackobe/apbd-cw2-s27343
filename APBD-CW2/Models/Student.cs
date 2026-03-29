using APBD_CW2.Enums;

namespace APBD_CW2.Models;

public class Student : User
{
    public string StudentNumber { get; private set; }
    public string FieldOfStudy { get; private set; }

    public Student(string firstName, string lastName, string studentNumber, string fieldOfStudy)
        : base(firstName, lastName, UserType.Student)
    {
        if (string.IsNullOrWhiteSpace(studentNumber))
            throw new ArgumentException("Student number cannot be empty.");
        if (string.IsNullOrWhiteSpace(fieldOfStudy))
            throw new ArgumentException("Field of study cannot be empty.");

        StudentNumber = studentNumber;
        FieldOfStudy = fieldOfStudy;
    }

    public override int GetRentalLimit() => 2;
}