using WPF_MVVM_TEMPLATE.Entitys;

namespace WPF_MVVM_TEMPLATE.InterfaceAdapter;

public interface IChatRepos
{
    List<Chat> GetAllChats(); 
    Chat GetChat(int id);
    
}