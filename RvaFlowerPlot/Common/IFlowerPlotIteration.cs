using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    [ServiceContract]
    public interface IFlowerPlotIteration
    {
        [OperationContract]
        FlowerPlotIteration GetFlowerPlot(int id);

        [OperationContract]
        bool AddFlowerPlot(FlowerPlotIteration flower);

        [OperationContract]
        bool EditFlowerPlot(FlowerPlotIteration flower, out long time);

        [OperationContract]
        bool DeleteFlowerPlot(FlowerPlotIteration flowerPlot);

        [OperationContract]
        void DeleteFlowerPlotOverride(FlowerPlotIteration flowerPlot);

        [OperationContract]
        List<FlowerPlotIteration> GetAllFlowerPlots();

        [OperationContract]
        List<FlowerPlotIteration> SearchFlowerPlots(string searchText);

        [OperationContract]
        void EditFlowerPlotOverride(FlowerPlotIteration newFlowerPlot, out long time);
    }
}
