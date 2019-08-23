using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConFusion.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ConFusion.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DishesController : ControllerBase
    {
        private readonly IConFusionRepository repository;

        public DishesController(IConFusionRepository repository)
        {
            this.repository = repository;
        }
        // GET api/values
        [HttpGet]
        public async Task<ActionResult<Dishes[]>> Get()
        {
             var dishes = await repository.GetAllDishesAsync();
            return dishes ;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public async Task<ActionResult<Dishes>> Post(Dishes dish)
        {
            try
            {
                
                
                    this.repository.Add(dish);
                if (await this.repository.SaveChangesAsync())
                {
                    return Created("", dish);
                }
            }
            catch(Exception e)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Post Failure" + e);
            }
            return BadRequest();

        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var selectedDish = await repository.GetDishAsync(id);
                if (selectedDish == null) return NotFound("Dish not found to delete");

                repository.Delete(selectedDish);
                if (await repository.SaveChangesAsync())
                {
                    return Ok();
                }
            }
            catch (Exception e)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Delete Dish Failure" + e);
            }
            return BadRequest();
        }
    }
}
