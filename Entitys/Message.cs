namespace WPF_MVVM_TEMPLATE.Entitys;

public class Message
{
    public Message(string message)
    {
        Text = message;
    }
    public string Text { get; set; }
    
}