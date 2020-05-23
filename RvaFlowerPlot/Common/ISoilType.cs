using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    [ServiceContract]
 public interface ISoilType
    {
        [OperationContract]
        SoilType GetSoilType(string SoilName);

        [OperationContract]
        bool AddSoilType(SoilType soil);

        [OperationContract]
        List<SoilType> GetAllSoilsType();
    }
}
