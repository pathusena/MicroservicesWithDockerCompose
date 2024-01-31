using CustomerAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CustomerAPI.Controllers
{
    [Route("api/customer")]
    [ApiController]
    public class CustomerAPIController : ControllerBase
    {
        private readonly ApplicationDBContext _dbContext;

        public CustomerAPIController(ApplicationDBContext dBContext)
        {
            _dbContext = dBContext;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Customer>>> GetCustomers()
        {
            return await _dbContext.Customers.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Customer>> GetCustomer(int id)
        {
            return await _dbContext.Customers.FindAsync(id);
        }

        [HttpPost]
        public async Task<ActionResult> SaveCustomer(Customer customer)
        {
            await _dbContext.Customers.AddAsync(customer);
            await _dbContext.SaveChangesAsync();
            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult> UpdateCustomer(Customer customer)
        {
            _dbContext.Customers.Update(customer);
            await _dbContext.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCustomer(int id)
        {
            var customer = await _dbContext.Customers.FindAsync(id);
            _dbContext.Customers.Remove(customer);
            return Ok();
        }
    }
}
