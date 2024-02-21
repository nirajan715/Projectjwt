using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using trytryuntilyoudie7.Data;
using trytryuntilyoudie7.Models;

namespace trytryuntilyoudie7.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ProductController(AppDbContext context)
        {
            _context = context;
        }

        //Get Product
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetAllProducts()
        {
            if (_context.Products == null)
            {
                return NotFound();
            }
            return await _context.Products.ToListAsync();
        }


        //Create Product
        [Authorize]
        [HttpPost("create")]
        public string CreateProduct([FromBody] Product product)
        {

            _context.Products.Add(product);
            _context.SaveChanges();
            return "Product added successfully";
        }

        //Update Product
        [HttpPut("update")]
        public string UpdateProduct([FromBody] Product product, int productId)
        {
            Product prod = _context.Products.FirstOrDefault(m => m.Id == productId);
            if (prod != null)
            {
                _context.Products.Update(product);
                _context.SaveChanges();

                return "Updated successfully";
            }
            return "There is no product";
        }



        //Delete Product
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            var student = await _context.Products.FindAsync(id);
            if (student == null)
            {
                return NotFound();
            }

            _context.Products.Remove(student);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
