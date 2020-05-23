using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    class FlowerProxy
    {
        private static object lockObject = new object();
        private static FlowerProxy instance;

        private FlowerProxy()
        {
            NetTcpBinding myBinding = new NetTcpBinding();
            myBinding.Security.Mode = SecurityMode.Transport;
            myBinding.Security.Transport.ClientCredentialType =
                TcpClientCredentialType.Windows;


            ChannelFactory<IFlower> FlowersFactory =
                    new ChannelFactory<IFlower>(
                    myBinding,
                    new EndpointAddress("net.tcp://localhost:4000/IFlower"));
            Proxy = FlowersFactory.CreateChannel();
        }

        public IFlower Proxy { get; set; }

        public static FlowerProxy Instance
        {
            get
            {
                lock (lockObject)
                {
                    if (instance == null)
                    {
                        instance = new FlowerProxy();
                    }

                    return instance;
                }
            }
        }
    }
}

