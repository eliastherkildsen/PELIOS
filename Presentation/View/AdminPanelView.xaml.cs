using System.Windows.Controls;
using WPF_MVVM_TEMPLATE.Entitys;
using WPF_MVVM_TEMPLATE.Presentation.View.Components;

namespace WPF_MVVM_TEMPLATE.Presentation.View;

public partial class AdminPanelView : UserControl
{
    public AdminPanelView()
    {
        InitializeComponent();
        
        List<Message> messageList = new List<Message>()
        {
            new Message("Jeg elsker dig!", "", ""),
            new Message("Du elsker mig!", "", ""),
            new Message("Vi hader DAO!", "", ""),
            new Message("Du elsker fisk", "", ""),
            new Message("Vi hader DAO!", "", ""),
            new Message("Du elsker fisk!", "", ""),
        }; 

        ChatComp chatComp = new ChatComp(EFeelings.Angry, messageList ); 
        aaa.Children.Add(chatComp);
    }
    
    
}