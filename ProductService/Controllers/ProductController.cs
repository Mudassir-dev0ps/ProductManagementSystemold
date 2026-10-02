using Microsoft.AspNetCore.Mvc;
using ProductService.Models;
using ProductService.Repository;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProductService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ProductRepository _repo;

        public ProductController(ProductRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public ActionResult<List<Product>> GetAll() => _repo.GetAll();

        [HttpGet("{id}")]
        public ActionResult<Product> GetById(int id)
        {
            var product = _repo.GetById(id);
            return product == null ? NotFound() : Ok(product);
        }

        [HttpPost]
        public ActionResult<Product> Add(Product product)
        {
            var newProduct = _repo.Add(product);
            return CreatedAtAction(nameof(GetById), new { id = newProduct.Id }, newProduct);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Product product)
        {
            if (id != product.Id) return BadRequest("ID mismatch");

            var success = _repo.Update(product);
            return success ? NoContent() : NotFound();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var success = _repo.Delete(id);
            return success ? NoContent() : NotFound();
        }
    }
}
