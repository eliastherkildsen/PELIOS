using System.Xml.Linq;

namespace WPF_MVVM_TEMPLATE.Entitys;

public class Chat
{
    public EFeelings Feeling {get; set;}
    public XElement Element { get; set; }
    public List<Message> Messages{ get; set; }
    
    public Chat(XElement element, EFeelings feeling)
    {
        Element = element; 
        Feeling = feeling;
    }
    public Chat(XElement element, EFeelings feeling, List<Message> messages)
    {
        Element = element; 
        Feeling = feeling;
        Messages = messages;
    }
    
    
}