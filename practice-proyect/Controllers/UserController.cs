using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using practice_proyect.Context;
using practice_proyect.Model;

namespace practice_proyect.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly FirstContext _firstContext;

        public UserController(FirstContext firstContext) {
            _firstContext = firstContext;
        }

        [HttpGet]
        public async Task<ActionResult> findAll(){
            return Ok(await _firstContext.Users.ToListAsync());
        }

        [HttpPost]
        public async Task<ActionResult> save(User u) {
            _firstContext.Users.Add(u);
            await _firstContext.SaveChangesAsync();
            return Ok(u);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult> findOne(int id) {
            var find = await _firstContext.Users.FindAsync(id);
            if (find is null) return NotFound();
            return Ok(find);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> update(User u, int id) {
            _firstContext.Entry(u).State = EntityState.Modified;
            await _firstContext.SaveChangesAsync();
            return Ok(u);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> delete(int id) {
            var find = await _firstContext.Users.FindAsync(id);
            if (find is null) return NotFound();
            _firstContext.Users.Remove(find);
            await _firstContext.SaveChangesAsync();
            return NoContent();
        }
    }
}
