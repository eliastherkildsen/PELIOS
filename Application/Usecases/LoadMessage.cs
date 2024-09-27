using WPF_MVVM_TEMPLATE.Entitys;
using WPF_MVVM_TEMPLATE.InterfaceAdapter;

namespace WPF_MVVM_TEMPLATE.Application.Usecases;

public class LoadMessage
{
    private IMessageRepos _messageRepos;
    public LoadMessage(IMessageRepos messageRepos)
    {
        _messageRepos = messageRepos;
        
    }

    public List<Message> LoadAllMessages()
    {
        return _messageRepos.GetAllMessages();
    }
}