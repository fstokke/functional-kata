using FunctionalKata.MutableState;

namespace FunctionalKataTests.MutableState;

public class ShoppingCartTests
{
    [Fact]
    public void CanAddItemToShoppingCart()
    {
        var shoppingCart = new ShoppingCart()
            .AddItem("Apple", 100, 1);

        Assert.Single(shoppingCart.Items);
        var item = shoppingCart.Items.Single();
        Assert.Equal("Apple", item.Name);
        Assert.Equal(100.0M, item.Price);
        Assert.Equal(1, item.Quantity);
        Assert.Equal(100, shoppingCart.TotalAmount);
    }
    
    
    [Fact]
    public void CalculatesCorrectTotalAmount()
    {
        var shoppingCart = new ShoppingCart()
            .AddItem("Apple", 100, 1) 
            .AddItem("Banana", 200, 2);

        Assert.Equal(2, shoppingCart.Items.Count());
        Assert.Equal(500, shoppingCart.TotalAmount);
    }
}
