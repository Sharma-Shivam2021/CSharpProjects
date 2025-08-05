namespace InheritanceApp;

public class Person
{
    public string Name { get; private set; }

    public int Age { get; private set; }

    public Person(string name, int age)
    {
        Name = name;
        Age = age;
        Console.WriteLine("Person constructor called");
    }
   
    public void DisplayPersonInfo()
    {
        Console.WriteLine($"Name: {Name}, Age: {Age}");
    }

    /// <summary>
    /// Makes our object older!
    /// </summary>
    /// <param name="years">The parameter that indicates 
    /// the amount of years the object should age.</param>
    /// <returns> Returns the new age.</returns>
    public int BecomeOlder(int years)
    {
        Age += years;
        return Age ;
    }
}


public class Employee : Person
{

    public string JobTitle { get;private set; }
    public int EmployeeID { get;private set; }
    public Employee(string name, int age, string jobTitle, int employeeID) 
        : base(name, age) // calling the base constructor
    {
        JobTitle = jobTitle;
        EmployeeID = employeeID;
        Console.WriteLine("Employee Constructor Called");
    }

    public void DisplayEmployeeInfo()
    {
        DisplayPersonInfo();
        Console.WriteLine($"JobTitle: {JobTitle}");
    }
}

public class Manager : Employee
{
    public int TeamSize { get;private set; }
    public Manager(string name,
                   int age,
                   string jobTitle,
                   int employeeID,
                   int teamSize) : base(name, age, jobTitle, employeeID)
    {
        TeamSize = teamSize;
    }

    public void DisplayManagerInfo()
    {
        DisplayEmployeeInfo();
        Console.WriteLine($"TeamSize: {TeamSize}");
    }
}