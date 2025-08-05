
namespace InheritanceApp;

class BaseClass
{
    public int publicField;
    protected int protectedField;
    // access only within same class
    private int privateField;

    public void ShowFields()
    {
        Console.WriteLine($"Public: {publicField}, " +
            $"Protected: {protectedField}, " +
            $"Private: {privateField}");
    }
}

class DerivedClass : BaseClass
{
    public void AccessFields()
    {
        publicField = 1;
        protectedField = 2;
        // private field of base class can not be accessed by the derived class
        //privateField = 3;
        ShowFields();
    }
}