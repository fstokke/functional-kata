using FunctionalKata.MutableState;

namespace FunctionalKataTests.MutableState;

public class DiscountCalculatorTests
{
    [Fact]
    public void NoDiscountWhenAmountIsLessThanMinimum()
    {
        var shoppingCart = new ShoppingCart()
            .AddItem("Apple", 100, 1) 
            .AddItem("Banana", 200, 2)
            .AddItem("Pear", 499, 1);

        var discountCalculator = new DiscountCalculator();

        var totalDiscount = discountCalculator.CalculateDiscount(shoppingCart);
        
        Assert.Equal(999, shoppingCart.TotalAmount);
        Assert.Equal(0, totalDiscount);
    }
    
    [Fact]
    public void Get10PercentDiscountWhenTotalIsGreaterThanOrEqualTo1000()
    {
        var shoppingCart = new ShoppingCart()
            .AddItem("Apple", 100, 1) 
            .AddItem("Banana", 200, 2)
            .AddItem("Pear", 500, 1);

        var discountCalculator = new DiscountCalculator();

        var totalDiscount = discountCalculator.CalculateDiscount(shoppingCart);
        
        Assert.Equal(1000, shoppingCart.TotalAmount);
        Assert.Equal(100, totalDiscount);
    }
    
    [Fact]
    public void Get5PercentDiscountWhenBuying10OrMoreItems()
    {
        var shoppingCart = new ShoppingCart()
            .AddItem("Apple", 100, 10) 
            .AddItem("Banana", 50, 9)
            .AddItem("Pear", 150, 1);

        var discountCalculator = new DiscountCalculator();

        var totalDiscount = discountCalculator.CalculateDiscount(shoppingCart);
        
        Assert.Equal(1600, shoppingCart.TotalAmount);
        const decimal flatDiscount = 1600 * 0.1m;
        const decimal bulkDiscount = 100 * 10 * 0.05m;
        Assert.Equal(flatDiscount + bulkDiscount, totalDiscount);
    }
}