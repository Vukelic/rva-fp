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
    class SoilTypeViewModel : BindableBase
    {
        private Window soiltypewindow;
        private BindingList<SoilType> mySoils;
        private string label1;
        private string labelName;
        public SoilTypeViewModel(Window SoilTypeWindow,BindingList<SoilType> mySoils,SoilType soiltype)
        {
            this.soiltypewindow = SoilTypeWindow;
            this.mySoils = mySoils;
            MySoilType = soiltype;

            SaveSoilCommand = new MyICommand(SaveSoil, CanSaveSoil);
            ExitCommand = new MyICommand(Exit);
        }
        public SoilType MySoilType { get; set; }
        public ICommand SaveSoilCommand { get; set; }
        public ICommand ExitCommand { get; set; }
        public string Label1
        {
            get => label1;
            set { label1 = value; OnPropertyChanged("Label1"); }
        }

        public string LabelName
        {
            get => labelName;
            set { labelName = value; OnPropertyChanged("LabelName"); }
        }

        public bool CanSaveSoil()
        { 
            if (MySoilType.ClayPercent + MySoilType.SandPercent + MySoilType.SiltPercent != 100)
            {
                Label1 = "The sum \n[ClayPercent,\n" +
                       "SandPercent, \n SiltPercent]" +
                       "\n must be 100%";
                return false;
            }

            if (String.IsNullOrWhiteSpace(MySoilType.SoilName)) 
            {
                Label1 = string.Empty;
                LabelName = "Name is required!";
                return false;
            }

            Label1 = string.Empty;
            LabelName = string.Empty;

            return true;
        }

        public void SaveSoil()
        {
            SoilProxy.Instance.Proxy.AddSoilType(MySoilType);

            try
            {
                mySoils.Add(MySoilType);
                LoggerTable.AddLog("Korisnik dodaje novi tip zemljista.", TypeEventLog.INFO, DateTime.Now);
            }
            catch (EndpointNotFoundException e)
            {
                MessageBox.Show(soiltypewindow, "Network error.");
                LogManager.GetLogger("Client").Debug($"Network error: {e}");
            }
            catch (Exception e)
            {
                MessageBox.Show(soiltypewindow, "Network error.");
                LogManager.GetLogger("Client").Debug($"Login error: {e}");
            }


            soiltypewindow.Close();
        }

        public void Exit()
        {
            soiltypewindow.Close();
            LoggerTable.AddLog("Korisnik odbacio svoje izmene.", TypeEventLog.INFO, DateTime.Now);
        }
    }
}
