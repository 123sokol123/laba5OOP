using System;
using System.Collections.Generic;

public class Customer : ICustomer
{
    public string Name { get; private set; }
    private List<IBook> Cart;

    public Customer(string name)
    {
        Name = name;
        Cart = new List<IBook>();
    }

    public void AddToCart(IBook book)
    {
        Cart.Add(book);
        Console.WriteLine($"Book '{book.Title}' added to the cart.");
    }

    public void ViewCart()
    {
        Console.WriteLine($"{Name}'s Cart:");
        foreach (var book in Cart)
        {
            book.DisplayInfo();
        }
    }
}
