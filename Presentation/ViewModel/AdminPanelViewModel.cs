using System.Diagnostics;
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
    
    private List<Chat> _chats;
    private int _selectedChatIndex;
    private int _selectedMessageIndex;
    
    
    public AdminPanelViewModel()
    {
        _chats = LoadChats();
            
    }
    
    private List<Chat> LoadChats()
    {
        IFileService fileService = new FileService(); 
        IChatRepos chatRepos = new XMLFileChatRepos(fileService);
        LoadChat loadChat = new LoadChat(chatRepos, "C:\\Users\\elias\\RiderProjects\\PELIOS\\Resources");
        return loadChat.GetAllChats(); 
    }
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