namespace InheritanceApp;

/*
 * A sealed method is a method in a base class 
 * that prevents further overriding in derived classes.
 * In other words, once a method is sealed, 
 * it cannot be modified by any subclass.
 * In C#, a method can only be sealed if it is already overridden 
 * in a derived class. This means you cannot seal a method 
 * directly in the base class; 
 * it must first be an overridden method. 
 */

class SealedMethodBase
{
    public virtual void ShowMessage()
    {
        Console.WriteLine("Message from BaseClass");
    }
}

class SealedMethodDerive : SealedMethodBase
{
    public sealed override void ShowMessage()
    {
        Console.WriteLine("Message from Derive (Sealed)");
    }
}

class SubDerivedClass: SealedMethodDerive
{
    // ERROR: Cannot override because it's sealed
    //public override void ShowMessage()
    //{

    //}
}