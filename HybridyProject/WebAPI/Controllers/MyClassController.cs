﻿namespace WebAPI.Controllers
{
    public class MyClassController : Controller
    {

        private readonly IMyClass _service;
        public MyClassController(IMyClass classService)
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
        public async Task<ActionResult> Update(MyClass myClass)
        {
            try
            {
                if (myClass == null)
                    return BadRequest("Product not found");

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
                    _service.DeleteMyClass(id);
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