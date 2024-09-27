using WPF_MVVM_TEMPLATE.Entitys;
using WPF_MVVM_TEMPLATE.InterfaceAdapter;

namespace WPF_MVVM_TEMPLATE.Infrastructure;

public class MemoryMessageRepos : IMessageRepos
{
    
    private Chat _chat;
    public MemoryMessageRepos(Chat chat)
    {
        _chat = chat;
    }

    public List<Message> GetAllMessages()
    {
        List<Message> messeges = new List<Message>();
        var messageList = _chat.Element.Elements("Message");
        foreach (var msg in messageList)
        {
            messeges.Add(new Message(msg, _chat.Feeling));
        }
        
        return messeges;
        
    }
}