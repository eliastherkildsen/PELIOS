using System.Diagnostics;
using System.Windows.Controls;
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
        //_messages = messages;
        
        CrateChatComp(_chatEFeeling);
        
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
    
    private void CrateChatComp(EFeelings chatEFeeling)
    {
        
        Label labelFeeling = new Label();
        labelFeeling.Content = chatEFeeling.ToString();
        Children.Add(labelFeeling);

    }
    
    
}
