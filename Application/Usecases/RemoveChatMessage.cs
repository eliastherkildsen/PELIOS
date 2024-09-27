﻿using System.Diagnostics;
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
    public List<Chat> RemoveMessage(List<Chat> chats, Message message)
    {
        List<Chat> removeChats = chats;
        bool found = false;
        if (message != null)
        {
            Debug.WriteLine($"{message.Feelings}");



            for (int i = 0; i < removeChats.Count; i++)
            {

                for (int j = 0; j < removeChats[i].Messages.Count; j++)
                {

                    if (removeChats[i].Messages[j].GetHashCode() == message.GetHashCode())
                    {
                        Debug.WriteLine($"Before del {removeChats[i].Messages.Count}");
                        removeChats[i].Messages.RemoveAt(j);
                        Debug.WriteLine($"After del {removeChats[i].Messages.Count}");
                        
                    }
                    
                    Debug.WriteLine($"Before del {removeChats[i].Feeling} :::: {removeChats[i].Messages.Count}");

                }

            }


        }
        
        foreach (var chat in removeChats)
        {
            Debug.WriteLine("IN REMOVECHAT" + chat.Feeling + ", ->> " + chat.Messages.Count.ToString());
        }
        
        return removeChats;

    }


/*
foreach (var chat in removeChats)
{
    foreach (var chatMessage in chat.Messages)
    {

        if (message.GetHashCode() == chatMessage.GetHashCode())
        {




            Debug.WriteLine($"Message count before: {chat.Messages.Count}");
            chat.Messages.Remove(chatMessage);
            Debug.WriteLine($"Message count after: {chat.Messages.Count}");
            Debug.WriteLine("message removed");
            break;
        }
    }
}

}
    return chats;

*/
        

        
    
    

}