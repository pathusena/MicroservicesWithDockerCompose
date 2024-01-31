using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace OrderAPI.Models
{

    [Serializable, BsonIgnoreExtraElements]
    public class OrderDetail
    {
        [BsonElement("product_id"), BsonRepresentation(BsonType.Int32)]
        public int ProductId { get; set; }

        [BsonElement("product_name"), BsonRepresentation(BsonType.String)]
        public string ProductName { get; set; }

        [BsonElement("qty"), BsonRepresentation(BsonType.Decimal128)]
        public decimal Qty { get; set; }

        [BsonElement("unit_price"), BsonRepresentation(BsonType.Decimal128)]
        public decimal UnitPrice { get; set; }
    }
}
