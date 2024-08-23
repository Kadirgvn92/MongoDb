using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace MongoDb.Entities;

public class Customer
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string CustomerId { get; set; }
    public string FullName { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }

    // Müşterinin siparişleri (isteğe bağlı)
    public List<Order> Orders { get; set; } = new List<Order>();
}