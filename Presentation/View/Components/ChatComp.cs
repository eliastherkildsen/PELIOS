using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using WPF_MVVM_TEMPLATE.Entitys;

namespace WPF_MVVM_TEMPLATE.Presentation.View.Components;

public class ChatComp : StackPanel
{

    private List<MessageComp> _messagesComps;
    private List<Message> _messages;
    private Chat _chat;
    private EFeelings _chatEFeeling;

    public ChatComp(Chat chat)
    {
        _chatEFeeling = chat.Feeling;
        _messages = chat.Messages;
        _messagesComps = CreateMessageComp(_messages);
        
        CrateChatComp(_chatEFeeling, _messagesComps);
        
    }

    private List<MessageComp>? CreateMessageComp(List<Message> messages)
    {
        
        List<MessageComp> messageComps = new List<MessageComp>();
        foreach (var msg in messages)
        {
            messageComps.Add(new MessageComp(msg));
        }
        
        return messageComps;
    }

   
    
    private void CrateChatComp(EFeelings chatEFeeling, List<MessageComp> messageComps)
    {
        int count = 0;
        Label feeling = CreateLabel(chatEFeeling.ToString());
        Children.Add(feeling);
        
        foreach (var msg in messageComps)
        {
            Children.Add(msg);
            count++;
        }
        
        feeling.Content = feeling.Content + " | Messages: " + count.ToString();
        

    }

    private Label CreateLabel(string text)
    {
        Label labelFeeling = new Label();
        labelFeeling.Content = text;
        labelFeeling.FontSize = 20;
        labelFeeling.FontWeight = FontWeights.Bold;
        labelFeeling.Foreground = Brushes.DarkTurquoise;
        
        return labelFeeling;
    }
    
    
}
