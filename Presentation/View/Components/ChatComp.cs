using System.Windows.Controls;
using System.Windows.Media;
using WPF_MVVM_TEMPLATE.Entitys;

namespace WPF_MVVM_TEMPLATE.Presentation.View.Components;

public class ChatComp : StackPanel
{

    private List<MessageComp> _messagesComps;
    private List<Message> _messages;
    private Feelings _ChatFeeling;

    public ChatComp(Feelings chatFeeling, List<Message> messages)
    {
        _ChatFeeling = chatFeeling;
        _messages = messages;

        _messagesComps = CreateMessageComp(_messages);
        CrateChatComp(_messagesComps, chatFeeling);
        
    }

    private void CrateChatComp(List<MessageComp> messageComps, Feelings chatFeeling)
    {
        
        Label labelFeeling = new Label();
        labelFeeling.Content = chatFeeling.ToString();
        
        Label lableMessageOcurence = new Label();
        lableMessageOcurence.Content = messageComps.Count;

        Children.Add(labelFeeling);
        Children.Add(lableMessageOcurence);

        foreach (var VARIABLE in messageComps)
        {
            Children.Add(VARIABLE);

        }
        

    }

    private List<MessageComp> CreateMessageComp(List<Message> messages)
    {
        
        List<MessageComp> messageComps = new List<MessageComp>();

        foreach (Message message in messages)
        {
            messageComps.Add(new MessageComp(message.Text));
        }

        return messageComps; 

    }
    
    
}
