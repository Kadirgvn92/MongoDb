using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace MongoDb.Entities;

public class OrderItem
{
    [BsonRepresentation(BsonType.ObjectId)]
    public string ProductId { get; set; } 
    public string ProductName { get; set; }
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
    public decimal TotalPrice => Quantity * UnitPrice; 
}