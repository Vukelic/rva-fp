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
    class AddEditFlowerPlotViewModel : BindableBase
    {
        private Window addEditFlowerPlotWindow;
        private BindingList<FlowerPlotIteration> myFlowerPlots;
        private string soilName;
        private string flowerName;
        private Visibility addNextStage;

        public AddEditFlowerPlotViewModel(FlowerPlotIteration flowerPlot, Window addEditFlowerPlotWindow, bool add, BindingList<FlowerPlotIteration> myFlowerPlots, Visibility addnextstage)
        {
            this.myFlowerPlots = myFlowerPlots;
            MyFlowerPlot = flowerPlot;
            this.addEditFlowerPlotWindow = addEditFlowerPlotWindow;
            Add = add;
            SoilName = MyFlowerPlot.SoilName;
            FlowerName = MyFlowerPlot.FlowerName;
            AddNextStage = addnextstage;

            ExitCommand = new MyICommand(Exit);
            NextStageCommand = new MyICommand(NextStage);

            mySoiltype = new List<SoilType>(SoilProxy.Instance.Proxy.GetAllSoilsType());
            MySoiltype = (from o in mySoiltype
                          select o.ToString()).ToList();
       
            myFlowerType = new List<Flower>(FlowerProxy.Instance.Proxy.GetAllFlowersType());
            MyFlowertype = (from o in myFlowerType
                            select o.ToString()).ToList();

            SaveFlowerPlotCommand = new MyICommand(SaveUserFlowerPlot, CanSaveFlowerPlot);

            NewFlowerPlot = MyFlowerPlot.Clone();
            NextStageChanged = true;

        }
        public bool NextStageChanged { get; set; }
        public bool Add { get; set; }
        public List<SoilType> mySoiltype { get; set; }
        public List<string> MySoiltype { get; set; }
        public List<string> MyFlowertype { get; set; }
        public List<Flower> myFlowerType { get; set; }
        public FlowerPlotIteration MyFlowerPlot { get; set; }
        public FlowerPlotIteration NewFlowerPlot { get; set; }
        public ICommand SaveFlowerPlotCommand { get; set; }
        public ICommand ExitCommand { get; set; }
        public ICommand NextStageCommand { get; set; }
        public Visibility AddNextStage
        {
            get => addNextStage;
            set { addNextStage = value; OnPropertyChanged("AddNextStage"); }
        }

        public bool IsIdleState
        {
            get => NewFlowerPlot.Stage == StageTypes.Idle;
        }

        public string SoilName
        {
            get => soilName;
            set { soilName = value; OnPropertyChanged("SoilName"); }
        }
        public string FlowerName
        {
            get => flowerName;
            set { flowerName = value; OnPropertyChanged("FlowerName"); }
        }
        public bool CanSaveFlowerPlot()
        {
            if (!String.IsNullOrWhiteSpace(NewFlowerPlot.Area.ToString()) && !String.IsNullOrWhiteSpace(NewFlowerPlot.HarvestDate.ToString())
               && !String.IsNullOrWhiteSpace(NewFlowerPlot.MoisturePerc.ToString()) && !String.IsNullOrWhiteSpace(NewFlowerPlot.PlantingDate.ToString())
                && !String.IsNullOrWhiteSpace(NewFlowerPlot.Stage.ToString()) && !String.IsNullOrEmpty(NewFlowerPlot.FlowerName) &&
                !String.IsNullOrEmpty(NewFlowerPlot.SoilName))
            {
                return true;
            }

            return false;
        }

        public void SaveUserFlowerPlot()
        {
            if (Add)
            {
                MyFlowerPlot.SaveProperties(NewFlowerPlot); 
                MyFlowerPlot.Id = (int)DateTime.Now.Ticks;
                FlowerPlotIterationProxy.Instance.Proxy.AddFlowerPlot(MyFlowerPlot);
                try
                {
                    myFlowerPlots.Add(MyFlowerPlot);
                    LoggerTable.AddLog("Korisnik dodao novi flowerplot.", TypeEventLog.INFO, DateTime.Now);
                }
                catch (EndpointNotFoundException e)
                {
                    MessageBox.Show(addEditFlowerPlotWindow, "Network error.");
                    LogManager.GetLogger("Client").Debug($"Network error: {e}");
                }
                catch (Exception e)
                {
                    MessageBox.Show(addEditFlowerPlotWindow, "Network error.");
                    LogManager.GetLogger("Client").Debug($"Login error: {e}");
                }
            }
            else
            {
                long time;
                if (FlowerPlotIterationProxy.Instance.Proxy.EditFlowerPlot(NewFlowerPlot, out time))
                {
                    NewFlowerPlot.LastChange = time;
                    MyFlowerPlot.SaveProperties(NewFlowerPlot);
                    addEditFlowerPlotWindow.Close();
                    LoggerTable.AddLog("Korisnik izmenio trenutni flowerplot.", TypeEventLog.INFO, DateTime.Now);
                    return;
                }

                if (MessageBox.Show("Another user change data, discard changes?", "...", System.Windows.MessageBoxButton.YesNo) == MessageBoxResult.No)
                {
                    FlowerPlotIterationProxy.Instance.Proxy.EditFlowerPlotOverride(NewFlowerPlot, out time);
                    MyFlowerPlot.SaveProperties(NewFlowerPlot);
                    MyFlowerPlot.LastChange = time;
                    LoggerTable.AddLog("Korisnik izmenio trenutni flowerplot.", TypeEventLog.INFO, DateTime.Now);
                }
                else
                {
                    LoggerTable.AddLog("Korisnik odbacio trenutne izmene.", TypeEventLog.INFO, DateTime.Now);
                }
            }

            addEditFlowerPlotWindow.Close();
        }

        public void Exit()
        {
            MessageBox.Show(addEditFlowerPlotWindow, "The changes are discarded");
            LoggerTable.AddLog("Korisnik odbacio svoje izmene.", TypeEventLog.INFO, DateTime.Now);
            addEditFlowerPlotWindow.Close();
        }

        public void NextStage()
        {
             if (MyFlowerPlot.Stage == StageTypes.Idle)
             {
                 NewFlowerPlot.Stage = StageTypes.Planted;
             }
             else if (MyFlowerPlot.Stage == StageTypes.Planted)
             {
                 NewFlowerPlot.Stage = StageTypes.Bloomed;
             }
             else if (MyFlowerPlot.Stage == StageTypes.Bloomed)
             {
                 NewFlowerPlot.Stage = StageTypes.Harvested;
             }
             else
             {
                 NewFlowerPlot.Stage = StageTypes.Idle;
             }

            NextStageChanged = false;
            OnPropertyChanged("IsIdleState");
        }
    }
}



