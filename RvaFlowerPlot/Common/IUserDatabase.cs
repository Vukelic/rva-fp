using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    [ServiceContract]
    public interface IUserDatabase
    {
        [OperationContract]
        bool Authenticate(string username, string password);

        [OperationContract]
        User GetUser(string username);

        [OperationContract]
        bool AddUser(User user);

        [OperationContract]
        bool EditUser(User user);

        [OperationContract]
        bool DeleteUser(string username);

        [OperationContract]
        List<User> GetAllUsers();
    }
}
