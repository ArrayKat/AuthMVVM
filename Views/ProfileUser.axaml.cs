using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using AvaloniaApplication1.Models;
using AvaloniaApplication1.ViewModels;

namespace AvaloniaApplication1;

public partial class ProfileUser : UserControl
{
    public ProfileUser(User user)
    {
        InitializeComponent();
        DataContext = new ProfileUserViewModel(user);
    }
}