namespace FunctionalKata.MutableState;

public class DiscountCalculator(
    decimal minimumFlatDiscountAmount = 1000,
    int minimumBulkDiscountQuantity = 10,
    decimal flatDiscountRate = 0.1m,
    decimal bulkDiscountRate = 0.05m)
{

    public decimal CalculateDiscount(ShoppingCart cart) =>
        CalculateFlatRateDiscount(cart) + CalculateBulkDiscount(cart);

    private decimal CalculateFlatRateDiscount(ShoppingCart cart) =>
        cart.TotalAmount >= minimumFlatDiscountAmount
            ? cart.TotalAmount * flatDiscountRate
            : 0.0m;

    private decimal CalculateBulkDiscount(ShoppingCart cart) =>
        cart.Items
            .Where(item => item.Quantity >= minimumBulkDiscountQuantity)
            .Sum(item => item.Price * item.Quantity * bulkDiscountRate);
    
}