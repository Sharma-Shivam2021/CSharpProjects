using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCode_SOLID_.SOLID;

// Liskov Substitution
// can replace derive classes with base class
// without causing errors
internal class Bird
{
    public virtual void MakeSound()
    {
        Console.WriteLine("Chirp");
    }
}

internal class Penguin : Bird
{
    public override void MakeSound()
    {
        base.MakeSound();
    }
}


// Flyable class
internal class Sparrow : Bird, IFlyable
{
    public void Fly()
    {
        Console.WriteLine("Fly");
    }
}

// Solution to make sure that only flying birds have method
// to call Fly()  method

public interface IFlyable
{
    void Fly();
}