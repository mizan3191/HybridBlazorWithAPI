namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonsController : ControllerBase
    {
        private readonly IPerson _service;
        public PersonsController(IPerson person)
        {
            _service = person;
        }

        [HttpPost]
        public async Task<ActionResult> Create(Person person)
        {
            try
            {
                if (person == null)
                {
                    return BadRequest("No Person found");
                }
                _service.CreatePerson(person);
                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                                "Error retrieving data from the database");
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, Person person)
        {
            try
            {
                if (person == null || id <= 0)
                    return BadRequest("person not found");

                _service.UpdatePerson(person);
                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                                "Error retrieving data from the database");
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                if (id > 0)
                {
                    var entity = _service.GetPerson(id);
                    if (entity == null)
                    {
                        return NotFound();
                    }
                    _service.DeletePerson(entity);
                    return Ok();
                }
                else
                {
                    return NotFound("person not found in database");
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                                "Error retrieving data from the database");
            }
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Person>>> GetAll()
        {
            try
            {
                var persons = _service.GetAll();

                if (persons == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(persons);
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                                "Error retrieving data from the database");

            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Person>> GetById(int id)
        {
            try
            {
                var person = _service.GetPerson(id);

                if (person == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(person);
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                                "Error retrieving data from the database");
            }
        }
    }
}
