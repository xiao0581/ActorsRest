using ActorRepositoryLib;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

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
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [HttpGet]
        public ActionResult<IEnumerable<Actor>> Get([FromHeader] string? amount, [FromHeader] int startIndex,
            [FromQuery] string? nameFilter, [FromQuery] int? minBirthYear)
        {
            IEnumerable<Actor> actorList =
                _actorsRepository.Get(nameFilter, minBirthYear, null, null);

            //if (amount != null)
            //{
            //    if (int.TryParse(amount, out int count))
            //    {
            //        actorList = actorList.Skip(startIndex).Take(count);
            //    }
            //    else
            //    {
            //        return BadRequest("Amount must be a number");
            //    }
            //}
            //else {

            //    return BadRequest("Amount not fill in");
            //}
           
            if (actorList.Any())
            {
                Response.Headers.Add("TotalCount", "" + actorList.Count());
                return Ok(actorList);
            }
            else
            {
                return NoContent();
            }
        
        }


            // GET api/<ActorsController>/5
            [HttpGet("{id}")]
        public Actor? Get(int id)
        {
            return _actorsRepository.GetById(id);
        }

        // POST api/<ActorsController>
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost]
        public ActionResult<Actor> Post([FromBody] Actor newActor)
        {
            try
            {
                Actor createdActor = _actorsRepository.Add(newActor);
                return Created("/" + createdActor.Id, createdActor);
            }
            catch (Exception ex) when (ex is ArgumentNullException ||
                               ex is ArgumentOutOfRangeException)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<ActorsController>/5
        [HttpPut("{id}")]
        public Actor? Put(int id, [FromBody] Actor updatedActor)
        {
            return _actorsRepository.Update(id, updatedActor);
        }

        // DELETE api/<ActorsController>/5
        [HttpDelete("{id}")]
        public Actor? Delete(int id)
        {
            return _actorsRepository.Delete(id);
        }
    }
}
