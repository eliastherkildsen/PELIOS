using System.Diagnostics;
using System.Net.Mime;
using System.Windows;
using System.Xml.Linq;
using WPF_MVVM_TEMPLATE.Entitys;
using WPF_MVVM_TEMPLATE.Presentation.View.Components;

namespace WPF_MVVM_TEMPLATE.Application.Usecases;

public class FilterChatMessage
{
    
    private List<Chat> chatList = new();
    public FilterChatMessage(List<Chat> chat)
    {
        chatList = chat;
    }
    
    /// <summary>
    /// Takes in a search word and looks through all chats and gets the messages
    /// that contains the given word
    /// Returns a list with all the messages
    /// </summary>
    /// <param name="searchText"></param>
    /// <returns></returns>
    public List<Message> Search(string searchText)
    {
        
        List<Message> foundMessages = new();
        
        foreach (Chat chat in chatList)
        {
            // String for getting the sentiment of a chat
            string sentiment = chat.Element.Attribute("sentiment")?.Value;
            var messageList = chat.Element.Elements("Message")
                .Select(m => new
                {
                    User = m.Element("User")?.Value,
                    Text = m.Element("Text")?.Value
                })
                .ToList();
            
            foreach (var message in messageList)
            {
                
                var text = message.Element("Text");
                
                if (text.Value.Contains(searchText))
                {
                    
                    Debug.WriteLine($"I should add this: " + message);
                    // Adds the message containing the search word to a list
                    foundMessages.Add(new Message(message));
                }
            }
        }

        return foundMessages;
    }
} 