using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;
using System.Xml.Linq;
using WPF_MVVM_TEMPLATE.Entitys;
using WPF_MVVM_TEMPLATE.Presentation.ViewModel;

namespace WPF_MVVM_TEMPLATE.Presentation.View.Components;

public class MessageComp : StackPanel
{
    
    private Label _title;
    private TextBlock _messageBlock;
    private Button _deleteButton;
    private readonly string _messageText;
    private Message _message;
    private readonly string _messageSender; 
    
    public MessageComp(Message message)
    {
        _message = message;
        _messageText = GetMessageFromElemet(_message.Element); 
        _messageSender = GetSenderFromElemet(_message.Element);
        CreateUi();
        
    }

    private void CreateUi()
    {
        
        // Create a new Grid with two rows and two columns
        Grid grid = new Grid
        {
            //MaxWidth = 800, // Set a max width to prevent the message from being too wide
            Width = double.NaN // Allow it to expand to fit the content
        };
        
        
        // Define rows for the title and message+button
        grid.RowDefinitions.Add(new RowDefinition()); // Row for Title
        grid.RowDefinitions.Add(new RowDefinition()); // Row for Message and Button

        // Define columns for message and button in the second row
        grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) }); // Message gets most space
        grid.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Auto }); // Button gets as much space as needed

        // Create UI elements
        _title = CreateLabel(_messageSender);
        _messageBlock = CreateTextBlock(_messageText);
        _deleteButton = CreateButton("Delete");
        
        // Place elements in the Grid
        Grid.SetRow(_title, 0);  // Title in the first row
        Grid.SetRow(_messageBlock, 1); // Message in the second row, first column
        Grid.SetColumn(_messageBlock, 0);

        Grid.SetRow(_deleteButton, 1); // Button in the second row, second column
        Grid.SetColumn(_deleteButton, 1);

        // Add elements to Grid
        grid.Children.Add(_title);
        grid.Children.Add(_messageBlock);
        grid.Children.Add(_deleteButton);
        
        Border border = new Border
        {
            BorderBrush = Brushes.Black, // Set border color
            BorderThickness = new Thickness(2), // Set border thickness
            CornerRadius = new CornerRadius(5), // Optional: Set rounded corners
            Padding = new Thickness(10), // Add some padding inside the border
            Margin = new Thickness(5),
            Background = (Brush)new BrushConverter().ConvertFromString("#415A77")!,
            Child = grid // Set the grid as the content of the border
        };

        // Add the grid to the StackPanel
        Children.Add(border);
    }

    private string GetMessageFromElemet(XElement element)
    {
        var message = from e in element.Descendants("Text") select e;

        if (!message.Any()) throw new NullReferenceException("The message is empty");
        return message.First().Value;
    }    
    
    private string GetSenderFromElemet(XElement element)
    {
        var message = from e in element.Descendants("User") select e;

        if (!message.Any()) throw new NullReferenceException("The message is empty");
        return message.First().Value;
    }
    
    private TextBlock CreateTextBlock(string message)
        {
            TextBlock textBlock = new TextBlock
            {
                Text = message,
                TextWrapping = TextWrapping.Wrap,
                Foreground = new SolidColorBrush(Colors.Wheat),
                //MaxWidth = 200,
                //HorizontalAlignment = HorizontalAlignment.Left,
            };
            return textBlock;
        }

    private Label CreateLabel(string content)
        {
            var label = new Label
            {
                Content = content,
                HorizontalAlignment = HorizontalAlignment.Left, // Align to the left
                FontWeight = FontWeights.Bold, // Optional: Make the title bold
                Foreground = new SolidColorBrush(Colors.GreenYellow) // E0E1DD color in RGB
            };
            return label;
        }

    private Button CreateButton(string content)
    {
        var button = new Button
        {
            Width = 100,
            Height = 25,
            Content = content,
            HorizontalAlignment = HorizontalAlignment.Right
        };

        // Bind the DeleteMessageCommand from the ViewModel (inherited DataContext)
        var binding = new Binding("DeleteMessageCommand")
        {
            Mode = BindingMode.OneWay
        };
        button.SetBinding(Button.CommandProperty, binding);

        // Pass the Message object as a CommandParameter
        button.CommandParameter = _message;

        return button;
    }
    
}