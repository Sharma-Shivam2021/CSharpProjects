namespace InheritanceApp;

/*
 * An abstract class is a class that cannot be instantiated directly. 
 * Instead, it serves as a blueprint for other classes. 
 * It is meant to be inherited by other classes that provide 
 * specific implementations for its abstract methods.
 * An abstract method is a method that is declared but not 
 * defined in the abstract class. It must be overridden in a 
 * derived class.
 * This allows developers to enforce a structure and behavior
 * across multiple related classes while allowing for 
 * flexibility in implementation. 
 */

abstract class Vehicle
{
    public int Speed { get; set; }
    public abstract void Move();
}

class Car : Vehicle
{
    public override void Move()
    {
        Console.WriteLine("The car is driving.");
    }
}
