using Microsoft.AspNetCore.Mvc;
using ShopSol.Aplication.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ShopSol.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SupplierController : ControllerBase

    {
        private readonly ISupplierService supplierService;

        public SupplierController(ISupplierService supplierService)
        {
            this.supplierService = supplierService;
        }
        // GET: api/<SupplierController>
        [HttpGet]
        public IActionResult Get()
        {
            var result = this.supplierService.GetSuppliers();

            if (!result.Success)
                return BadRequest(result);
            else
                return Ok(result);
        }

        // GET api/<SupplierController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var result = this.supplierService.GetSupplier(id);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            else
            {
                return Ok(result);
            }
        }

        // POST api/<SupplierController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<SupplierController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<SupplierController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
