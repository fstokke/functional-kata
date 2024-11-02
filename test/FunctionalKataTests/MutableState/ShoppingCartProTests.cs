using FunctionalKata.MutableState;

namespace FunctionalKataTests.MutableState;

public class ShoppingCartProTests
{
    [Fact]
    public void CanAddItemToShoppingCart()
    {
        var shoppingCart = new ShoppingCartPro()
            .AddItem("Apple", 100, 1);

        Assert.Single(shoppingCart.Items);
        var item = shoppingCart.Items.Single();
        Assert.Equal("Apple", item.Name);
        Assert.Equal(100, item.Price);
        Assert.Equal(1, item.Count);
        Assert.Equal(100, shoppingCart.TotalAmount);
    }
    
    
    [Fact]
    public void CalculatesCorrectTotalAmount()
    {
        var shoppingCart = new ShoppingCartPro()
            .AddItem("Apple", 100, 1) 
            .AddItem("Banana", 200, 2);

        Assert.Equal(2, shoppingCart.Items.Count());
        Assert.Equal(500, shoppingCart.TotalAmount);
    }
    
    [Fact]
    public void GroupsItemsWithSameNameAndPrice()
    {
        var shoppingCart = new ShoppingCartPro()
            .AddItem("Apple", 100, 1)
            .AddItem("Banana", 200, 2)
            .AddItem("Banana", 200, 3)
            .AddItem("Apple", 50, 3);

        Assert.Equal(3, shoppingCart.Items.Count());
        Assert.Equal(1250, shoppingCart.TotalAmount);
        var bananas = shoppingCart.Items.Single(item => item.Name == "Banana");
        Assert.Equal(5, bananas.Count);
        
    }
    
    [Fact]
    public void CanAddMultipleItems()
    {
        var initialCart = new ShoppingCartPro()
            .AddItem("Apple", 100, 1) 
            .AddItem("Banana", 200, 2);
        
        var shoppingCart = initialCart
            .AddItems(new[]
            {
                new ShoppingCartProItem("Banana", 200, 2),
                new ShoppingCartProItem("Apple", 50, 3),
                new ShoppingCartProItem("Banana", 200, 2),
                new ShoppingCartProItem("Pear", 300, 2),
            });
        
        Assert.Equal(4, shoppingCart.Items.Count());
        Assert.Equal(2050, shoppingCart.TotalAmount);
        var bananas = shoppingCart.Items.Single(item => item.Name == "Banana");
        Assert.Equal(200, bananas.Price);
        Assert.Equal(6, bananas.Count);

    }
}
