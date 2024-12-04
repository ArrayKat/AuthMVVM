using AvaloniaApplication1.Models;
using Microsoft.EntityFrameworkCore;
using MsBox.Avalonia.Enums;
using MsBox.Avalonia;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace AvaloniaApplication1.ViewModels
{
    internal class AutorisationViewModel : ViewModelBase
    {
        string login;
        string password;

        public string Login { get => login; set => this.RaiseAndSetIfChanged(ref login, value); }
        public string Password { get => password; set => this.RaiseAndSetIfChanged(ref password, value); }

        public void ToBack() {
            MainWindowViewModel.Instance.PageContent = new Menu();
        }
        public async void Auth() { 
            byte[] hashPassword = MD5.HashData(Encoding.ASCII.GetBytes(password));
            User user = MainWindowViewModel.myConnection.Users.Include(x => x.IdRoleNavigation).FirstOrDefault(x => x.Login == login && x.Passvord == hashPassword);
            if (user != null) MainWindowViewModel.Instance.PageContent = new ProfileUser(user);
            else await MessageBoxManager.GetMessageBoxStandard("Ошибка", "Вы ввели не правильный логин или пароль.", ButtonEnum.Ok).ShowAsync();
        }
    }
}
