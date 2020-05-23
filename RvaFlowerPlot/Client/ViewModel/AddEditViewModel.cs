using Client.Commands;
using Common;
using log4net;
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
    class AddEditViewModel : BindableBase
    {
        private Window addEditWindow;
        private BindingList<User> myUsers;
        private string labelUsername;
        private string labelPassword;
        private string labelLastname;
        private string labelName;
        private string labelType;

        public AddEditViewModel(User user, Window addEditWindow, bool add, BindingList<User> myUsers,bool edit)
        {
            this.myUsers = myUsers;
            this.addEditWindow = addEditWindow;
            MyUser = user;
            NewMyUser = MyUser.Clone();
            Add = add;
            Edit = edit;
            UserTypesList = Enum.GetNames(typeof(UserTypes)).ToList();
            TypeUser = user.TypeUser.ToString();
          
            SaveUserCommand = new MyICommand(SaveUser, CanSaveUser);
            ExitCommand = new MyICommand(Exit);
        }

        public bool Add { get; set; }
        public bool Edit { get; set; }
        public User MyUser { get; set; }
        public string TypeUser { get; set; }
        public User NewMyUser { get; set; } 
        public List<string> UserTypesList { get; set; }
        public ICommand SaveUserCommand { get; set; }
        public ICommand ExitCommand { get; set; }
 
        public string LabelUsername
        {
            get => labelUsername;
            set { labelUsername = value; OnPropertyChanged("LabelUsername"); }
        }
        public string LabelName
        {
            get => labelName;
            set { labelName = value; OnPropertyChanged("LabelName"); }
        }
        public string LabelLastname
        {
            get => labelLastname;
            set { labelLastname = value; OnPropertyChanged("LabelLastname"); }
        }
        public string LabelPassword
        {
            get => labelPassword;
            set { labelPassword = value; OnPropertyChanged("LabelPassword"); }
        }

        public string LabelType
        {
            get => labelType;
            set { labelType = value; OnPropertyChanged("LabelType"); }
        }

        public bool CanSaveUser()
        {
            if (String.IsNullOrWhiteSpace(NewMyUser.Username))
            {
                LabelUsername = "Username is required";
                LabelLastname = string.Empty;
                LabelName = string.Empty;
                LabelType = string.Empty;
                LabelPassword = string.Empty;
                return false;
            }
            if (String.IsNullOrWhiteSpace(NewMyUser.Password))
            {
                LabelPassword = "Password is required";
                LabelLastname = string.Empty;
                LabelName = string.Empty;
                LabelType = string.Empty;
                LabelUsername = string.Empty;
                return false;
            }
            if (String.IsNullOrWhiteSpace(NewMyUser.Name))
            {
                LabelName = "Name is required";
                LabelLastname = string.Empty;
                LabelPassword = string.Empty;
                LabelType = string.Empty;
                LabelUsername = string.Empty;
                return false;
            }
            if(String.IsNullOrWhiteSpace(NewMyUser.Lastname))
            {
                LabelLastname = "Lastname is required";
                LabelPassword = string.Empty;
                LabelName = string.Empty;
                LabelType = string.Empty;
                LabelUsername = string.Empty;
                return false;
            }
            
            if (String.IsNullOrWhiteSpace(NewMyUser.TypeUser.ToString()))
            {
                LabelType = "Type is required";
                return false;
            }

            LabelPassword = string.Empty;
            LabelLastname = string.Empty;
            LabelName = string.Empty;
            LabelType = string.Empty;
            LabelUsername = string.Empty;
            return true;
        }

        public void SaveUser()
        {
            MyUser.SaveProperties(NewMyUser);
            if (Add)
            {
                if (UserProxy.Instance.Proxy.AddUser(MyUser))
                {
                    try
                    {
                        myUsers.Add(MyUser);
                        LoggerTable.AddLog("Korisnik dodao novog korisnika.", TypeEventLog.INFO, DateTime.Now);
                    }
                    catch (EndpointNotFoundException e)
                    {
                        MessageBox.Show(addEditWindow, "Network error.");
                        LogManager.GetLogger("Client").Debug($"Network error: {e}");
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show(addEditWindow, "Network error.");
                        LogManager.GetLogger("Client").Debug($"Login error: {e}");
                    }
                }           
            }
            else
            {
                UserProxy.Instance.Proxy.EditUser(MyUser);
                LoggerTable.AddLog("Korisnik izmenio korisnika.", TypeEventLog.INFO, DateTime.Now);
            }

            addEditWindow.Close();
        }

        public void Exit()
        {
            MessageBox.Show(addEditWindow, "The changes are discarded");
            LoggerTable.AddLog("Korisnik odbacio svoje izmene.", TypeEventLog.INFO, DateTime.Now);
            addEditWindow.Close();
        } 
    }
}
