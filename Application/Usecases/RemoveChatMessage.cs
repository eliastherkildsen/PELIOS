using System.Diagnostics;
using WPF_MVVM_TEMPLATE.Entitys;
using WPF_MVVM_TEMPLATE.InterfaceAdapter;

namespace WPF_MVVM_TEMPLATE.Application.Usecases;


public class RemoveChatMessage 
{
    
    /// <summary>
    /// This method removes a message from a chat at a specified index
    /// </summary>
    /// <param name="selectedChat"> the chat object from which the message will be removed </param>
    /// <param name="messageIndex"> the index of the message wanted to be removed in the message list </param>
    /// <returns> returns the modified chat object after the message is removed </returns>
    /// <exception cref="ArgumentNullException"></exception>
    /// <exception cref="ArgumentOutOfRangeException"></exception>
    public Chat RemoveMessage(Chat selectedChat, int messageIndex)
    {
        if (selectedChat == null)
        {
            throw new ArgumentNullException($"Selected chat {nameof(selectedChat)} is null");
        }

        
        // loads all child elements from XElement and saves them in a list
        var messages = selectedChat.GetElement().Elements().ToList();
        Debug.WriteLine(messages);
        
        
        // checks if message index is out of bounds
        if (messageIndex < 0 || messageIndex >= messages.Count)
        {
            throw new ArgumentOutOfRangeException($"Message index: {nameof(messageIndex)} is out of bounds.");
        }
        
        
        // removes message element at given index
        messages.ElementAt(messageIndex).Remove();
        
        
        return selectedChat;
    }
    
    

}