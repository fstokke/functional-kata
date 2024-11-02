namespace FunctionalKata.MutableState;

public class ShoppingCartItem
{
    public string Name { get; set; }
    public decimal Price { get; set; }
    public int Quantity { get; set; }

    public ShoppingCartItem(string name, decimal price, int quantity)
    {
        Name = name;
        Price = price;
        Quantity = quantity;
    }
}

public class ShoppingCart
{
    private List<ShoppingCartItem> _items;

    public ShoppingCart()
    {
        _items = new List<ShoppingCartItem>();
    }

    public ShoppingCart AddItem(string name, decimal price, int count )
    {
        _items.Add(new ShoppingCartItem(name, price, count));
        return this;
    }

    
    public decimal TotalAmount
    {
        get
        {
            var totalAmount = 0m;
            foreach (var item in _items)
            {
                totalAmount += item.Price * item.Quantity;
            }

            return totalAmount;
        }
    }
    
    public IEnumerable<ShoppingCartItem> Items
    {
        get { return _items;  }
    }
    
}