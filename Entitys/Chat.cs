using System.Xml.Linq;

namespace WPF_MVVM_TEMPLATE.Entitys;

public class Chat
{
    public EFeelings Feeling {get; set;}
    public XElement Element { get; set; }
    
    public Chat(XElement element, EFeelings feeling)
    {
        Element = element; 
        Feeling = feeling;
    }
    
    
}