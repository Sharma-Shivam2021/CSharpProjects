using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCode_SOLID_.SOLID;

internal class SRP_OrderService
{
    private List<Order> _orders = new List<Order>();
    private OrderLogger _orderLogger = new OrderLogger();
    private OrderNotifier _orderNotifier = new OrderNotifier();

    public void AddOrder(Order order)
    {
        _orders.Add(order);
        _orderLogger.LogOrder(order);
        _orderNotifier.NotifyCustomer(order);
    }


    /* SINGLE RESPONSIBILTY PRINCIPLE 
     * It states that one class should only perform one type of action
     * Logging and Notifying have nothing to do with 
     * Order Service 
     * it can add, remove, edit and read the orders
    private void NotifyCustomer(Order order)
    {
        Console.WriteLine($"Order {order.Id} logged");
    }

    private void LogOrder(Order order)
    {
        Console.WriteLine($"Customer notified for order {order.Id}");
    }
    */
}

internal class OrderLogger
{
    public void LogOrder(Order order)
    {
        Console.WriteLine($"Customer notified for order {order.Id}");
    }
}
internal class OrderNotifier
{
    public void NotifyCustomer(Order order)
    {
        Console.WriteLine($"Order {order.Id} logged");
    }
}
