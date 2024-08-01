using Microsoft.AspNetCore.Mvc;
using ShopSol.Aplication.Dto.Product;
using ShopSol.Aplication.Interfaces;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ShopSol.Api.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService productService;

        public ProductController(IProductService productService)
        {
            this.productService = productService;
        }
        // GET: api/<ProductController>
        [HttpGet ("GetProduct")]
        public IActionResult GetProducts()
        {
            var result = this.productService.GetProducts();


            if (!result.Success)
            {
                return BadRequest(result);
            }
            else
            {
                return Ok(result);
            }
        }

        // GET api/<ProductController>/5
        [HttpGet("GetProductById")]
        public IActionResult Get(int id)
        {
            var result = this.productService.GetProduct(id);

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        // POST api/<ProductController>
        [HttpPost]
        public IActionResult Post([FromBody] ProductSaveDto productSaveDto)
        {
            var result = this.productService.SaveProducts(productSaveDto);

            if (!result.Success)
                return BadRequest(result);


            return Ok(result);
        }

        // PUT api/<ProductController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ProductController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
