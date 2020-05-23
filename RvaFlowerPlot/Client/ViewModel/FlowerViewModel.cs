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
    class FlowerViewModel : BindableBase
    {
        private Window flowerwindow;
        private BindingList<Flower> myFlowers;
        private string label1;
        public FlowerViewModel(Window flowerwindow, BindingList<Flower> myFlowers, Flower flower)
        {
            this.flowerwindow = flowerwindow;
            this.myFlowers = myFlowers;
            MyFlower = flower;

            SaveFlowerCommand = new MyICommand(SaveFlower, CanSaveFlower);
            ExitCommand = new MyICommand(Exit);
        }

        public Flower MyFlower { get; set; }
        public ICommand SaveFlowerCommand { get; set; }
        public ICommand ExitCommand { get; set; }
        public string Label1
        {
            get => label1;
            set { label1 = value; OnPropertyChanged("Label1"); }
        }
        public bool CanSaveFlower()
        {
             if (!String.IsNullOrWhiteSpace(MyFlower.FlowerName))
             {
                Label1 = string.Empty;
                 return true;
             }

            Label1 = "Name is name required!";
            return false;
        }

        public void SaveFlower()
        {
            FlowerProxy.Instance.Proxy.AddFlowerType(MyFlower);
            try
            {
                myFlowers.Add(MyFlower);
                LoggerTable.AddLog("Korisnik dodaje novi tip cveta.", TypeEventLog.INFO, DateTime.Now);
            }
            catch (EndpointNotFoundException e)
            {
                MessageBox.Show(flowerwindow, "Network error.");
                LogManager.GetLogger("Client").Debug($"Network error: {e}");
            }
            catch (Exception e)
            {
                MessageBox.Show(flowerwindow, "Network error.");
                LogManager.GetLogger("Client").Debug($"Login error: {e}");
            }

            flowerwindow.Close();
        }
        public void Exit()
        {
            flowerwindow.Close();
            LoggerTable.AddLog("Korisnik odbacio svoje izmene.", TypeEventLog.INFO, DateTime.Now);
        }
    }
}
