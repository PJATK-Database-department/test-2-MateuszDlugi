using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test2T.Repositories.Interfaces;

namespace Test2T.Controllers
{
    [Route("api/inspection")]
    [ApiController]
    public class InspectionsController : ControllerBase
    {
        private readonly IInspectionsRepo repository;

        public InspectionsController(IInspectionsRepo repository)
        {
            this.repository = repository;
        }
        [HttpGet("inspection/{id}")]
        public async Task<IActionResult> GetInspection([FromRoute] int id)
        {
            var result = await repository.GetInspectionAsyc(id);

            if (result == null)
                return NoContent();

            return Ok(result);
        }
    }
}
