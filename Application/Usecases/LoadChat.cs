using WPF_MVVM_TEMPLATE.Entitys;
using WPF_MVVM_TEMPLATE.InterfaceAdapter;

namespace WPF_MVVM_TEMPLATE.Application.Usecases;

public class LoadChat
{


    private readonly IChatRepos _repo; 
    public LoadChat(IChatRepos repo)
    {
        _repo = repo;
    }

    public List<Chat> GetAllChats()
    {
        return _repo.GetAllChats(); 
    }

    public Chat GetChatById(int id)
    {
        return _repo.GetChat(id);
    }
    
}