using System.Windows;
using System.Windows.Controls;
using WPF_MVVM_TEMPLATE.Application.Usecases;
using System.Windows.Input;
using WPF_MVVM_TEMPLATE.Entitys;
using WPF_MVVM_TEMPLATE.Infrastructure;
using WPF_MVVM_TEMPLATE.InterfaceAdapter;
using WPF_MVVM_TEMPLATE.Presentation.View.Components;
using WPF_MVVM_TEMPLATE.Presentation.ViewModel;

namespace WPF_MVVM_TEMPLATE.Presentation.View;

public partial class AdminPanelView : UserControl
{
    public AdminPanelView()
    {
        InitializeComponent();
        this.DataContext = new AdminPanelViewModel();
        
        List<Message> messageList = new List<Message>()
        {
            new Message("Tommy, I just realized... this conference might not be as fun as last year. It feels different this time.", "", ""),
            new Message("Tommy, I just realized... this conference might not be as fun as last year. It feels different this time.", "", ""),
            new Message("Tommy, I just realized... this conference might not be as fun as last year. It feels different this time.", "", ""),
            new Message("Tommy, I just realized... this conference might not be as fun as last year. It feels different this time.", "", ""),
            new Message("Tommy, I just realized... this conference might not be as fun as last year. It feels different this time.", "", ""),
            new Message("Tommy, I just realized... this conference might not be as fun as last year. It feels different this time.", "", ""),
        }; 

        ChatComp chatComp = new ChatComp(EFeelings.Angry, messageList ); 
        aaa.Children.Add(chatComp);
    }
}