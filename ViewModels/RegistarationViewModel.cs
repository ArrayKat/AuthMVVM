using AvaloniaApplication1.Models;
using MsBox.Avalonia;
using MsBox.Avalonia.Enums;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AvaloniaApplication1.ViewModels
{
    internal class RegistarationViewModel : ViewModelBase
    {
        User _newUser = new User();
        string _password;
        bool isTrueData = false;
        public User NewUser { get => _newUser; set =>  this.RaiseAndSetIfChanged( ref _newUser, value); }
        public string Password { get => _password; set => this.RaiseAndSetIfChanged(ref _password, value); }

        public RegistarationViewModel(int idRole) {
            NewUser.IdRole = idRole;
        }

        public void ToBack() {
            MainWindowViewModel.Instance.PageContent = new Menu();
        }
        public async void SaveChange() {
            CheckData();
            if (isTrueData) { 
                NewUser.Passvord = MD5.HashData(Encoding.ASCII.GetBytes(_password));
                MainWindowViewModel.myConnection.Users.Add(NewUser);
                MainWindowViewModel.myConnection.SaveChanges();
                MainWindowViewModel.Instance.PageContent = new Menu();
            }
        }
        public async void CheckPassword() {

            string errorMessage = "Пароль не удовлетворяет требованиям: \n";
            int upperCase = Regex.Matches(_password, "[A-Z]").Count();
            if (upperCase >= 2)
            {
                int lowerCase = Regex.Matches(_password, "[a-z]").Count();
                if (lowerCase >= 3)
                {
                    int digits = Regex.Matches(_password, "\\d").Count();
                    if (digits >= 2)
                    {
                        bool lengthOk = _password.Length >= 8;
                        if (lengthOk) {
                            bool startsWithDigit = Regex.IsMatch(_password, @"^\d");
                            if (!startsWithDigit)
                            {
                                await MessageBoxManager.GetMessageBoxStandard("Сообщение", "Вы успешно зарегестировались!", ButtonEnum.Ok).ShowAsync();
                                isTrueData = true;
                            }
                            else { isTrueData = false; errorMessage += "- пароль не должен начинаться с цифры\n"; }
                        }
                        else { isTrueData = false; errorMessage += "- длина пароля должна быть не менее 8 символов\n"; }
                    }
                    else { isTrueData = false; errorMessage += "- не менее 2 цифр\n"; }
                }
                else { isTrueData = false; errorMessage += "- не менее 3 строчных латинских символов\n"; }
            }
            else { isTrueData = false; errorMessage += "- не менее 2 заглавных латинских символов\n"; }
            if (!isTrueData) await MessageBoxManager.GetMessageBoxStandard("Ошибка", errorMessage, ButtonEnum.Ok).ShowAsync();
        }
        public async void CheckData() {
            string errorMessage = "Вы не заполнили следующие обязательные поля:\n";
            isTrueData = true;
            if (string.IsNullOrEmpty(NewUser.Surname)) { errorMessage += "- фамилию\n"; isTrueData = false; }
            if (string.IsNullOrEmpty(NewUser.Name)) { errorMessage += "- имя\n"; isTrueData = false; }
            if (string.IsNullOrEmpty(NewUser.Patronymic)){ errorMessage += "- отчество\n"; isTrueData = false; }
            if (string.IsNullOrEmpty(NewUser.Login)){ errorMessage += "- логин\n"; isTrueData = false; }
            if (string.IsNullOrEmpty(Password)){ errorMessage += "- пароль\n"; isTrueData = false; }

            if (!isTrueData) await MessageBoxManager.GetMessageBoxStandard("Ошибка", errorMessage, ButtonEnum.Ok).ShowAsync();
            List<User> users = MainWindowViewModel.myConnection.Users.ToList();
            User user = users.FirstOrDefault(x => x.Login == NewUser.Login);
            if (user != null) { isTrueData = false; await MessageBoxManager.GetMessageBoxStandard("Ошибка", "Пользователь с данным логином уже существует", ButtonEnum.Ok).ShowAsync(); }
            if (isTrueData) CheckPassword();
            
        }
    }
}
