using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    class FlowerService : IFlower
    {
        public bool AddFlowerType(Flower flower)
        {
            using (IUnitOfWork unit = new UnitOfWork(new Context()))
            {
                Flower f = unit.FlowersType.Get(flower.FlowerName);
                if (f == null) //ako takvav user ne postoji,dodaj
                {
                    unit.FlowersType.Add(flower);
                    unit.Complete();
                    return true;
                }
                return false;
            }
        }

        public List<Flower> GetAllFlowersType()
        {
            using (IUnitOfWork unit = new UnitOfWork(new Context()))
            {
                return new List<Flower>(unit.FlowersType.GetAll());
            }
        }

        public Flower GetFlowerType(string FlowerName)
        {
            using (IUnitOfWork unit = new UnitOfWork(new Context()))
            {
                return unit.FlowersType.Get(FlowerName);
            }
        }
    }
}
