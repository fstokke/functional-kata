using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;

namespace FunctionalKata.MutableState;

[SuppressMessage("ReSharper", "NotAccessedPositionalProperty.Global")]
public record ShoppingCartItem(string Name, decimal Price, int Quantity);

public class ShoppingCart
{
    private readonly ImmutableList<ShoppingCartItem> _items;
    private readonly decimal _totalAmount;

    public ShoppingCart()
    {
        _items = [];
        _totalAmount = 0;
    }

    private ShoppingCart(ImmutableList<ShoppingCartItem> items, decimal totalAmount)
    {
        _items = items;
        _totalAmount = totalAmount;
    }

    public ShoppingCart AddItem(string name, decimal price, int count) =>
        new(_items.Add(new ShoppingCartItem(name, price, count)), _totalAmount + price * count);

    public decimal TotalAmount => _totalAmount;

    public IEnumerable<ShoppingCartItem> Items => _items;
}