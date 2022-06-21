using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Test2T.DTOs
{
    public class InspectionDto
    {
        public string CarName { get; set; }
        public int CarProductionYear { get; set; }
        public string MechanicFirstName { get; set; }
        public string MechanicLastName { get; set; }
        public IEnumerable<ServiceTypeDictDto> ServiceTypeDict { get; set; }

    }
}
