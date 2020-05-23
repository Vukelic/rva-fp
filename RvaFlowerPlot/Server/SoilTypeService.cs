using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    class SoilTypeService : ISoilType
    {
        public bool AddSoilType(SoilType soil)
        {
            using (IUnitOfWork unit = new UnitOfWork(new Context()))
            {
                SoilType s = unit.Soils.Get(soil.SoilName);
                if (s == null) //ako takvav user ne postoji,dodaj
                {
                    unit.Soils.Add(soil);
                    unit.Complete();
                    return true;
                }
                return false;
            }
        }

        public List<SoilType> GetAllSoilsType()
        {
            using (IUnitOfWork unit = new UnitOfWork(new Context()))
            {
                return new List<SoilType>(unit.Soils.GetAll());
            }
        }

        public SoilType GetSoilType(string SoilName)
        {
            using (IUnitOfWork unit = new UnitOfWork(new Context()))
            {
                return unit.Soils.Get(SoilName);
            }
        }
    }
}
