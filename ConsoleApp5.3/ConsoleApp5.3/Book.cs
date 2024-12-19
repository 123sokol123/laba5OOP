public class Book : IBook
{
    public string Title { get; private set; }
    public string Author { get; private set; }
    public decimal Price { get; private set; }

    public Book(string title, string author, decimal price)
    {
        Title = title;
        Author = author;
        Price = price;
    }

    public void DisplayInfo()
    {
        Console.WriteLine($"Title: {Title}, Author: {Author}, Price: {Price:C}");
    }
}
