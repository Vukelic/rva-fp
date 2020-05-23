using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    [ServiceContract]
    public interface IFlower
    {
        [OperationContract]
        Flower GetFlowerType(string FlowerName);

        [OperationContract]
        bool AddFlowerType(Flower flower);

        [OperationContract]
        List<Flower> GetAllFlowersType();
    }
}
