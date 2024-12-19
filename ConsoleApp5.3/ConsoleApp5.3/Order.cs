using System;

public class Order : IOrder
{
    public void PlaceOrder(ICustomer customer)
    {
        Console.WriteLine($"Order placed by {customer.Name}. Thank you for your purchase!");
    }
}
