namespace CollectionsApp;

internal class DictionaryExample
{

    public DictionaryExample()
    {
        Dictionary<int, Employee> employees = new Dictionary<int, Employee>();
        employees.Add(1, new Employee("John Doe", 35, 100000));
        employees.Add(2, new Employee("John Wick", 30, 200000));
        employees.Add(3, new Employee("John McArthy", 36, 3660000));
        employees.Add(4, new Employee("John Cena", 38, 1056600));

        DisplayDictionary(employees);
    }

    private void DisplayDictionary(Dictionary<int, Employee> employees)
    {
        // Iterating over a dictionary
        foreach (KeyValuePair<int, Employee> employee in employees)
        {
            Console.WriteLine($"ID: {employee.Key}, Name: {employee.Value.Name}, Age: {employee.Value.Age}, Salary: {employee.Value.Salary}");
        }
        Console.WriteLine();
    }
}

class Employee
{
    public string Name { get; set; }
    public int Age { get; set; }
    public int Salary { get; set; }

    public Employee(string name, int age, int salary)
    {
        Name = name;
        Age = age;
        Salary = salary;
    }
}


public class Exercise
{

    public Dictionary<string, List<int>> dict = new Dictionary<string, List<int>>
    {
        {"1",new List<int>{ 2,3} },
        //["2"]=new List<int>{5,6 }, 
    };
    public void PrintDictionaryValues()
    {

        foreach (var item in dict)
        {
            Console.WriteLine($"{item.Key} {item.Value[0]} {item.Value[1]} ");
        }
    }
}

public class Student
{
    public int Id { get; set; }
    public string Name { get; set; }

    public int Grade { get; set; }
}