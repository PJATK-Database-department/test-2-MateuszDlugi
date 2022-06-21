using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Test2T.Models
{
    public class Car
    {
        public Car()
        {
            Inspection = new HashSet<Inspection>();
        }
        [Key]
        public int IdCar { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [Required]
        public int ProductionYear { get; set; }

        public virtual ICollection<Inspection> Inspection { get; set; }
    }
}
