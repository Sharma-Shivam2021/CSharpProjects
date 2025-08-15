using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCode_SOLID_;

public class Order
{
    public int Id { get; set; }
    public string ProductName { get; set; }
    public int Quantity { get; set; }

    public double Price { get; set; }

}

public class OrderPrinter
{
    public void PrintOrderDetails(List<Order> orders)
    {
        double totalPrice = 0;
        foreach (Order order in orders)
        {
            if (order.Quantity > 0 && order.Price > 0)
            {
                totalPrice += order.Quantity * order.Price;
                double total = order.Price * order.Quantity;
                Console.WriteLine("Order ID: " + order.Id);
                Console.WriteLine("Product: " + order.ProductName);
                Console.WriteLine("Quantity: " + order.Quantity);
                Console.WriteLine("Price: " + order.Price);
                Console.WriteLine("Total: " + total);
                Console.WriteLine("----------------------------");
            }
        }
        Console.WriteLine("Total Price: " + totalPrice);
    }
}
