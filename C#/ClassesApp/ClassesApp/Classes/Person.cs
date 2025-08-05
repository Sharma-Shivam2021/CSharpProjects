namespace ClassesApp.Classes;

public class Person
{
    public string Name { get; }

    public Person(string name)
    {
        Name = name;
    }

    public void Greet()
    {
        Console.WriteLine($"Hello, {Name}!");
    }
}
