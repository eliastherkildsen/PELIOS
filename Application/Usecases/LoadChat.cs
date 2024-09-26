using WPF_MVVM_TEMPLATE.Entitys;
using WPF_MVVM_TEMPLATE.InterfaceAdapter;

namespace WPF_MVVM_TEMPLATE.Application.Usecases;

public class LoadChat
{
    
    private readonly IChatRepos _repo;
    private readonly string _path;
    public LoadChat(IChatRepos repo, string path)
    {
        _repo = repo;
        _path = path;
    }

    public List<Chat> GetAllChats()
    {
        return _repo.GetAllChats(_path); 
    }

    public Chat GetChatById(int id)
    {
        return _repo.GetChat(id);
    }
    
}