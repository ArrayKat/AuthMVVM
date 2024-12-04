using AvaloniaApplication1.Models;
using Microsoft.EntityFrameworkCore;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvaloniaApplication1.ViewModels
{
    internal class MenuViewModel : ViewModelBase
    {
        bool isVisibleRegAuth;

        public bool IsVisibleRegAuth { get => isVisibleRegAuth; set => this.RaiseAndSetIfChanged( ref isVisibleRegAuth, value); }
        int idRole = 0;

        public MenuViewModel() {
            isVisibleBtnRegAdm();
        }

        public void isVisibleBtnRegAdm() { 
            List<User>? users = MainWindowViewModel.myConnection.Users.Include(x => x.IdRoleNavigation).ToList();
            idRole = MainWindowViewModel.myConnection.RoleUsers.FirstOrDefault(x => x.NameRole == "Администратор").Id;
            User admin = users.FirstOrDefault(x => x.IdRole == idRole);
            //если пользователей ни одного нет
            IsVisibleRegAuth = users.Count()!=0 ? true : false;
              
        }
        public void registration() {
            //перекидываем на страницу регистрации:
            //в Registration передаем idRole
            MainWindowViewModel.Instance.PageContent = !IsVisibleRegAuth ? new Registration(1) : new Registration(2);
        }
        public void autorisation() {
            MainWindowViewModel.Instance.PageContent = new Autorisation();
        }
    }
}
