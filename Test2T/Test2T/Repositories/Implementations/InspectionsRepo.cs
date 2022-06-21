using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test2T.DTOs;
using Test2T.Models;
using Test2T.Repositories.Interfaces;

namespace Test2T.Repositories.Implementations
{
    public class InspectionsRepo : IInspectionsRepo
    {
        private readonly Context context;

        public InspectionsRepo(Context context)
        {
            this.context = context;
        }
        public async Task<InspectionDto> GetInspectionAsyc(int id)
        {
            var inspection = await context.Inspection.FindAsync(id);

            if (inspection == null)
                return null;

            InspectionDto inspectionDto = await context
                .Inspection
                .Where(e => e.IdInspection == id)
                .Select(e => new InspectionDto
                {
                    CarName = e.IdCarNav.Name,
                    CarProductionYear = e.IdCarNav.ProductionYear,
                    MechanicFirstName = e.IdMechanicNav.FirstName,
                    MechanicLastName = e.IdMechanicNav.LastName,
                    
                    /*ServiceTypeDict = e.ServiceTypeDict_Inspection.Select(e => new ServiceTypeDictDto
                    {
                        IdServiceType = e.IdServiceType.,
                        ServiceType = e.ServiceType,
                        Price = e.Price
                    })*/
                }).FirstAsync();

            return inspectionDto;
        }
    }
}
