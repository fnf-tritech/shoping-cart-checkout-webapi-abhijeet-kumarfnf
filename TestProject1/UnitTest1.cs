namespace ShoppingCheckout;
public class UnitTest1
{
    private readonly CheckoutServices _checkout;
    public UnitTest1()
    {
        _checkout = new CheckoutServices();
    }
    [Fact]
    public void Test1()
    {
        string skus = "";
        int totalPrice = _checkout.Checkout(skus);
        Assert.Equal(0, totalPrice);
    }
}