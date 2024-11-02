using System.Collections.Immutable;

namespace FunctionalKataLib;

public interface IPrinter<T>
{
    void PrintObject(T obj);
}

public class MockPrinter<T> : IPrinter<T>
{
    private readonly List<T> _objects = [];

    public ImmutableList<T> Objects => _objects.ToImmutableList();

    public void PrintObject(T obj)
    {
        _objects.Add(obj);
    }
}