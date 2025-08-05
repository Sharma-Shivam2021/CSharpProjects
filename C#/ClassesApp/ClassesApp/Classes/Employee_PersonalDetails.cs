namespace ClassesApp;

internal partial class Employee
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }

    partial void OnJobAssigned();

    public void AssignJob(string jobTitle)
    {
        this.JobTitle = jobTitle;
        OnJobAssigned();
    }
}
