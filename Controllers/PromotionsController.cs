using System;
using System.Threading.Tasks;
using ConFusion.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace ConFusion.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PromotionsController : ControllerBase
    {
        private readonly IConFusionRepository repository;

        public PromotionsController(IConFusionRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<Promotions[]>> Get()
        {
            var Promotions = await repository.GetAllPromotionsAsync();
            return Promotions;
        }

        [HttpPost]
        public async Task<ActionResult<Promotions>> Post(Promotions leader)
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
