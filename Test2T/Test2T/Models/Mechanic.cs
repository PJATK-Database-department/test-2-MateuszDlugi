using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Test2T.Models
{
    public class Mechanic
    {
        public Mechanic()
        {
            Inspection = new HashSet<Inspection>();
        }
        [Key]
        public int IdMechanic { get; set; }
        [Required]
        [MaxLength(20)]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(30)]
        public string LastName { get; set; }

        public virtual ICollection<Inspection> Inspection { get; set; }
    }
}
