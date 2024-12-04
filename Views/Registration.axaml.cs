using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using AvaloniaApplication1.ViewModels;

namespace AvaloniaApplication1;

public partial class Registration : UserControl
{
    public Registration(int idRole)
    {
        InitializeComponent();
        DataContext = new RegistarationViewModel(idRole);
    }
}