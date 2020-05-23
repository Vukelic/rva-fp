using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    public class FlowerPlotIterationService : IFlowerPlotIteration
    {
        private static object lockObject = new object();

        public bool AddFlowerPlot(FlowerPlotIteration flower)
        {
            using (IUnitOfWork unit = new UnitOfWork(new Context()))
            {
                FlowerPlotIteration f = unit.Flowers.Get(flower.Id);
                if (f == null) //ako takvav user ne postoji,dodaj
                {
                    unit.Flowers.Add(flower);
                    unit.Complete();
                    FlowerPlotIteration f1 = unit.Flowers.Get(flower.Id);
                    return true;
                }
                return false;
            }
        }

        public bool DeleteFlowerPlot(FlowerPlotIteration flowerPlot)
        {
            using (IUnitOfWork unit = new UnitOfWork(new Context()))
            {
                FlowerPlotIteration flower = unit.Flowers.Get(flowerPlot.Id);
                if (flower != null) //postoji obrisi
                {
                    if (flowerPlot.LastChange != flower.LastChange)
                    {
                        return false;
                    }

                    unit.Flowers.Remove(flower);
                    unit.Complete();
                    return true;
                }

                return true;
            }
        }

        public void DeleteFlowerPlotOverride(FlowerPlotIteration flowerPlot)
        {
            lock (lockObject)
            {
                using (IUnitOfWork unit = new UnitOfWork(new Context()))
                {
                    FlowerPlotIteration flower = unit.Flowers.Get(flowerPlot.Id);
                    if (flower != null) //postoji obrisi
                    {
                        unit.Flowers.Remove(flower);
                        unit.Complete();
                    }
                } 
            }
        }

        public bool EditFlowerPlot(FlowerPlotIteration flower, out long time)
        {
            using (IUnitOfWork unit = new UnitOfWork(new Context()))
            {
                FlowerPlotIteration f = unit.Flowers.Get(flower.Id);
                if (f != null)
                {
                    if (flower.LastChange != f.LastChange)
                    {
                        time = 0;
                        return false;
                    }

                    flower.LastChange = DateTime.Now.Ticks;

                    unit.Flowers.Remove(f);
                    unit.Flowers.Add(flower);

                    unit.Complete();
                    time = flower.LastChange;
                    return true;
                }

                time = 0;
                return false;
            }
        }

        public void EditFlowerPlotOverride(FlowerPlotIteration flower, out long time)
        {
            lock (lockObject)
            {
                using (IUnitOfWork unit = new UnitOfWork(new Context()))
                {
                    FlowerPlotIteration f = unit.Flowers.Get(flower.Id);
                    if (f != null)
                    {
                        unit.Flowers.Remove(f);

                    }

                    flower.LastChange = DateTime.Now.Ticks;
                    time = flower.LastChange;
                    unit.Flowers.Add(flower);

                    unit.Complete();
                }
            }
        }

        public List<FlowerPlotIteration> GetAllFlowerPlots()
        {
            using (IUnitOfWork unit = new UnitOfWork(new Context()))
            {
                return new List<FlowerPlotIteration>( unit.Flowers.GetAll());           
            }
        }

        public FlowerPlotIteration GetFlowerPlot(int id)
        {
            using (IUnitOfWork unit = new UnitOfWork(new Context()))
            {
                return unit.Flowers.Get(id);
            }
        }

        public List<FlowerPlotIteration> SearchFlowerPlots(string searchText)
        {
            using (Context baza = new Context())
            {
                return baza.Flowers.Where(x => x.SoilName.Contains(searchText) || x.FlowerName.Contains(searchText) || x.Stage.ToString().Contains(searchText)).ToList();
            }
        }
    }
}
