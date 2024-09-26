using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Windows;
using WPF_MVVM_TEMPLATE.Application.Usecases;
using WPF_MVVM_TEMPLATE.Entitys;
using WPF_MVVM_TEMPLATE.Infrastructure;
using WPF_MVVM_TEMPLATE.InterfaceAdapter;
using WPF_MVVM_TEMPLATE.Presentation.View.Components;

namespace WPF_MVVM_TEMPLATE.Presentation.ViewModel;

public class AdminPanelViewModel : ViewModelBase
{
    private ObservableCollection<ChatComp> _chatComps;

    public ObservableCollection<ChatComp> ChatComps
    {
       get => _chatComps;
       set => _chatComps = value;
    }
    private List<Chat> _chats;
    private string _searchTerm;

    public AdminPanelViewModel()
    {
        _chats = LoadChats();
        _chatComps = new ObservableCollection<ChatComp>();
        foreach (var chat in _chats)
        {
           _chatComps.Add(new ChatComp(chat));
        }
        
        
    }
    
   private List<Chat> LoadChats()
    {
        IFileService fileService = new FileService(); 
        IChatRepos chatRepos = new XMLFileChatRepos(fileService);
        LoadChat loadChat = new LoadChat(chatRepos, "C:\\Users\\elias\\RiderProjects\\PELIOS\\Resources\\XML_DTD\\XMLFiles");
        return loadChat.GetAllChats(); 
    }
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
   
}