
namespace InheritanceApp;


internal class Animal
{

    public void Eat()
    {
        Console.WriteLine("Eating...");
    }

    // used to make a method overridable
    public virtual void MakeSound()
    {
        Console.WriteLine("Animal Makes sound.");
    }
}

///*
// Single Inheritance
// Dog -> Animal
class Dog : Animal
{
    // overriding the MakeSound method of BaseClass(Animal)
    public override void MakeSound()
    {
        Console.WriteLine("Barking...");
    }
}
//*/

///*
// Multilevel Inheritance
// Collie -> Dog -> Animal
class Collie : Dog
{
    public void Active()
    {
        Console.WriteLine("Collie are super active breed of dog");
    }
}
//*/

///*
// Hierarchical inheritance
// Animal -> Dog
// Animal -> Cat
// Animal -> Pig
class Cat : Animal
{
    // overriding the MakeSound method of BaseClass(Animal)
    public override void MakeSound()
    {
        Console.WriteLine("Meowing...");
    }
}

class Pig : Animal
{
    // overriding the MakeSound method of BaseClass(Animal)
    public override void MakeSound()
    {
        Console.WriteLine("Oinking");
    }
}
//*/