using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public enum StageTypes { Idle, Planted, Bloomed, Harvested }

    [DataContract]
    public class FlowerPlotIteration : BindableBase, IFlowerPlotPrototype
    {
        private StageTypes stage;

        public FlowerPlotIteration()
        {
            LastChange = DateTime.Now.Ticks;
            HarvestDate = DateTime.Now;
            PlantingDate = DateTime.Now;
        }

        [DataMember]
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [DataMember]
        public float Area { get; set; }

        [DataMember]
        public DateTime HarvestDate { get; set; } 

        [DataMember]
        public float MoisturePerc { get; set; } 

        [DataMember]
        public DateTime PlantingDate { get; set; } 

        [DataMember]
        public StageTypes Stage { get => stage; set { stage = value; OnPropertyChanged("Stage"); } } 

        [DataMember]
        public string SoilName { get; set; }

        [DataMember]
        public string FlowerName { get; set; }

        [DataMember]
        public long LastChange { get; set; }

        public FlowerPlotIteration Clone()
        {
            return new FlowerPlotIteration()
            {
                Id = this.Id,
                LastChange = this.LastChange,
                Area = this.Area,
                HarvestDate = this.HarvestDate,
                MoisturePerc = this.MoisturePerc,
                SoilName = this.SoilName,
                FlowerName = this.FlowerName,
                PlantingDate = this.PlantingDate,
                Stage = this.Stage,
            };
        }

        public void SaveProperties(FlowerPlotIteration myFlowerPlotIteration)
        {
            this.Id = myFlowerPlotIteration.Id;
            this.LastChange = myFlowerPlotIteration.LastChange;
            this.Area = myFlowerPlotIteration.Area;
            this.HarvestDate = myFlowerPlotIteration.HarvestDate;
            this.MoisturePerc = myFlowerPlotIteration.MoisturePerc;
            this.SoilName = myFlowerPlotIteration.SoilName;
            this.FlowerName = myFlowerPlotIteration.FlowerName;
            this.PlantingDate = myFlowerPlotIteration.PlantingDate;
            this.Stage = myFlowerPlotIteration.Stage;
            OnPropertyChanged("Area");
            OnPropertyChanged("HarvestDate");
            OnPropertyChanged("MoisturePerc");
            OnPropertyChanged("SoilName");
            OnPropertyChanged("FlowerName");
            OnPropertyChanged("PlantingDate");
        }
    }
}
