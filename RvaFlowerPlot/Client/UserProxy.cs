using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    class UserProxy
    {
        private static object lockObject = new object();
        private static UserProxy instance;

        private UserProxy()
        {
            NetTcpBinding myBinding = new NetTcpBinding();
            myBinding.Security.Mode = SecurityMode.Transport;
            myBinding.Security.Transport.ClientCredentialType =
                TcpClientCredentialType.Windows;


            ChannelFactory<IUserDatabase> UsersFactory = 
                    new ChannelFactory<IUserDatabase>(
                    myBinding, 
                    new EndpointAddress("net.tcp://localhost:4000/IUserDatabase"));
            Proxy = UsersFactory.CreateChannel();
        }

        public IUserDatabase Proxy { get; set; }

        public static UserProxy Instance 
        {
            get
            {
                lock (lockObject)
                {
                    if(instance == null)
                    {
                        instance = new UserProxy();
                    }

                    return instance;
                }
            }
        }
    }
}
