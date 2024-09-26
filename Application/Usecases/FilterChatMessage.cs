using WPF_MVVM_TEMPLATE.Entitys;

namespace WPF_MVVM_TEMPLATE.Application.Usecases;

public class FilterChatMessage
{
    List<Message> foundMessages = new();

    public FilterChatMessage()
    {
        
    }
    
    // return list of message objects with the sentiment.
    public List<Message> Search(string searchText)
    {
        //Search in all MessageExchanges
        
        return foundMessages;
    }
}