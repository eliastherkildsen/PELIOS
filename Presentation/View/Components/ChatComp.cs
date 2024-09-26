using System.Windows.Controls;
using System.Windows.Media;
using WPF_MVVM_TEMPLATE.Entitys;

namespace WPF_MVVM_TEMPLATE.Presentation.View.Components;

public class ChatComp : StackPanel
{

    private List<MessageComp> _messagesComps;
    private List<Message> _messages;
    private EFeelings _chatEFeeling;

    public ChatComp(EFeelings chatEFeeling, List<Message> messages)
    {
        _chatEFeeling = chatEFeeling;
        _messages = messages;

        _messagesComps = CreateMessageComp(_messages);
        CrateChatComp(_messagesComps, chatEFeeling);
        
    }

    private void CrateChatComp(List<MessageComp> messageComps, EFeelings chatEFeeling)
    {
        
        Label labelFeeling = new Label();
        labelFeeling.Content = chatEFeeling.ToString();
        
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
