
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using practice_proyect.Context;
using practice_proyect.Model;

namespace practice_proyect.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleController : ControllerBase
    {
        private readonly FirstContext _firstContext;

        public VehicleController(FirstContext firstContext) {
            _firstContext = firstContext;
        }

        [HttpGet]
        public async Task<ActionResult> findALL() {
            return Ok(await _firstContext.Vehicles.ToListAsync());
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult> findOne(int id) {
            return Ok(await _firstContext.Vehicles.FindAsync(id));
        }

        [HttpPost]
        public async Task<ActionResult> save([FromBody] Vehicle v) {
            _firstContext.Vehicles.Add(v);
            await _firstContext.SaveChangesAsync();
            return Ok(v);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> update(Vehicle v, int id) {
            _firstContext.Entry(v).State = EntityState.Modified;
            await _firstContext.SaveChangesAsync();
            return Ok(v);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> delete(int id) {
            var find = await _firstContext.Vehicles.FindAsync(id);
            if (find is null) return NotFound();
            _firstContext.Vehicles.Remove(find);
            await _firstContext.SaveChangesAsync();
            return NoContent();
        }

    }
}
