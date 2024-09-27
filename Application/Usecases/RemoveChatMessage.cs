﻿using System.Diagnostics;
using WPF_MVVM_TEMPLATE.Entitys;
using WPF_MVVM_TEMPLATE.InterfaceAdapter;

namespace WPF_MVVM_TEMPLATE.Application.Usecases;


public class RemoveChatMessage
{
    /// <summary>
    /// This method removes a message from a chat
    /// </summary>
    /// <param name="chats"> the list of chat objects </param>
    /// <param name="message"> the message to be removed </param>
    /// <returns> a list of chats incl. the modified chat object without the message to be removed </returns>
    public List<Chat> RemoveMessage(List<Chat> chats, Message message)
    {
        List<Chat> tempChats = chats;
        bool found = false;
        
        if (message != null)
        {

            for (int i = 0; i < tempChats.Count; i++)
            {

                for (int j = 0; j < tempChats[i].Messages.Count; j++)
                {

                    if (tempChats[i].Messages[j].GetHashCode() == message.GetHashCode())
                    {
                        tempChats[i].Messages.RemoveAt(j);
                    }
                    
                }
            }
        }
        
        return tempChats;
    }
}