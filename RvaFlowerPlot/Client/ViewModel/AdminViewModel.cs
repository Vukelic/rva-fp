using Client.Commands;
using Client.View;
using Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Client.ViewModel
{
    class AdminViewModel
    {
        private Window adminWindow;
        public AdminViewModel(Window adminWindow)
        {
            this.adminWindow = adminWindow;

            AddUserCommand = new MyICommand(Add);
            EditUserCommand = new MyICommand(Edit, CanEdit);
            DeleteUserCommand = new MyICommand(Delete, CanDelete);
            ExitCommand = new MyICommand(Exit);

            MyUsers = new BindingList<User>(UserProxy.Instance.Proxy.GetAllUsers());
        }
        public BindingList<User> MyUsers { get; set; }
        public User SelectedUser { get; set; }
        public ICommand AddUserCommand { get; set; }
        public ICommand EditUserCommand { get; set; }
        public ICommand DeleteUserCommand { get; set; }
        public ICommand ExitCommand { get; set; }
        public void Add()
        {
            User user = new User();
            Window addEditWindow = new AddEditWindow();
            addEditWindow.DataContext = new AddEditViewModel(user, addEditWindow, true, MyUsers, true);
            addEditWindow.ShowDialog();
        }

        public bool CanEdit()
        {
            return SelectedUser != null;
        }

        public void Edit()
        {
           Window addEditWindow = new AddEditWindow();
           addEditWindow.DataContext = new AddEditViewModel(SelectedUser, addEditWindow, false, MyUsers,true);
           addEditWindow.ShowDialog();
        }

        public bool CanDelete()
        {
            return SelectedUser != null;
        }

        public void Delete()
        {
            UserProxy.Instance.Proxy.DeleteUser(SelectedUser.Username);

            MyUsers.Remove(SelectedUser);

            LoggerTable.AddLog("Korisnik obrisao korisnika.", TypeEventLog.INFO, DateTime.Now);
        }

        public void Exit()
        {
            adminWindow.Close();
        }    
    }
}
