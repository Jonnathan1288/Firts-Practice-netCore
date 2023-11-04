using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using practice_proyect.Model;
using practice_proyect.Repository;

namespace practice_proyect.Controllers
{
    //[Route("api/[controller]")]
    [Route("api/[controller]")]
    [ApiController]
    public class ParentController : ControllerBase
    {
        private readonly IParentRepository _repository;

        public ParentController(IParentRepository repository) {
            _repository = repository;
        }

        [HttpGet]
        [Route("find-all")]
        public async Task<ActionResult> findAll()
        {
            return Ok(await _repository.FindAllAsync());
        }

        [HttpPost]
        [Route("save")]
        public async Task<ActionResult> save(Parent p) {
            return Ok(await _repository.CreateAsync(p));
        }

        [HttpGet]
        [Route("find-one/{id:int}")]
        public async Task<ActionResult> findOne(int id) {
            return Ok(await _repository.FindByIdAsync(id));
        }

        [HttpPut]
        [Route("update")]
        public async Task<ActionResult> updateAsync(Parent p) {
            return Ok(await _repository.UpdateAsync(p));
        }

        /*[HttpPost]
        [Route("save-multiple")]
        public async Task<ActionResult> saveMultiple([FromBody] List<Parent> p) {
            return Ok(await _repository.saveMultipleAsync(p));
        }*/

    }
}
