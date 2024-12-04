using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Platform.Storage;
using AvaloniaApplication1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvaloniaApplication1.ViewModels
{
    internal class ProfileUserViewModel : ViewModelBase
    {
        User _currentUser;
        
        public User CurrentUser { get => _currentUser; set => _currentUser = value; }
        public ProfileUserViewModel(User user) {
            CurrentUser = user;
            
        }
        public void ToPageBack() {
            MainWindowViewModel.Instance.PageContent = new Menu();
        }
        public async Task AddPhoto() {
            if (Application.Current?.ApplicationLifetime is not IClassicDesktopStyleApplicationLifetime desctop || desctop.MainWindow?.StorageProvider is not { } provider) throw new NullReferenceException("провайдер отсутствует");

            var file = await provider.OpenFilePickerAsync(
                new FilePickerOpenOptions()
                {
                    Title = "Выберите изображение",
                    AllowMultiple = false,
                    FileTypeFilter = [FilePickerFileTypes.All, FilePickerFileTypes.ImageAll]
                }
                );
            if (file != null)
            {
                await using var readStream = await file[0].OpenReadAsync();
                byte[] buffer = new byte[readStream.Length];
                readStream.ReadAtLeast(buffer, 1);
                CurrentUser.Image = buffer;

                MainWindowViewModel.myConnection.SaveChanges();
                MainWindowViewModel.Instance.PageContent = new ProfileUser(_currentUser);
            }
        }
    }
}
