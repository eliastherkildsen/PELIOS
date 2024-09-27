using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Security.RightsManagement;
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
                //Debug.WriteLine(msg.Text);
               UiComps.Add(new MessageComp(msg));
             }
               
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
    
    private int _sentimentCount;
    public int SentimentCount
    {
       get => _sentimentCount;
       set
       {

          Dictionary<EFeelings, int> sentimentCount = new Dictionary<EFeelings, int>();
          sentimentCount.Add(EFeelings.Angry, 0);
          sentimentCount.Add(EFeelings.Happy, 0);
          sentimentCount.Add(EFeelings.Sad, 0);
          sentimentCount.Add(EFeelings.Annoyed, 0);
          sentimentCount.Add(EFeelings.Excited, 0);
          sentimentCount.Add(EFeelings.Hopeful, 0);
          sentimentCount.Add(EFeelings.Confused, 0);
          
          foreach (var message in _messages)
          {
             sentimentCount[message.Feelings]++;
          }

          string tempFeel = "";
          int tempCount = 0;
          foreach (var sentiment in sentimentCount)
          {
             
          }
          
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
        LoadChat loadChat = new LoadChat(chatRepos, "C:\\Users\\AlexG\\RiderProjects\\PELIOS\\Resources\\XML_DTD\\XMLFiles");
        return loadChat.GetAllChats(); 
    }

    private ObservableCollection<StackPanel> DisplayChats(List<Chat> chats)
    {
       ObservableCollection<StackPanel> chatComps = new ObservableCollection<StackPanel>();
       foreach (var chat in _chats)
       {
          chatComps.Add(new ChatComp(chat));
       }

       return chatComps; 

    }
   
    public ICommand CommandDisplayAll => new CommandBase((Object commandPara) =>
    {
       {
          UiComps = DisplayChats(_chats);
          Debug.WriteLine("Displaing all chats");
       }
    });
    
}