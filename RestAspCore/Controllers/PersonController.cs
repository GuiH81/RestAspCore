using Microsoft.AspNetCore.Mvc;
using RestAspCore.Model;
using RestAspCore.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RestAspCore.Controllers
{
    [Route("api/[controller]")]
    public class PersonController : Controller
    {
        private IPersonService _personService;

        public PersonController(IPersonService personService) {
            _personService = personService;
        }
        // GET: api/<controller>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_personService.FindAll());

        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var person = _personService.FindById(id);

            if (person == null) return NotFound();
            return Ok(person);
        }

        // POST api/<controller>
        [HttpPost]
        public IActionResult Post([FromBody]Person person)
        {
            if (person == null) return NotFound();
            return new ObjectResult(_personService.Create(person));
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public IActionResult Put([FromBody]Person person)
        {
            if (person == null) return NotFound();
            return new ObjectResult(_personService.Update(person));
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _personService.Delete(id);
            return NoContent();
        }
    }
}
