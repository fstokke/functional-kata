using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;

namespace FunctionalKataLib;


public interface IEpostSender
{
    void SendEpost(string epost, string title, string text);
}

public class MockEpostSender : IEpostSender
{
    [SuppressMessage("ReSharper", "NotAccessedPositionalProperty.Global")]
    public record Message(string Epost, string Title, string Text);

    private readonly List<Message> _messages = [];
    
    public void SendEpost(string epost, string title, string text)
    {
        _messages.Add(new Message(epost, title, text));
    }

    public ImmutableList<Message> Messages => _messages.ToImmutableList();
}