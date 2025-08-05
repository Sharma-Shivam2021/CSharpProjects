
namespace InheritanceApp;
/*
 * Method Hiding is a technique in C# that allows a derived class 
 * to define a method with the same name as a method in the 
 * base class, effectively hiding the base class method rather 
 * than overriding it. This is done using the new keyword.
 */
class MethodHidingBase
{
    public void ShowMessage()
    {
        Console.WriteLine("Message from MethodHidingBase");
    }
}

class MethodHidingDerived : MethodHidingBase
{
    public new void ShowMessage()
    {
        Console.WriteLine("Message from MethodHidingDerived");
    }
}


