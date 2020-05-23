using Client.Commands;
using Client.View;
using Common;
using log4net;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Common;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Client.ViewModel
{
    class LoginViewModel : INotifyPropertyChanged
    {
        private string username;
        private string password;
        private User user;
        private LoginWindow loginWindow;     
        public LoginViewModel(LoginWindow loginWindow)
        {
            this.loginWindow = loginWindow;
            LoginCommand = new MyICommand(Login, CanLogin);
            ExitCommand = new MyICommand(Exit);
        }
        public ICommand LoginCommand { get; set; }
        public ICommand ExitCommand { get; set; }
        public string Username
        {
            get => username;
            set { username = value; OnPropertyChanged("Username"); }
        }
        public string Password
        {
            get => password;
            set { password = value; OnPropertyChanged("Password"); }
        }

        public bool CanLogin()
        {
            return !string.IsNullOrEmpty(Username) && loginWindow.PasswordBox1.Password.Length>0;
        }

        public void Login()
        {
            Password = loginWindow.PasswordBox1.Password.ToString();

            try
            {
                if (!UserProxy.Instance.Proxy.Authenticate(Username, loginWindow.PasswordBox1.Password))
                {
                    MessageBox.Show(loginWindow, "Username/Password not found.");
                    Username = string.Empty;
                    loginWindow.PasswordBox1.Password = string.Empty;
                    return;
                }

                user = UserProxy.Instance.Proxy.GetUser(Username);
            }catch(EndpointNotFoundException e)
            {
                MessageBox.Show(loginWindow, "Network error.");
                LogManager.GetLogger("Client").Debug($"Network error: {e}");
            }
            catch (Exception e) 
            {
                MessageBox.Show(loginWindow, "Network error.");
                LogManager.GetLogger("Client").Debug($"Login error: {e}");
            }

            Window newWindow;
            if (user.TypeUser == UserTypes.ADMIN)
            {
                newWindow = new FlowerPlotWindow();
                newWindow.DataContext = new FlowerPlotViewModel(newWindow,Visibility.Hidden,Visibility.Visible,Username);
            }
            else
            {
                newWindow = new FlowerPlotWindow();
                newWindow.DataContext = new FlowerPlotViewModel(newWindow, Visibility.Visible, Visibility.Hidden,Username);
            }

            LoggerTable.AddLog("Korisnik ulogovan.", TypeEventLog.INFO, DateTime.Now);
            newWindow.Show();
            loginWindow.Close();
        }

        public void Exit()
        {
            loginWindow.Close();
            Environment.Exit(0);
            LoggerTable.AddLog("Korisnik napustio aplikaciju.", TypeEventLog.INFO, DateTime.Now);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
