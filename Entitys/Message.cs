using System.Xml.Linq;

namespace WPF_MVVM_TEMPLATE.Entitys;

public class Message
{
    public Message(string message, string sentiment, string messageExchange)
    {
        Text = message;
        Sentiment = sentiment;
        MessageExchange = messageExchange;
    }

    public Message(XElement element)
    {
        Element = element;
    }
    
    public string Text { get; set; }
    public string Sentiment { get; set; }
    public string MessageExchange { get; set; }
    public XElement Element { get; set; }
}