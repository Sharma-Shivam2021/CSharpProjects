/*
 * An interface in C# is a contract that defines a set of 
 * members (methods, properties, events, or indexers) 
 * that implementing classes or structs must provide. 
 * Interfaces do not contain implementation, only the 
 * signatures. They enable abstraction, polymorphism, 
 * and decoupling in your code.
 */

using InterfacesApp;

internal class Program
{
    
    static void Main(string[] args)
    {
        IPaymentProcessor creditCardProcessor=new CreditCardProcessor();
        PaymentService paymentService= new PaymentService(creditCardProcessor);
        paymentService.ProcessOrderPayment(12);

        IPaymentProcessor payPapProcessor=new PaypalProcessor();
        PaymentService paypal=new PaymentService(payPapProcessor);
        paypal.ProcessOrderPayment(13);
    }
}