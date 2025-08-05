namespace InterfacesApp;

public interface IAnimal
{
    void MakeSound();
    void Eat(string food);
}

class Dog : IAnimal
{
    public void Eat(string food)
    {
        Console.WriteLine($"Dog ate {food}");
    }

    public void MakeSound()
    {
        Console.WriteLine("Dog barks");
    }
}

class Cat : IAnimal
{
    public void Eat(string food)
    {
        Console.WriteLine($"Cat ate {food}");

    }

    public void MakeSound()
    {
        Console.WriteLine("Cat meows");
    }
}
