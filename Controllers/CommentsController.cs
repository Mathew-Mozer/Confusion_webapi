using System;
using System.Threading.Tasks;
using ConFusion.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace ConFusion.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly IConFusionRepository repository;

        public CommentsController(IConFusionRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<Comments[]>> Get()
        {
            var Comments = await repository.GetAllCommentsAsync();
            return Comments;
        }

        [HttpPost]
        public async Task<ActionResult<Dishes>> Post(Comments comment)
        {
            try
            {

                repository.Add(comment);
                if (await repository.SaveChangesAsync())
                {
                    return Created("", comment);
                }
            }
            catch (Exception e)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Post Comment Failure" + e);
            }
            return BadRequest();

        }
    }
}
