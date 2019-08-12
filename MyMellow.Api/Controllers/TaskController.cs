using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyMellow.Infrastructure;

namespace MyMellow.Api.Controllers
{
    [ApiController]
    [Route("api/tasks")]
    public class TaskController: ControllerBase 
    {
        private readonly MyMellowContext _context;

        public TaskController(MyMellowContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Domain.Models.Task>>> Get()
        {
            var tasks = await _context.Task.ToListAsync();

            return Ok(tasks);
        }

        [HttpPost]
        public async Task<ActionResult<Domain.Models.Task>> Create([FromBody] Domain.Models.Task task)
        {
            _context.Task.Add(task);
            await _context.SaveChangesAsync();

            return Ok(task);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Domain.Models.Task>> Update(int id, [FromBody] Domain.Models.Task task)
        {
            if (id != task.Id)
            {
                return BadRequest();
            }

            var update = await _context.Task.FindAsync(id);

            if (update == null)
            {
                return NotFound();
            }

            update.Name = task.Name;

            await _context.SaveChangesAsync();

            return Ok(update);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Domain.Models.Task>> Delete(int id)
        {
            var task = await _context.Task.FindAsync(id);

            if (task == null)
            {
                return NotFound();
            }

            _context.Task.Remove(task);

            await _context.SaveChangesAsync();

            return Ok();
        }


    }
}
