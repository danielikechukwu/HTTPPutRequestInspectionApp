using HTTPPutRequestInspection.Models;
using HTTPPutRequestInspection.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HTTPPutRequestInspection.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ProductRepository _productRepository;

        public ProductsController(ProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
            var products = await _productRepository.GetProducts();

            return Ok(products);
        }

        // Update an Existing Product
        // PUT: api/Product/1
        [HttpPut("{Id}")]
        public async Task<ActionResult<Product>> PutProduct([FromRoute] int Id, [FromBody] Product product)
        {
            if (Id != product.Id)
            {
                return BadRequest();
            }

            var result = await _productRepository.UpdateProduct(product);

            if(result == null)
            {
                return NotFound();
            }

            return Ok(result);

        } 
    }
}
