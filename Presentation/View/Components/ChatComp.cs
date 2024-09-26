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
        _chatEFeeling = GetChatFeeling(chat);
        _messages = GetMesseges(chat);
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

    private List<Message> GetMesseges(Chat chat)
    {
        List<Message> messeges = new List<Message>();
        var messageList = chat.Element.Elements("Message");
        foreach (var msg in messageList)
        {
            messeges.Add(new Message(msg));
        }
        
        return messeges;
        
    }

    private EFeelings GetChatFeeling(Chat chat)
    {
        
       var result = chat.Element.Attribute("sentiment");
       // checking if feeling is not set. 
       if (result == null) throw new NullReferenceException("sentement is null");
       string feeling = result.Value.ToLower();
       
       Debug.WriteLine(feeling);

       if (feeling == "angry") return EFeelings.Angry; 
       if (feeling == "happy") return EFeelings.Happy;
       if (feeling == "sad") return EFeelings.Sad;
       if (feeling == "confused") return EFeelings.Confused;
       if (feeling == "annoyed") return EFeelings.Annoyed;
       if (feeling == "hopeful") return EFeelings.Hopefull;
       if (feeling == "excited") return EFeelings.Excited;
       
       throw new NullReferenceException("feeling is null or not a valid feeling");
       
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
