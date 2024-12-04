using Avalonia.Controls;
using AvaloniaApplication1.Models;
using ReactiveUI;

namespace AvaloniaApplication1.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        public static _43pKolinichenko2Context myConnection = new _43pKolinichenko2Context();
        public static MainWindowViewModel Instance;
        public MainWindowViewModel() { 
            Instance = this;
        }

        UserControl _pageContent = new Menu();
        public UserControl PageContent { get => _pageContent; set => this.RaiseAndSetIfChanged( ref _pageContent,  value); }
    }
}
