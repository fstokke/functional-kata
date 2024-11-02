namespace FunctionalKata.MutableState;

public record Product(string Name, decimal Price);
public record ShoppingCartProItem(string Name, decimal Price, int Count);


public class ShoppingCartPro
{
    private readonly Dictionary<Product, int> _items;

    public ShoppingCartPro()
    {
        _items = new Dictionary<Product, int>();
    }
    
    public ShoppingCartPro AddItem(string name, decimal price, int count)
    {
        int existingCount;
        var newCount = count;
        var product = new Product(name, price);
        if (_items.TryGetValue(product, out existingCount))
        {
            newCount += existingCount;
        }
        _items[product] = newCount;
        return this;
    }

    public ShoppingCartPro AddItems(IEnumerable<ShoppingCartProItem> items)
    {
        foreach (var item in items)
        {
            AddItem(item.Name, item.Price, item.Count);
        }

        return this;
    }
    
    public IEnumerable<ShoppingCartProItem> Items {
        get
        {
            var items = new List<ShoppingCartProItem>();
            foreach (var (product, count) in _items)
            {
                items.Add(new ShoppingCartProItem(product.Name, product.Price, count));
            }
            return items;
        }
    }

    public decimal TotalAmount => _items.Sum(pair => pair.Key.Price * pair.Value);
     
}