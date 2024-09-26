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
    private int _selectedChatIndex;
    private int _selectedMessageIndex;
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
    
    
    public void DeleteMessage()
    {
       RemoveChatMessage removeChatMessage = new RemoveChatMessage();
       Chat selectedChat = _chats[_selectedChatIndex];
        
       Chat modifiedChat = removeChatMessage.RemoveMessage(selectedChat, _selectedMessageIndex);
       AddModification(modifiedChat);

    }

    private void AddModification(Chat modifiedChat)
    {
       _chats[_selectedChatIndex] = modifiedChat;
    }
    
}