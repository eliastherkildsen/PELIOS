using WPF_MVVM_TEMPLATE.Entitys;

namespace WPF_MVVM_TEMPLATE.InterfaceAdapter;

public interface IChatRepos
{
    List<Chat> GetAllChats(string path); 
    Chat GetChat(int id);
}