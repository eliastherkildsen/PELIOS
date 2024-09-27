
using System.Security.RightsManagement;
using System.Windows;
using System.Windows.Documents;
using WPF_MVVM_TEMPLATE.Entitys;
using WPF_MVVM_TEMPLATE.Presentation.View;

namespace WPF_MVVM_TEMPLATE.Application.Usecases;

public class SearchChat
{
    Dictionary<EFeelings, int> sentiments = new Dictionary<EFeelings, int>()
    {
        {EFeelings.Angry, 0},
        {EFeelings.Happy, 0},
        {EFeelings.Sad, 0},
        {EFeelings.Annoyed, 0},
        {EFeelings.Excited, 0},
        {EFeelings.Hopeful, 0},
        {EFeelings.Confused, 0}
    };
    
    private List<Message> _messages;
    public SearchChat(List<Message> messages)
    {
        _messages = messages;
    }
    
    /// <summary>
    /// For getting in what sentiment a word is most commonly used 
    /// </summary>
    /// <returns>string, with what sentiment and how many occurrences</returns>
    public string SentimentCount()
    {
        foreach (var message in _messages)
        {
            sentiments[message.Feelings]++;
        }
        
        int tempCount = 0;
        string tempFeel = String.Empty;
        foreach (var sentiment in sentiments)
        {
            if (sentiment.Value > tempCount)
            {
                tempCount = sentiment.Value;
                tempFeel = sentiment.Key.ToString();
            }
        }
        string result = $"{tempFeel}: {tempCount}";
        
        return result;
    }

}