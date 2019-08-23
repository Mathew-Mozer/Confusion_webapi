using System;
using System.Threading.Tasks;
using ConFusion.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace ConFusion.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeadersController : ControllerBase
    {
        private readonly IConFusionRepository repository;

        public LeadersController(IConFusionRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<Leaders[]>> Get()
        {
            var Leaders = await repository.GetAllLeadersAsync();
            return Leaders;
        }

        [HttpPost]
        public async Task<ActionResult<Leaders>> Post(Leaders leader)
        {
            try
            {

                repository.Add(leader);
                if (await repository.SaveChangesAsync())
                {
                    return Created("", leader);
                }
            }
            catch (Exception e)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Post Leader Failure" + e);
            }
            return BadRequest();

        }
    }
}
