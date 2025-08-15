using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCode_SOLID_.SOLID;

// if one interface gets too big such that some classes do not implement most of the methods
// then we need to separate these methods into different interface
// to reduce the clutter


/*

// Current status
public interface IWorker
{
    void Work();
    void Eat();
}

public class Worker : IWorker
{
    public void Eat()
    {
        Console.WriteLine("Eating");
    }

    public void Work()
    {
        Console.WriteLine("Working");
    }
}

public class Robot : IWorker
{
    public void Eat()
    {
        // Forced to create this method even though 
        // it is not required for this class
        throw new NotImplementedException();
    }

    public void Work()
    {
        Console.WriteLine("Working");
    }
}

*/

// Solution using Interface Segeragation

public interface IEatable
{
    void Eat();
}

public interface IWorkable
{
    void Work();
}


public class Worker : IWorkable, IEatable
{
    public void Eat()
    {
        Console.WriteLine("Eating");
    }

    public void Work()
    {
        Console.WriteLine("Working");
    }
}

public class Robot : IWorkable
{
    public void Work()
    {
        Console.WriteLine("Working");
    }
}