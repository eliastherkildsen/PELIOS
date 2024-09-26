using System.Windows.Controls;

namespace WPF_MVVM_TEMPLATE.Presentation.View.Components;

public class MessageComp : StackPanel
{
    
    private Label _message;
    private Button _deleteButton;

    public MessageComp(string message)
    {
        
        Children.Add(CreateLable(message));
        Children.Add(CreateButton("Remove"));
        
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