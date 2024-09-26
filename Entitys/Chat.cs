using System.Xml.Linq;

namespace WPF_MVVM_TEMPLATE.Entitys;

public class Chat
{
    private EFeelings _feeling;
    private XElement _element;
    
    public Chat(EFeelings feeling, XElement element)
    {
        _feeling = feeling;
        _element = element; 
    }
    
    
}