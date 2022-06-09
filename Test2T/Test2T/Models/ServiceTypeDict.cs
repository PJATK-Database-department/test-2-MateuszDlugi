using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Test2T.Models
{
    public class ServiceTypeDict
    {
        public ServiceTypeDict()
        {
            ServiceTypeDict_Inspection = new HashSet<ServiceTypeDict_Inspection>();
        }
        [Key]
        public int IdServiceType { get; set; }
        [Required]
        [MaxLength(20)]
        public string ServiceType { get; set; }
        [Required]
        public float Price { get; set; }

        public virtual ICollection<ServiceTypeDict_Inspection> ServiceTypeDict_Inspection { get; set; }
    }
}
