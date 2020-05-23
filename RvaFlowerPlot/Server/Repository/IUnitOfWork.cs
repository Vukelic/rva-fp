using Common;
using System;

namespace Server
{ 
    public interface IUnitOfWork : IDisposable
    {
        IRepository<User> Users { get; }
        IRepository<FlowerPlotIteration> Flowers { get; }
        IRepository<Flower> FlowersType { get; }
        IRepository<SoilType> Soils { get; }
        void DeleteDatabase();
        int Complete();
        bool NotExists();
    }
}