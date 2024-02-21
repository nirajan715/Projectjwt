using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using trytryuntilyoudie7.Data;
using trytryuntilyoudie7.Models;

namespace trytryuntilyoudie7.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CategoryController(AppDbContext context)
        {
            _context = context;
        }


        //Get Category
        [HttpGet]
        public List<Category> GetCategory()
        {
            return _context.Categories.ToList();
        }

        //Create Category
        [HttpPost]
        public string CreateCategory([FromBody] Category category)
        {

            _context.Categories.Add(category);
            _context.SaveChanges();
            return "Category created successfully";
        }

        //Update Product
        [HttpPut]
        public string UpdateCategory([FromBody] Category category, int categoryId)
        {
            Category cat = _context.Categories.FirstOrDefault(m => m.Id == categoryId);
            if (cat != null)
            {
                _context.Categories.Update(category);
                _context.SaveChanges();

                return "Updated successfully";
            }
            return "There is no category";
        }


        //Delete Category   
        [HttpDelete]
        public string RemoveCategory([FromBody] Category category)
        {
            Category cat = _context.Categories.FirstOrDefault(m => m.Id == category.Id);
            if (cat != null)
            {
                _context.Categories.Remove(category);
                _context.SaveChanges();

                return "Removed successfully";
            }
            return "There is no category";
        }
    }
}
