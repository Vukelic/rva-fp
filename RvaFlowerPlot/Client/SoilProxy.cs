using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    class SoilProxy
    {
        private static object lockObject = new object();
        private static SoilProxy instance;

        private SoilProxy()
        {
            NetTcpBinding myBinding = new NetTcpBinding();
            myBinding.Security.Mode = SecurityMode.Transport;
            myBinding.Security.Transport.ClientCredentialType =
                TcpClientCredentialType.Windows;


            ChannelFactory<ISoilType> SoilsFactory =
                    new ChannelFactory<ISoilType>(
                    myBinding,
                    new EndpointAddress("net.tcp://localhost:4000/ISoilType"));
            Proxy = SoilsFactory.CreateChannel();
        }

        public ISoilType Proxy { get; set; }

        public static SoilProxy Instance
        {
            get
            {
                lock (lockObject)
                {
                    if (instance == null)
                    {
                        instance = new SoilProxy();
                    }

                    return instance;
                }
            }
        }
    }
}

