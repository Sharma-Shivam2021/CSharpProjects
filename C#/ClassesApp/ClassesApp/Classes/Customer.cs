namespace ClassesApp.Classes;

internal class Customer
{
    private static int nextId = 0;
    private readonly int _id;
    // Properties
    public string? Name { get; set; }
    public string? Address { get; set; }
    public string? ContactNumber { get; set; }

    // read-only property
    public int Id { get { return _id; } }

    // Custom Constructor
    public Customer(string name, string address, string contactNumber)
    {
        Name = name;
        Address = address;
        ContactNumber = contactNumber;
    }

    public Customer(string name)
    {
        _id = nextId++;
        Name = name;
    }

    // Deafult Contructor
    public Customer()
    {
        _id = nextId++;
        Name = "No Name";
        Address = "No Address";
        ContactNumber = "No Contact Number";
    }

    public void SetDetails(string name, string address, string contactNumber)
    {
        Name = name;
        Address = address;
        ContactNumber = contactNumber;
    }

    public void GetDetail()
    {
        Console.WriteLine("Customer Id: " + _id + "\nCustomer Name: " + Name);
    }

    public static void DoSomeCustomerStuff()
    {
        Console.WriteLine("Customer Class doing some stuff");
    }
}

