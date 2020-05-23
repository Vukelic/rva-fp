using Client.Commands;
using Client.View;
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
    class FlowerPlotViewModel : BindableBase
    {
        private Window flowerPlotWindow;
        private string searchString;
        private string username;
        public FlowerPlotViewModel(Window flowerPlotWindow, Visibility editUser, Visibility adminUser, string Username)
        {
            this.flowerPlotWindow = flowerPlotWindow;
            AddFlowerPlotCommand = new MyICommand(Add);
            EditFlowerPlotCommand = new MyICommand(Edit, CanEdit);
            DeleteFlowerPlotCommand = new MyICommand(Delete, CanDelete);
            LogoutCommand = new MyICommand(Logout);
            ExitCommand = new MyICommand(Exit);
            SoilTypeCommand = new MyICommand(Soiltype);
            FlowerTypeCommand = new MyICommand(Flowertype);
            SeacrhFlowerCommand = new MyICommand(SearchFlowerPlots);
            EditUserCommand = new MyICommand(EditUser);
            AdminUserCommand = new MyICommand(AdminUser);
            RefreshFlowerCommand = new MyICommand(RefreshFlowerPlots);
            DuplicateFlowerCommand = new MyICommand(DuplicateFlowerPlots, CanDuplicateFlowerPlots);
            UndoCommand = new MyICommand(UndoExecute, CanUndo);
            RedoCommand = new MyICommand(RedoExecute, CanRedo);
            ClearAllCommand = new MyICommand(ClearAll);
            EditIsEnable = editUser;
            AdminIsEnable = adminUser;
            SearchString = string.Empty;
            username = Username;

            MyFlowerPlots = new BindingList<FlowerPlotIteration>(FlowerPlotIterationProxy.Instance.Proxy.GetAllFlowerPlots());

            MyUsers = new BindingList<User>(UserProxy.Instance.Proxy.GetAllUsers());

            NewMyUser = UserProxy.Instance.Proxy.GetUser(Username);

        }
        public static BindingList<string> Logs { get => LoggerTable.Logs; }
        public BindingList<FlowerPlotIteration> MyFlowerPlots { get; set; }
        public BindingList<SoilType> MySoilType { get; set; }
        public BindingList<User> MyUsers { get; set; }
        public BindingList<Flower> MyFlowerType { get; set; }
        public FlowerPlotIteration SelectedFlowerPlot { get; set; }
        public FlowerPlotIteration NewSelectedFlowerPlot { get; set; }
        public FlowerPlotIteration UndoRedoFlowerPlot { get; set; }
        public User NewMyUser { get; set; }
        public Visibility EditIsEnable { get; set; }
        public Visibility AdminIsEnable { get; set; }
        public ICommand AddFlowerPlotCommand { get; set; }
        public ICommand EditFlowerPlotCommand { get; set; }
        public ICommand DeleteFlowerPlotCommand { get; set; }
        public ICommand LogoutCommand { get; set; }
        public ICommand ExitCommand { get; set; }
        public ICommand SoilTypeCommand { get; set; }
        public ICommand FlowerTypeCommand { get; set; }
        public ICommand StageCommand { get; set; }
        public ICommand SeacrhFlowerCommand { get; set; }
        public ICommand EditUserCommand { get; set; }
        public ICommand AdminUserCommand { get; set; }
        public ICommand RefreshFlowerCommand { get; set; }
        public ICommand DuplicateFlowerCommand { get; set; }
        public ICommand UndoCommand { get; set; }
        public ICommand RedoCommand { get; set; }
        public ICommand ClearAllCommand { get; set; }
        public string SearchString
        {
            get => searchString;
            set { searchString = value; OnPropertyChanged("SearchString"); }
        }

        public string Username
        {
            get => username;
            set { username = value; }
        }
        public void Soiltype()
        {
            MySoilType = new BindingList<SoilType>(SoilProxy.Instance.Proxy.GetAllSoilsType());
            SoilType soiltype = new SoilType();
            Window soilTypeWindow = new SoilTypeWindow();
            soilTypeWindow.DataContext = new SoilTypeViewModel(soilTypeWindow, MySoilType, soiltype);
            soilTypeWindow.ShowDialog();
        }

        public void Flowertype()
        {
            MyFlowerType = new BindingList<Flower>(FlowerProxy.Instance.Proxy.GetAllFlowersType());
            Flower flower = new Flower();
            Window flowerWindow = new FlowerWindow();
            flowerWindow.DataContext = new FlowerViewModel(flowerWindow, MyFlowerType, flower);
            flowerWindow.ShowDialog();
        }

        public void Add()
        {
            FlowerPlotIteration flowerPlot = new FlowerPlotIteration();
            Window addEditFlowerPlotWindow = new AddEditFlowerPlotWindow();
            addEditFlowerPlotWindow.DataContext = new AddEditFlowerPlotViewModel(flowerPlot, addEditFlowerPlotWindow, true, MyFlowerPlots, Visibility.Hidden);
            addEditFlowerPlotWindow.ShowDialog();
        }

        public void EditUser()
        {
            Window addEditWindow = new AddEditWindow();
            addEditWindow.DataContext = new AddEditViewModel(NewMyUser, addEditWindow, false, MyUsers, false);
            addEditWindow.ShowDialog();
        }

        public void AdminUser()
        {
            Window adminWindow = new AdminWindow();
            adminWindow.DataContext = new AdminViewModel(adminWindow);
            adminWindow.ShowDialog();
        }
        public bool CanEdit()
        {
            return SelectedFlowerPlot != null;
        }

        public void Edit()
        {
            Window addEditFlowerPlotWindow = new AddEditFlowerPlotWindow();
            addEditFlowerPlotWindow.DataContext = new AddEditFlowerPlotViewModel(SelectedFlowerPlot, addEditFlowerPlotWindow, false, MyFlowerPlots, Visibility.Visible);
            addEditFlowerPlotWindow.ShowDialog();
        }

        public bool CanDelete()
        {
            return SelectedFlowerPlot != null;
        }

        public void Delete()
        {
            UndoRedoFlowerPlot = SelectedFlowerPlot.Clone();
            try
            {
                if (FlowerPlotIterationProxy.Instance.Proxy.DeleteFlowerPlot(SelectedFlowerPlot))
                {
                    MyFlowerPlots.Remove(SelectedFlowerPlot);
                    canUndo = true;
                    canRedo = false;
                    LoggerTable.AddLog("Korisnik obrisao trenutni flowerplot.", TypeEventLog.INFO, DateTime.Now);
                    return;
                }

                if (MessageBox.Show("Another user change data, discard changes?", "...", System.Windows.MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    LoggerTable.AddLog("Korisnik odbacio izmene.", TypeEventLog.INFO, DateTime.Now);
                    return;
                }
                else
                {
                    FlowerPlotIterationProxy.Instance.Proxy.DeleteFlowerPlotOverride(SelectedFlowerPlot);
                    MyFlowerPlots.Remove(SelectedFlowerPlot);
                    canUndo = true;
                    canRedo = false;
                    LoggerTable.AddLog("Korisnik obrisao trenutni flowerplot.", TypeEventLog.INFO, DateTime.Now);
                }
            }
            catch (EndpointNotFoundException e)
            {
                MessageBox.Show(flowerPlotWindow, "Network error.");
                LogManager.GetLogger("Client").Debug($"Network error: {e}");
            }
            catch (Exception e)
            {
                MessageBox.Show(flowerPlotWindow, "Network error.");
                LogManager.GetLogger("Client").Debug($"Login error: {e}");
            }
             
        }

        public void Logout()
        {
            Window loginWindow = new LoginWindow();
            loginWindow.Show();
            flowerPlotWindow.Close();
            LoggerTable.AddLog("Korisnik se odjavio.", TypeEventLog.INFO, DateTime.Now);
        }

        public void Exit()
        {
            flowerPlotWindow.Close();
            LoggerTable.AddLog("Korisnik se odjavio.", TypeEventLog.INFO, DateTime.Now);
        }

        public void SearchFlowerPlots()
        {
            MyFlowerPlots = new BindingList<FlowerPlotIteration>(FlowerPlotIterationProxy.Instance.Proxy.SearchFlowerPlots(SearchString));
            OnPropertyChanged("MyFlowerPlots");
            SearchString = string.Empty;
            LoggerTable.AddLog("Korisnik vrsi pretragu.", TypeEventLog.INFO, DateTime.Now);
        }

        public void RefreshFlowerPlots()
        {
            MyFlowerPlots = new BindingList<FlowerPlotIteration>(FlowerPlotIterationProxy.Instance.Proxy.GetAllFlowerPlots());
            OnPropertyChanged("MyFlowerPlots");
            LoggerTable.AddLog("Korisnik osvezava prikaz tabele.", TypeEventLog.INFO, DateTime.Now);
        }

        public bool CanDuplicateFlowerPlots()
        {
            return SelectedFlowerPlot != null;
        }

        public void DuplicateFlowerPlots()
        {
            NewSelectedFlowerPlot = SelectedFlowerPlot.Clone();
            NewSelectedFlowerPlot.Id = (int)DateTime.Now.Ticks;

            FlowerPlotIterationProxy.Instance.Proxy.AddFlowerPlot(NewSelectedFlowerPlot);
            try
            {
                MyFlowerPlots.Add(NewSelectedFlowerPlot);
                LoggerTable.AddLog("Korisnik duplira postojeci objekat.", TypeEventLog.INFO, DateTime.Now);
            }
            catch (Exception)
            {
                MessageBox.Show(flowerPlotWindow, "Can not be duplicate flowerplot!");
            }
        }

        bool canUndo = false;
        bool canRedo = false;

        public void UndoExecute()
        {
            FlowerPlotIterationProxy.Instance.Proxy.AddFlowerPlot(UndoRedoFlowerPlot);
            try
            {
                MyFlowerPlots.Add(UndoRedoFlowerPlot);
                canRedo = true;
                canUndo = false;
                LoggerTable.AddLog("Korisnik dodao novi flowerplot.", TypeEventLog.INFO, DateTime.Now);
            }
            catch (Exception)
            {
                MessageBox.Show("Can not be added FlowerPlot!");
            }
        }

        public bool CanUndo()
        {
            return canUndo;
        }

        public void RedoExecute()
        {
            if (FlowerPlotIterationProxy.Instance.Proxy.DeleteFlowerPlot(UndoRedoFlowerPlot))
            {
                MyFlowerPlots.Remove(UndoRedoFlowerPlot);
                LoggerTable.AddLog("Korisnik obrisao trenutni flowerplot.", TypeEventLog.INFO, DateTime.Now);

                canRedo = false;
                canUndo = true;
                return;
            }

            if (MessageBox.Show("Another user change data, discard changes?", "...", System.Windows.MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                LoggerTable.AddLog("Korisnik odbacio izmene.", TypeEventLog.INFO, DateTime.Now);
                return;
            }
            else
            {
                FlowerPlotIterationProxy.Instance.Proxy.DeleteFlowerPlotOverride(UndoRedoFlowerPlot);
                MyFlowerPlots.Remove(UndoRedoFlowerPlot);
                canRedo = false;
                canUndo = true;
                LoggerTable.AddLog("Korisnik obrisao trenutni flowerplot.", TypeEventLog.INFO, DateTime.Now);
            }
        }

        public bool CanRedo()
        {
            return canRedo;
        }
        public void ClearAll()
        {
            LoggerTable.Logs.Clear();
        }
    }
}