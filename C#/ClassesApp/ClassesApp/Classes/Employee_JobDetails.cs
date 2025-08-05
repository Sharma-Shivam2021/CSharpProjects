namespace ClassesApp;

internal partial class Employee
{
    public string? JobTitle { get; set; }
    public double? Salary { get; set; }

    partial void OnJobAssigned()
    {
        Console.WriteLine("A new Job has been assigned.");
    }
}
