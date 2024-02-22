using ActorRepositoryLib;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ActorRest2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActorsController : ControllerBase
    {
        private IActorsRepository _actorsRepository;

        public ActorsController(IActorsRepository actorsRepository)
        {
            _actorsRepository = actorsRepository;
        }

        // GET: api/<ActorsController>
        [HttpGet]
        public IEnumerable<Actor> Get()
        {
            return _actorsRepository.Get(null,null,null,null);
        }

        // GET api/<ActorsController>/5
        [HttpGet("{id}")]
        public Actor? Get(int id)
        {
            return _actorsRepository.GetById(id);
        }

        // POST api/<ActorsController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ActorsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ActorsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
