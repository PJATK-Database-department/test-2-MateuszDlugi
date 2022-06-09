using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test2T.DTOs;

namespace Test2T.Repositories.Interfaces
{
    public interface IInspectionsRepo
    {
        Task<InspectionDto> GetInspectionAsyc(int id);
    }
}
