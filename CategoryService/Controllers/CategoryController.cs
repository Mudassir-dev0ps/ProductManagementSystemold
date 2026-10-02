using CategoryService.Models;
using CategoryService.Repository;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CategoryService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly CategoryRepository _repo;

        public CategoryController(CategoryRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public ActionResult<List<Category>> GetAll() => _repo.GetAll();

        [HttpGet("{id}")]
        public ActionResult<Category> GetById(int id)
        {
            var category = _repo.GetById(id);
            return category == null ? NotFound() : Ok(category);
        }
    }
}
