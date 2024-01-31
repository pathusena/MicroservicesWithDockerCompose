using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace OrderAPI.Models
{
    public class Order
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? OrderId { get; set; }

        [BsonElement("customer_id"), BsonRepresentation(BsonType.Int32)]
        public int CustomerId { get; set; }

        [BsonElement("customer_name"), BsonRepresentation(BsonType.String)]
        public string CustomerName { get; set; }

        [BsonElement("order_date"), BsonRepresentation(BsonType.DateTime)]
        public DateTime OrderDate { get; set; }

        [BsonElement("order_details")]
        public List<OrderDetail> OrderDetails { get; set; }
    }
}
