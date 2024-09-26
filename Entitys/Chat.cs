using System.Xml.Linq;

namespace WPF_MVVM_TEMPLATE.Entitys;

public class Chat
{
    private EFeelings? _feeling;
    private XElement _element;

    public XElement Element
    {
        get => _element;
    }
    
    public Chat(XElement element)
    {
        _element = element; 
    }

    public Chat(EFeelings feeling, XElement element)
    {
        _feeling = feeling;
        _element = element;
    }
    
    public XElement GetElement()
    {
        return _element;
    }
    
}