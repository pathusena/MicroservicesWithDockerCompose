using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductAPI.Models;

namespace ProductAPI.Controllers
{
    [Route("api/product")]
    [ApiController]
    public class ProductAPIController : ControllerBase
    {
        private readonly ApplicationDBContext _dbContext;
        public ProductAPIController(ApplicationDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
            return await _dbContext.Products.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            return await _dbContext.Products.FindAsync(id);
        }

        [HttpPost]
        public async Task<ActionResult> SaveProduct(Product customer)
        {
            await _dbContext.Products.AddAsync(customer);
            await _dbContext.SaveChangesAsync();
            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult> UpdateProduct(Product customer)
        {
            _dbContext.Products.Update(customer);
            await _dbContext.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteProduct(int id)
        {
            var customer = await _dbContext.Products.FindAsync(id);
            _dbContext.Products.Remove(customer);
            return Ok();
        }


    }
}
