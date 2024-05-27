using MongoDB.Bson.Serialization.Attributes;

namespace SimplifiedPaymentsPlatform.Domain.Entities;

public class Transfer : BaseEntity
{
    [BsonElement("value")]
    public decimal Value { get; set; }

    [BsonElement("payer_id")]
    public string PayerId { get; set; }

    [BsonElement("payee_id")]
    public string PayeeId { get; set; }
    
    [BsonElement("created_at")]
    [BsonRepresentation(MongoDB.Bson.BsonType.DateTime)]
    public DateTime CreatedAt { get; set; } = DateTime.Now;
}