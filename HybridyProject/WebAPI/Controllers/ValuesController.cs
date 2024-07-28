using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IMyClass _service;
        public ValuesController(IMyClass classService)
        {
            _service = classService;
        }

        [HttpPost]
        public async Task<ActionResult> Create(MyClass myClass)
        {
            try
            {
                if (myClass == null)
                {
                    return BadRequest("No product found");
                }
                _service.CreateMyClass(myClass);
                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                                "Error retrieving data from the database");
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, MyClass myClass)
        {
            try
            {
                if (myClass == null || id<=0 )
                    return BadRequest("My Class not found");

                _service.UpdateMyClass(myClass);
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
                   var entity =  _service.GetMyClass(id);
                    if (entity == null)
                    {
                        return NotFound();
                    }
                    _service.DeleteMyClass(entity);
                    return Ok();
                }
                else
                {
                    return NotFound("Product not found in database");
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                                "Error retrieving data from the database");
            }
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MyClass>>> GetAll()
        {
            try
            {
                var products = _service.GetAll();

                if (products == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(products);
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                                "Error retrieving data from the database");

            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<MyClass>> GetById(int id)
        {
            try
            {
                var product = _service.GetMyClass(id);

                if (product == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(product);
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