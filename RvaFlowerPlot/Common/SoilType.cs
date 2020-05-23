using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    [DataContract]
    public class SoilType
    {
        [DataMember]
        [Key]
        public string SoilName { get; set; }

        [DataMember]
        public int ClayPercent { get; set; }

        [DataMember]
        public int SandPercent { get; set; }

        [DataMember]
        public int SiltPercent { get; set; }
        public override string ToString()
        {
            return this.SoilName + "[" + "Clay:" + this.ClayPercent + "%" +  " " + "Sand:" + this.SandPercent + "%" + " " + "Slit:" + this.SiltPercent + "%" +"]";
        }

    }
}
