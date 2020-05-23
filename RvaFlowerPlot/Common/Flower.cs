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
    [DataContract]
    public class Flower
    {
        [DataMember]
        [Key]
        public string FlowerName { get; set; }
        public override string ToString()
        {
            return this.FlowerName;
        }
    }
}
