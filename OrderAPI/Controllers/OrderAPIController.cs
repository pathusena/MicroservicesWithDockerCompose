using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using OrderAPI.Models;

namespace OrderAPI.Controllers
{
    [Route("api/order")]
    [ApiController]
    public class OrderAPIController : ControllerBase
    {
        private readonly IMongoCollection<Order> _ordersCollection;
        public OrderAPIController()
        {
            var dbHost = Environment.GetEnvironmentVariable("DB_HOST");
            var dbName = Environment.GetEnvironmentVariable("DB_NAME");
            var connctionString = $"mongodb://{dbHost}:27017/{dbName}";

            var mongoUrl = MongoUrl.Create(connctionString);
            var mongoclient = new MongoClient(mongoUrl);
            var database = mongoclient.GetDatabase(mongoUrl.DatabaseName);

            _ordersCollection = database.GetCollection<Order>("order");
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Order>>> GetOrders()
        {
            return await _ordersCollection.Find(Builders<Order>.Filter.Empty).ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Order>> GetOrder(string id)
        {
            var filter = Builders<Order>.Filter.Eq(x => x.OrderId, id);
            return await _ordersCollection.Find(filter).SingleOrDefaultAsync();
        }

        [HttpPost]
        public async Task<ActionResult> SaveOrder(Order order)
        {
            await _ordersCollection.InsertOneAsync(order);
            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult> UpdateOrder(Order order)
        {
            var filter = Builders<Order>.Filter.Eq(x => x.OrderId, order.OrderId);
            await _ordersCollection.ReplaceOneAsync(filter, order);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> UpdateOrder(string id)
        {
            var filter = Builders<Order>.Filter.Eq(x => x.OrderId, id);
            await _ordersCollection.DeleteOneAsync(filter);
            return Ok();
        }
    }
}
