
using Common;
using System.Collections.Generic;

namespace Server
{ 
    public class UnitOfWork : IUnitOfWork
    {
        private readonly Context _context;
        public UnitOfWork(Context context)
        {
            _context = context;
            Users = new Repository<User>(_context);
            Flowers = new Repository<FlowerPlotIteration>(_context);
            FlowersType = new Repository<Flower>(_context);
            Soils = new Repository<SoilType>(_context);
        }

        public IRepository<User> Users { get; private set; }
        public IRepository<FlowerPlotIteration> Flowers { get; private set; }
        public IRepository<Flower> FlowersType { get; private set; }
        public IRepository<SoilType> Soils { get; private set; }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public void DeleteDatabase()
        {
            _context.Database.Delete();
        }

        public bool NotExists()
        {
           
            if (_context.Database.Exists())
            {
                return true;
            }

            return false;
        }
    }
}