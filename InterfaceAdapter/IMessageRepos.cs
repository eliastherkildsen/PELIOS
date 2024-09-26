using System.Windows.Documents;
using WPF_MVVM_TEMPLATE.Entitys;

namespace WPF_MVVM_TEMPLATE.InterfaceAdapter;

public interface IMessageRepos
{
    List<Message> GetAllMessages();
}