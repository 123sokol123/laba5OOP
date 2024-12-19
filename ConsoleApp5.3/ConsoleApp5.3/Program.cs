using System;

class Program
{
    static void Main(string[] args)
    {
        IBook book1 = new Book("C# Programming", "John Doe", 29.99m);
        IBook book2 = new Book("Design Patterns", "Jane Smith", 39.99m);

        ICustomer customer = new Customer("Alice");
        customer.AddToCart(book1);
        customer.AddToCart(book2);

        customer.ViewCart();

        IOrder order = new Order();
        order.PlaceOrder(customer);
    }
}
