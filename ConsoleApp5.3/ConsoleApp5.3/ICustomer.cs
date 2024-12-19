public interface ICustomer
{
    string Name { get; }
    void AddToCart(IBook book);
    void ViewCart();
}
