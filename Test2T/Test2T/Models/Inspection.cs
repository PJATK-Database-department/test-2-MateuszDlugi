using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Test2T.Models
{
    public class Inspection
    {
        public Inspection()
        {
            ServiceTypeDict_Inspection = new HashSet<ServiceTypeDict_Inspection>();
        }
        [Key]
        public int IdInspection { get; set; }
        [Required]
        public int IdCar { get; set; }
        [Required]
        public int IdMechanic { get; set; }
        [Required]
        public DateTime InspectionDate { get; set; }
        [MaxLength(300)]
        public string Comment { get; set; }

        public virtual Car IdCarNav { get; set; }
        public virtual Mechanic IdMechanicNav { get; set; }

        public virtual ICollection<ServiceTypeDict_Inspection> ServiceTypeDict_Inspection { get; set; }
    }
}
