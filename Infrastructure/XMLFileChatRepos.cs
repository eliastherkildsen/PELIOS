using System.Diagnostics;
using System.Xml.Linq;
using WPF_MVVM_TEMPLATE.Entitys;
using WPF_MVVM_TEMPLATE.InterfaceAdapter;

namespace WPF_MVVM_TEMPLATE.Infrastructure;

public class XMLFileChatRepos : IChatRepos
{
    private const string ValidFileExtension = "xml";
    private IFileService _fileService;
    public XMLFileChatRepos(IFileService fileService)
    {
        _fileService = fileService;
    }
    
    /// <summary>
    /// Method for loading all chats from a given dir. into memory as a chat obj. 
    /// </summary>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public List<Chat> GetAllChats(string path)
    {
        
        // validate that the dir is available
        if (!_fileService.IsDirectoryAvailable(path)) throw new Exception($"Directory {path} not found");
        
        // validate that the dir contains files 
        if (!_fileService.DirectoryContainsFiles(path)) throw new Exception($"Directory {path} does not contain any files");
        
        // fetch part to all files in dir
        var files = _fileService.GetFiles(path);

        // validate the file extention
        List<string> validfiles = ValidFileExtensions(files);
        
        // checking if any valid files was found.
        if (validfiles.Count == 0) throw new Exception($"Directory {path} does not contain any valid files");
        
        // list for storing chats. 
        List<Chat> chats = new List<Chat>();
        
        // creating a chat obj for each valid file. 
        foreach (var file in validfiles)
        {
            XElement xElement = XElement.Load(file);
            chats.Add(new Chat(xElement));

        }

        return chats; 
    }

    private List<string> ValidFileExtensions(List<string> files)
    {
        List<string> validfiles = new List<string>(); 
        foreach (var file in files)
        {
            if (_fileService.FileIsOfType(file, ValidFileExtension))
            {
                validfiles.Add(file);
                Debug.WriteLine($"[XMLFileChatRepos] added valid file to list. FILE:  {file}");
            }
            else
            {
                Debug.WriteLine($"[XMLFileChatRepos] file does not match the rule, and is therefor not valid. FILE:  {file}");
            }
            
        }
        
        return validfiles;
        
    }

    public Chat GetChat(int id)
    {
        throw new NotImplementedException();
    }
    
}