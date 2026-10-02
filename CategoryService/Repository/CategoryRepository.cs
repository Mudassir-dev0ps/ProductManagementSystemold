using CategoryService.Models;

namespace CategoryService.Repository
{
    public class CategoryRepository
    {
        private static readonly List<Category> Categories = new()
        {
            new Category { Id = 1, Name = "Electronics" },
            new Category { Id = 2, Name = "Clothing" },
            new Category { Id = 3, Name = "Books" }
        };

        public List<Category> GetAll() => Categories;
        public Category? GetById(int id) => Categories.FirstOrDefault(c => c.Id == id);
    }
}
