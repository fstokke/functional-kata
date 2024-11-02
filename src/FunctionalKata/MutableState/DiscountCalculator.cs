namespace FunctionalKata.MutableState;

public class DiscountCalculator
{
    public decimal MinimumFlatDiscountAmount { get; set; }
    public int MinimumBulkDiscountQuantity { get; set; }
    public decimal FlatDiscountRate { get; set; }
    public decimal BulkDiscountRate { get; set; }

    private ShoppingCart? _cart;
    private decimal _totalDiscount;
    
    public DiscountCalculator(
        decimal minimumFlatDiscountAmount = 1000, 
        int minimumBulkDiscountQuantity = 10, 
        decimal flatDiscountRate = 0.1m, 
        decimal bulkDiscountRate = 0.05m)
    {
        MinimumFlatDiscountAmount = minimumFlatDiscountAmount;
        MinimumBulkDiscountQuantity = minimumBulkDiscountQuantity;
        FlatDiscountRate = flatDiscountRate;
        BulkDiscountRate = bulkDiscountRate;
    }
    
    public decimal CalculateDiscount(ShoppingCart cart)
    {
        _cart = cart;
        
        CalculateFlatRateDiscount();

        CalculateBulkDiscount();

        return _totalDiscount;
    }

    private void CalculateFlatRateDiscount()
    {
        if (_cart!.TotalAmount >= MinimumFlatDiscountAmount)
        {
            // Flat discount on total price
            _totalDiscount += _cart.TotalAmount * FlatDiscountRate; 
        }
    }

    private void CalculateBulkDiscount()
    {
        foreach (var item in _cart!.Items)
        {
            if (item.Quantity >= MinimumBulkDiscountQuantity)
            {
                // Extra discount when buying more than N items
                _totalDiscount += item.Price * item.Quantity * BulkDiscountRate; 
            }
        }
    }
}