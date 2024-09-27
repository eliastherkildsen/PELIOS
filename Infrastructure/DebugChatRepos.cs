using System.Xml.Linq;
using WPF_MVVM_TEMPLATE.Entitys;
using WPF_MVVM_TEMPLATE.InterfaceAdapter;

namespace WPF_MVVM_TEMPLATE.Infrastructure;

public class DebugChatRepos : IChatRepos
{
    public List<Chat> GetAllChats(string path)
    {
        throw new NotImplementedException();
    }

    public Chat GetChat(int id)
    {

        XElement messageExchange = new XElement("MessageExchange",
            new XAttribute("sentiment", "Angry"),
            new XElement("Message",
                new XElement("User", "Frank"),
                new XElement("Text", "You’ve got to be kidding me, Tommy! We’re sharing a room again? I thought we agreed on separate rooms this time!")
            ),
            new XElement("Message",
                new XElement("User", "Tommy"),
                new XElement("Text", "Hey, don’t look at me! I thought you were fine with it. Why didn’t you say anything earlier?")
            ),
            new XElement("Message",
                new XElement("User", "Frank"),
                new XElement("Text", "Because I didn’t think we’d have this problem again! I wanted some space this year. This is ridiculous!")
            ),
            new XElement("Message",
                new XElement("User", "Tommy"),
                new XElement("Text", "Well, it’s too late now! We’re stuck with it. What do you want me to do about it?")
            ),
            new XElement("Message",
                new XElement("User", "Frank"),
                new XElement("Text", "I don’t know, but this just ruins the whole trip for me. Even the beer doesn’t sound fun anymore.")
            ),
            new XElement("Message",
                new XElement("User", "Tommy"),
                new XElement("Text", "Oh, come on! Don’t tell me you’re going to sulk the entire time just because we’re sharing a room. Grow up, Frank!")
            ),
            new XElement("Message",
                new XElement("User", "Frank"),
                new XElement("Text", "This isn’t about \"sulking.\" I wanted a break, some space, and now it’s just a mess. I’m not looking forward to this at all anymore.")
            ),
            new XElement("Message",
                new XElement("User", "Tommy"),
                new XElement("Text", "Fine! Let’s just get through the conference, have a couple of beers, and try to survive sharing the room, okay?")
            )
        );

        
        return new Chat(messageExchange, EFeelings.Angry); 

    }
    
}