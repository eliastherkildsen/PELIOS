using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using WPF_MVVM_TEMPLATE.Application.Usecases;
using WPF_MVVM_TEMPLATE.Entitys;
using WPF_MVVM_TEMPLATE.Infrastructure;
using WPF_MVVM_TEMPLATE.InterfaceAdapter;
using WPF_MVVM_TEMPLATE.Presentation.View.Components;

namespace WPF_MVVM_TEMPLATE.Presentation.ViewModel;

public class AdminPanelViewModel : ViewModelBase
{
   
   // path to the "XMLFiles" folder where the XML files are stored
   private readonly string _directoryPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\Resources\XML_DTD\XMLFiles");

   
   private ObservableCollection<StackPanel> _UIComps = new ObservableCollection<StackPanel>();
   
   public ObservableCollection<StackPanel> UiComps
   {
      get => _UIComps;
      set
      {
         _UIComps = value;
         OnPropertyChanged();
      }
   }

   private List<Chat> _chats;

   public List<Chat> Chats
   {
      get => _chats;
      set
      {
         _chats = value;
      }
   }
   
   private List<Message> _messages;

    private string _searchTerm;
    public string SearchTerm
    {
       get => _searchTerm;
       set
       {
          //Check if its one word without spaces.
          if (WordService.CheckOneWord(value))
          {
             _searchTerm = value;
             OnPropertyChanged(nameof(SearchTerm));
             Debug.WriteLine($"SearchTerm: {_searchTerm}");
             
             UiComps.Clear();
             FilterChatMessage filterChatMessage = new FilterChatMessage(_chats);
            _messages = filterChatMessage.Search(_searchTerm);
             foreach (var msg in _messages)
             {
               UiComps.Add(new MessageComp(msg));
             }
             
             SearchChat searchChat = new SearchChat(_messages);
             SentimentCount = searchChat.SentimentCount();

          }
          else
          {
             string message = $"Incorrect Search Term: {value}\n" +
                              "Please enter one word without numbers or symbols."; 

             // Display the message box
             MessageBox.Show(message, "Search Failed", MessageBoxButton.OK, MessageBoxImage.Information);
          }
       }
    }
    
    private string _sentimentCount;
    public string SentimentCount
    {
       get => _sentimentCount;
       set
       {
          _sentimentCount = value;
          OnPropertyChanged();
       }
    }

    public AdminPanelViewModel()
    {
        _chats = LoadChats();
    }
    
    private List<Chat> LoadChats()
    {
        IFileService fileService = new FileService(); 
        IChatRepos chatRepos = new XMLFileChatRepos(fileService);
        LoadChat loadChat = new LoadChat(chatRepos, _directoryPath);
        return loadChat.GetAllChats(); 
    }

    private ObservableCollection<StackPanel> DisplayChatDebug()
    {
       ObservableCollection<StackPanel> chatComps = new ObservableCollection<StackPanel>();
       foreach (var chat in Chats)
       {
          chatComps.Add(new ChatComp(chat));
       }

       return chatComps;
    }

    
    private ObservableCollection<StackPanel> DisplayChats(List<Chat> chats)
    {
       ObservableCollection<StackPanel> chatComps = new ObservableCollection<StackPanel>();
       
       foreach (var chat in chats)
       {

          IMessageRepos MessageRepos = new MemoryMessageRepos(chat); 
          LoadMessage loadMessage =    new LoadMessage(MessageRepos);
          List<Message> chatMessages = loadMessage.LoadAllMessages();
          
          chat.Messages = new List<Message>();
          foreach (var message in chatMessages)
          {
             chat.Messages.Add(message);
               
          }
            
          chatComps.Add(new ChatComp(chat));
       }

       return chatComps; 
    }
   
    
    public ICommand CommandDisplayAll => new CommandBase((Object commandPara) =>
    {
       {
          UiComps = DisplayChats(_chats);
       }
    });
    
    
    public ICommand CommandDisplayMemo => new CommandBase((Object commandPara) =>
    {
       {

          if (UiComps.Count <= 0 || UiComps == null)
          {
             UiComps = DisplayChats(Chats);
          }
          else
          {
             UiComps = DisplayChatDebug();  
          }
       }
    });
    
    
    public ICommand DeleteMessageCommand => new CommandBase((Object commandPara) =>
    {
       {
          
          RemoveChatMessage removeChatMessage = new RemoveChatMessage();
          
          Message msgToDelete = commandPara as Message;
          
          if (msgToDelete == null) Debug.WriteLine("Message is null");
          
          Chats = removeChatMessage.RemoveMessage(Chats, msgToDelete);
          
          UiComps = DisplayChatDebug();  
          
       }
    });   
    
}