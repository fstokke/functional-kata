using System.Collections.Immutable;

namespace FunctionalKata.MutableState;

public record Product(string Name, decimal Price);
public record ShoppingCartProItem(string Name, decimal Price, int Count);


public class ShoppingCartPro
{
    private readonly ImmutableDictionary<Product, int> _items;
    private readonly Lazy<decimal> _totalAmount;
    

    public ShoppingCartPro()
        : this(ImmutableDictionary<Product, int>.Empty)
    {
    }
    
    private ShoppingCartPro(ImmutableDictionary<Product, int> items)
    {
        _items = items;
        _totalAmount = new Lazy<decimal>(CalculateTotalAmount);
    }
    
    public ShoppingCartPro AddItem(string name, decimal price, int count)
    {
        var product = new Product(name, price);
        var newCount = GetExistingCount(_items, product) + count;
        return new ShoppingCartPro(_items.SetItem(product, newCount));
    }

    public ShoppingCartPro AddItems(IEnumerable<ShoppingCartProItem> items)
    {
        var newItems = _items.ToBuilder();
        foreach (var item in items)
        {
            var product = new Product(item.Name, item.Price);
            var newCount = GetExistingCount(newItems, product) + item.Count;
            newItems[product] = newCount;
        }

        return new ShoppingCartPro(newItems.ToImmutable());
    }
    
    public IEnumerable<ShoppingCartProItem> Items => 
        _items.Select(item => new ShoppingCartProItem(item.Key.Name, item.Key.Price, item.Value));

    public decimal TotalAmount => _totalAmount.Value;
    
    private decimal CalculateTotalAmount() => _items.Sum(pair => pair.Key.Price * pair.Value);
    
    private static int GetExistingCount(IDictionary<Product, int> items, Product product) => 
        items.TryGetValue(product, out var existingCount) ? existingCount : 0;
}