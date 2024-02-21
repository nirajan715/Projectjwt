using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using trytryuntilyoudie7.Data;
using trytryuntilyoudie7.Models;

namespace trytryuntilyoudie7.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly AppDbContext _context;

        public OrderController(AppDbContext context)
        {
            _context = context;
        }
        //Get Orders
        [HttpGet("order")]
        public List<Order> GetOrders()
        {
            return _context.Orders.ToList();
        }

        //Create Order  
        [HttpPost("create")]
        public string CreateProduct([FromBody] Order product)
        {

            _context.Orders.Add(product);
            _context.SaveChanges();
            return "Product added successfully";
        }



        //Delete Order
        [HttpDelete("delete")]
        public string RemoveProduct([FromBody] Product product)
        {
            Product prod = _context.Products.FirstOrDefault(m => m.Id == product.Id);
            if (prod != null)
            {
                _context.Products.Remove(product);
                _context.SaveChanges();

                return "Removed successfully";
            }
            return "There is no product";
        }
    }
}
