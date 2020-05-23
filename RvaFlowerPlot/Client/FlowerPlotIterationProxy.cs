using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    class FlowerPlotIterationProxy
    {
        private static object lockObject = new object();
        private static FlowerPlotIterationProxy instance;

        private FlowerPlotIterationProxy()
        {
            NetTcpBinding myBinding = new NetTcpBinding();
            myBinding.Security.Mode = SecurityMode.Transport;
            myBinding.Security.Transport.ClientCredentialType =
                TcpClientCredentialType.Windows;


            ChannelFactory<IFlowerPlotIteration> FlowerPlotsFactory =
                    new ChannelFactory<IFlowerPlotIteration>(
                    myBinding,
                    new EndpointAddress("net.tcp://localhost:4000/IFlowerPlotIteration"));
            Proxy = FlowerPlotsFactory.CreateChannel();
        }

        public IFlowerPlotIteration Proxy { get; set; }

        public static FlowerPlotIterationProxy Instance
        {
            get
            {
                lock (lockObject)
                {
                    if (instance == null)
                    {
                        instance = new FlowerPlotIterationProxy();
                    }

                    return instance;
                }
            }
        }
    }
}

