using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    class UserService : IUserDatabase
    {
        public bool AddUser(User user)
        {
            using (IUnitOfWork unit = new UnitOfWork(new Context()))
            {
                User u = unit.Users.Get(user.Username); 
                if (u == null) //ako takvav user ne postoji,dodaj
                {
                    unit.Users.Add(user);
                    unit.Complete();
                    return true;
                }
                return false;
            }
        }

        public bool Authenticate(string username, string password)
        {
            using (IUnitOfWork unit = new UnitOfWork(new Context()))
            {
                User user = unit.Users.Get(username);
                if (user == null)
                {
                    return false;
                }

                if (!user.Password.Equals(password))
                {
                    return false;
                }

                return true;
            }
        }

        public bool DeleteUser(string username)
        {
            using (IUnitOfWork unit = new UnitOfWork(new Context()))
            {
                User user = unit.Users.Get(username);
                if (user != null) //postoji obrisi
                {
                    unit.Users.Remove(user);
                    unit.Complete();
                    return true;
                }

                return false;
            }
        }

        public bool EditUser(User user)
        {
            using (IUnitOfWork unit = new UnitOfWork(new Context()))
            {
                User u = unit.Users.Get(user.Username);
                if (u != null)
                {
                    unit.Users.Remove(u);
                    unit.Users.Add(user);
                    unit.Complete();
                    return true;
                }
                return false;
            }
        }

        public List<User> GetAllUsers()
        {
            using (IUnitOfWork unit = new UnitOfWork(new Context()))
            {
                return new List<User>( unit.Users.GetAll() );
            }
        }

        public User GetUser(string username)
        {
            using (IUnitOfWork unit = new UnitOfWork(new Context()))
            {
                return unit.Users.Get(username);
            }
        }
    }
}
