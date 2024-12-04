using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using AvaloniaApplication1.ViewModels;

namespace AvaloniaApplication1;

public partial class Menu : UserControl
{
    public Menu()
    {
        InitializeComponent();
        DataContext = new MenuViewModel();
    }
}