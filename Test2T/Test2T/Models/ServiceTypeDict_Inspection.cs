using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Test2T.Models
{
    public class ServiceTypeDict_Inspection
    {
        public int IdServiceType { get; set; }
        public int IdInspection { get; set; }
        [MaxLength(300)]
        public string Comments { get; set; }
    }
}
