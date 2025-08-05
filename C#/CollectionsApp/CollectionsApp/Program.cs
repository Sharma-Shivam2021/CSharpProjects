
using CollectionsApp;


internal class Program
{
    private static void Main(string[] args)
    {
        Dictionary<string, Student> student = new Dictionary<string, Student>();
        student.Add("John",new Student { Name="John",Id=1,Grade=85});    
        student.Add("Alice",new Student { Name="Alice",Id=2,Grade=90});    
        student.Add("Bob",new Student { Name="Bob",Id=1,Grade=78});

        foreach (var item in student)
        {
            Console.WriteLine($"Name: {item.Value.Name}, Id: {item.Value.Id}, Grade: {item.Value.Grade}");
        }

    }
        
    
}