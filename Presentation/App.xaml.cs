using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Windows;
using WPF_MVVM_TEMPLATE.Presentation.ViewModel;

namespace WPF_MVVM_TEMPLATE.Presentation;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application, INotifyPropertyChanged
{

    private ViewModelBase? _currentViewModel;
    public ViewModelBase? CurrentViewModel
    { 
        get => _currentViewModel; 
        set => SetField(ref _currentViewModel, value); 
    }
    
    private readonly List<KeyValuePair<Type, ViewModelBase>> _viewModels = new List<KeyValuePair<Type, ViewModelBase>>();

    
    
    /// <summary>
    /// Method for registering a view model
    /// </summary>
    /// <param name="viewModel"> viewmodel to register</param>
    /// <exception cref="Exception"> throw an Exception if the viewModel has already been registered</exception>
    public void RegistryViewModel(ViewModelBase viewModel)
    {
        
        _viewModels.Add(new KeyValuePair<Type, ViewModelBase>(viewModel.GetType(), viewModel));
        Debug.WriteLine($"AddViewModel: {viewModel.GetType().Name}");

        
    }
    public void LoadViewModel(Type type)
    {
        //Debug.WriteLine("Loading ViewModel");
        
        foreach (var viewModel in _viewModels)
        {
            if (viewModel.Key == type)
            {
                CurrentViewModel = viewModel.Value;
                return;
                //Debug.WriteLine($"Loaded ViewModel: {viewModel.Key} - {viewModel.Value} ");
            }    
        }
        
    }

    public List<KeyValuePair<Type, ViewModelBase>> GetViewModels()
    {
        return _viewModels;
    } 

    public event PropertyChangedEventHandler? PropertyChanged;

    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    protected bool SetField<T>(ref T field, T value, [CallerMemberName] string? propertyName = null)
    {
        if (EqualityComparer<T>.Default.Equals(field, value)) return false;
        field = value;
        OnPropertyChanged(propertyName);
        return true;
    }
}