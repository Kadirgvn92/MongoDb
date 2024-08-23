using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace MongoDb.Entities;

public class Order
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string OrderId { get; set; }

    [BsonRepresentation(BsonType.ObjectId)]
    public string CustomerId { get; set; } 

    public DateTime OrderDate { get; set; }
    public List<OrderItem> OrderItems { get; set; } 
    public decimal TotalAmount => OrderItems.Sum(item => item.TotalPrice); 
    public string OrderStatus { get; set; } 
    public string PaymentStatus { get; set; } 
}