using Common;
using log4net;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    class Program
    {
        private static ServiceHost soilTypeServer;
        private static ServiceHost flowerServer;
        private static ServiceHost flowerPlotServer;
        private static ServiceHost userServer;
     

        static void Main(string[] args)
        {
            LogManager.GetLogger("Server").Debug("Server is started.");

            string path = Directory.GetCurrentDirectory();
            path = path.Substring(0, path.LastIndexOf("bin"));
            AppDomain.CurrentDomain.SetData("DataDirectory", path);

            if (BaseIsEmpty())
            {
                LogManager.GetLogger("Server").Debug("Base is empty.");
                AddToBase();
            }
            Host();

            Console.WriteLine("Server started on port 4000.");

            Console.ReadKey(true);
            userServer.Close();
            flowerPlotServer.Close();
            flowerServer.Close();
            soilTypeServer.Close();
        }

        private static bool BaseIsEmpty()
        {
            using (IUnitOfWork context = new UnitOfWork(new Context()))
            {
                if (context.NotExists())
                {
                    return false;
                }
                return true;
            }
        }

        public static void Host()
        {
            NetTcpBinding binding = new NetTcpBinding();
            binding.Security.Mode = SecurityMode.Transport;
            binding.Security.Transport.ClientCredentialType =
                TcpClientCredentialType.Windows;

            userServer = new ServiceHost(typeof(UserService));
            userServer.AddServiceEndpoint(typeof(IUserDatabase),
                                       binding,
                                        new Uri("net.tcp://localhost:4000/IUserDatabase"));
            userServer.Open();

            flowerPlotServer = new ServiceHost(typeof(FlowerPlotIterationService));
            flowerPlotServer.AddServiceEndpoint(typeof(IFlowerPlotIteration),
                                        binding,
                                        new Uri("net.tcp://localhost:4000/IFlowerPlotIteration"));
            flowerPlotServer.Open();

            flowerServer = new ServiceHost(typeof(FlowerService));
            flowerServer.AddServiceEndpoint(typeof(IFlower),
                                        binding,
                                        new Uri("net.tcp://localhost:4000/IFlower"));
            flowerServer.Open();

            soilTypeServer = new ServiceHost(typeof(SoilTypeService));
            soilTypeServer.AddServiceEndpoint(typeof(ISoilType),
                                       binding,
                                        new Uri("net.tcp://localhost:4000/ISoilType"));
            soilTypeServer.Open();
        }

        private static void AddToBase()
        {

            using (IUnitOfWork context = new UnitOfWork(new Context()))
            {
               
               context.DeleteDatabase();
                User adminUser = new User()
                {
                    Username = "admin",
                    Password = "admin",
                    Name = "Biljana",
                    Lastname = "Vukelic",
                    TypeUser = UserTypes.ADMIN
                };

                User regularUser = new User()
                {
                    Username = "obican",
                    Password = "obican",
                    Name = "obican",
                    Lastname = "obican",
                    TypeUser = UserTypes.REGULAR
                };


                SoilType soil1 = new SoilType()
                {
                    SoilName = "Smonica",
                    ClayPercent = 20,
                    SandPercent = 20,
                    SiltPercent = 60
                };
                SoilType soil2 = new SoilType()
                {
                    SoilName = "Crnica",
                    ClayPercent = 80,
                    SandPercent = 10,
                    SiltPercent = 10
                };
                SoilType soil3 = new SoilType()
                {
                    SoilName = "Gajnjaca",
                    ClayPercent = 70,
                    SandPercent = 20,
                    SiltPercent = 10
                };

                Flower flower1 = new Flower()
                {
                    FlowerName = "Ruza"
                };

                Flower flower2 = new Flower()
                {
                    FlowerName = "Gerber"
                };

                Flower flower3 = new Flower()
                {
                    FlowerName = "Bozur"
                };
              
                FlowerPlotIteration flowerPlot1 = new FlowerPlotIteration()
                {
                    Area = 5,
                    Id = 501,
                    Stage = StageTypes.Idle,
                    HarvestDate = DateTime.Now,
                    MoisturePerc = 10,
                    PlantingDate = DateTime.Now,
                    FlowerName = "Ruza",
                    SoilName = "Crnica[Clay:80% Sand:10% Slit:10%]",
                    LastChange = DateTime.Now.Ticks
                };

                FlowerPlotIteration flowerPlot2 = new FlowerPlotIteration()
                {
                    Area = 6,
                    Id = 502,
                    Stage = StageTypes.Planted,
                    HarvestDate = DateTime.Now,
                    MoisturePerc = 20,
                    PlantingDate = DateTime.Now,
                    FlowerName = "Gerber",
                    SoilName = "Smonica[Clay:20% Sand:20% Slit:60%]",
                    LastChange = DateTime.Now.Ticks
                };

                FlowerPlotIteration flowerPlot3 = new FlowerPlotIteration()
                {
                    Area = 7,
                    Id = 503,
                    Stage = StageTypes.Bloomed,
                    HarvestDate = DateTime.Now,
                    MoisturePerc = 30,
                    PlantingDate = DateTime.Now,
                    FlowerName = "Bozur",
                    SoilName = "Gajnjaca[Clay:70% Sand:20% Slit:10%]",
                    LastChange = DateTime.Now.Ticks
                };

                try
                {
                    context.Users.Add(adminUser);
                    context.Users.Add(regularUser);
                    context.Soils.Add(soil1);
                    context.Soils.Add(soil2);
                    context.Soils.Add(soil3);
                    context.FlowersType.Add(flower1);
                    context.FlowersType.Add(flower2);
                    context.FlowersType.Add(flower3);
                    context.Flowers.Add(flowerPlot1);
                    context.Flowers.Add(flowerPlot2);
                    context.Flowers.Add(flowerPlot3);

                    context.Complete();
                }
                catch (Exception)
                {
                    LogManager.GetLogger("Server").Debug("Error with adding to base.");
                }
                   
            }
        }
      }
  }
