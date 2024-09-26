using System.Windows.Controls;
using System.Xml.Linq;
using WPF_MVVM_TEMPLATE.Entitys;

namespace WPF_MVVM_TEMPLATE.Presentation.View.Components;

public class MessageComp : StackPanel
{
    
    private Label _messageLabel;
    private Button _deleteButton;
    private String _messageText;
    private Message _message;
    
    
    public MessageComp(Message message)
    {
        _message = message; 
        _messageText = GetMessageFromElemet(_message.Element); 
        
        Children.Add(_messageLabel);
        Children.Add(_deleteButton);
        
    }

    private string GetMessageFromElemet(XElement element)
    {
        var message = from e in element.Descendants("Text") select e; 
        
        if (!message.Any()) throw new NullReferenceException("The message is empty");
        return message.First().Value; 
    }

    private Label CreateLable(string content)
    {
        var label = new Label();
        label.Content = content;
        return label;
    }

    private Button CreateButton(string content)
    {
        var button = new Button();
        button.Content = content;
        return button;
    }
    
}