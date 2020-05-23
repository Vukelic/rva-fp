using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public enum UserTypes { ADMIN, REGULAR }

    [DataContract]
    public class User : BindableBase, IUserPrototype
    {
        [DataMember]
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string Username { get; set; }

        [DataMember]
        public string Password { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Lastname { get; set; }

        [DataMember]
        public UserTypes TypeUser { get; set; }

        public User Clone()
        {
            return new User()
            {
                Username = this.Username,
                Password = this.Password,
                Name = this.Name,
                Lastname = this.Lastname,
                TypeUser = this.TypeUser
            };
        }

        public void SaveProperties(User myUser)
        {
            this.Username = myUser.Username;
            this.Password = myUser.Password;
            this.Name = myUser.Name;
            this.Lastname = myUser.Lastname;
            this.TypeUser = myUser.TypeUser;
            OnPropertyChanged("Username");
            OnPropertyChanged("Password");
            OnPropertyChanged("Name");
            OnPropertyChanged("Lastname");
            OnPropertyChanged("TypeUser");
        }
    }
}
