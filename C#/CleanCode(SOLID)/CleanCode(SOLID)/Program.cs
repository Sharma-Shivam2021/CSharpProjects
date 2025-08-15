using CleanCode_SOLID_;
using CleanCode_SOLID_.SOLID;

/*
 * This project file contains the c# clean code 
 * explanation.
 */


// bad Example

int n = 0;
string s = "John";

// good  -- Verbose Name
int studentCount = 100;
string studentName = "John";

// for boolean values or boolean method 
// should contain has or is in the name
bool hasError = false;

bool isValid = true;

List<Order> orders = new List<Order>
{
    new Order{Id=1,ProductName="Laptop",Quantity=2,Price=1500},
    new Order{Id=2,ProductName="Phone",Quantity=5,Price=500}
};

OrderPrinter orderPrinter = new OrderPrinter();
//orderPrinter.PrintOrderDetails(orders);


Invoice invoice = new Invoice { Amount = 100 };
BillingService billingService = new BillingService();
double total = billingService.CalculateTotal(invoice);
//Console.WriteLine("Total: "+total);

DiscountedInvoice discountedInvoice = new DiscountedInvoice();
discountedInvoice.Amount = 100;
discountedInvoice.Discount = 25;
DiscountedBillingService discountedBillingService = new DiscountedBillingService();
double discountedTotal = discountedBillingService.CalculateTotal(discountedInvoice);
//Console.WriteLine("Discounted Total "+discountedTotal);


Bird sparrow = new Sparrow();
//sparrow.MakeSound();

// this way only flying bird or class that implements the IFlyable 
// interface are able to call Fly() method

//((IFlyable)sparrow).Fly();

Bird penguin = new Penguin();
//penguin.MakeSound(); 


Worker humanWorker=new Worker();
//humanWorker.Eat();
//humanWorker.Work();

Robot robot= new Robot();
//robot.Work();

IEmailService emailService = new EmailService();
Notification notification = new Notification(emailService);
notification.Send("Hello World");













/*
 * PascalCase ->
 *  1. class Name
 *  2. PropertyName
 *  3. Method / Function Name
 * 
 * camelCase
 *  1. Function/Method Argument
 *  2. Field in method/function
 *  3. private field -> it can contain an underscore at the start of the name
 * 
 * AllCaps
 *  1. used to declare const keywords
 */


class CustomerService // PascalCase
{
    public const int MAX_CUSTOMER = 100; // ALL_CAPS

    public int CustomerCount { get; set; } // PascalCase
    /// <summary>
    /// Gets the customer by Id
    /// </summary>
    /// <param name="customerId"> The id for the customer to retrieve</param>
    /// <returns>Returns the customer found by Id</returns>
    public string GetCustomerName(int customerId /* camelCase*/) // PascalCase
    {
        string customnerName = "John Doe"; //camelCase
        return customnerName;
    }

    private string lastCustomerName = "John"; // camelCase

    private string _cutomerName = "JohnDoe"; // underScore camelCase

    // this is also valid but in the customer to resolve conflict between the argument and the field 
    // we'll need to use the 'this' keyword
    //private string cutomerName = "JohnDoe"; // underScore camelCase

    public CustomerService(string customerName)
    {
        _cutomerName = customerName;
        //this.cutomerName = customerName;  using 'this' to resolve conflict
    }

    //bad 
    public void Save() { }

    // good 
    public void SaveCustomer() { }

    public void SaveCustomerName() { }


    /*
     * For method name it's best to use
     * Is, Get, Set, Has, Can
     */

    public void SetCustomerName() { }

    public string GetCustomerName() { return ""; }

    public bool HasError() { return false; }

    public bool CanReceiveEmail() { return false; }


}

/*
* class Name should be a noun
* Method name should be a verb
* 
*/
class OrderProcessor
{
    public void ProcessOrder()
    {

    }
    public void PrintOrder() { }
    public void DeleteOrder()
    {
    }
}


/// <summary>
/// Represent the Customer with Id and Name
/// 
/// </summary>
class Customer
{
    /// <summary>
    /// Gets the Id of the customer
    /// </summary>
    public int id { get; }
    /// <summary>
    /// Gets and Sets the name of the customer
    /// </summary>
    public string Name { get; set; }
}



