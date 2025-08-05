namespace ClassesApp.Classes;

//class is accessible only within the same assembly
//(project or compiled output, such as a DLL or EXE).

internal class Car
{/*
    // member variable;
    // private hides the variable from other classes
    // Backing Field of the Model Property
    //A backing field is a private variable in a class that stores the actual data for a property.
    //In C#, properties provide a way to control access to the data, while the backing field holds
    //the value.
    //	_model is the backing field.
    //	Model is the property that exposes _model to other classes.
    //Why use backing fields?
    //•	They let you add logic when getting or setting a value (e.g., validation).
    //•	They encapsulate the data, hiding it from outside code.

    // These two variables do not change how they are get and set.
    //Therefore these can be set as property alone with simple get and set method.
    //private string _model = "";
    //private bool _isLuxury;
    // Lambda Expression (function => expression)
    */
    // static field accesible by Car class only and not its instances
    public static int NumberOfCars = 0;

    private string _brand = "";
    // Property
    public string Brand
    {
        get
        {
            if (IsLuxury)
            {
                return _brand + " - Luxury Edition";
            }
            else
            {
                return _brand;
            }
        }
        set
        {
            if (string.IsNullOrEmpty(value))
            {
                Console.WriteLine("You entered Nothing.");
                _brand = "DEFAULT_VALUE";
            }
            else
            {
                _brand = value;
            }
        }
    }
    public string Model { get; set; }
    public bool IsLuxury { get; set; }


    public Car()
    {
        NumberOfCars++;
    }

    //Constructor
    public Car(string model, string brand, bool isLuxury)
    {
        NumberOfCars++;
        Model = model;
        Brand = brand;
        IsLuxury = isLuxury;
        Console.WriteLine("A car of the " + Brand + " and model " + Model + " has been created");
    }

    public void Drive()
    {
        Console.WriteLine("I'm driving.");
    }
}
