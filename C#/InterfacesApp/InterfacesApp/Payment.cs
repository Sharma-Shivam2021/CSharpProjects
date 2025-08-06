namespace InterfacesApp;

/*
 * An interface in C# is a contract that defines a set of 
 * members (methods, properties, events, or indexers) 
 * that implementing classes or structs must provide. 
 * Interfaces do not contain implementation, only the 
 * signatures. They enable abstraction, polymorphism, 
 * and decoupling in your code.
 */
public interface IPaymentProcessor
{
    void ProcessPayment(decimal amount);
}

public class CreditCardProcessor : IPaymentProcessor
{
    public void ProcessPayment(decimal amount)
    {
        Console.WriteLine($"Processing credit card payment of {amount}");
    }
}

public class PaypalProcessor : IPaymentProcessor
{
    public void ProcessPayment(decimal amount)
    {
        Console.WriteLine($"Processing Paypal payment of {amount}");
    }
}

public class PaymentService
{
    private readonly IPaymentProcessor _processor;

    public PaymentService(IPaymentProcessor processor)
    {
        _processor = processor;
    }

      public void ProcessOrderPayment(decimal amount)
    {
        _processor.ProcessPayment(amount);
    }
}