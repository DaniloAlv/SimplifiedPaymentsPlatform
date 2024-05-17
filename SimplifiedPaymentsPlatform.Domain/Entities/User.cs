using MongoDB.Bson.Serialization.Attributes;
using SimplifiedPaymentsPlatform.Domain.Enums;

namespace SimplifiedPaymentsPlatform.Domain.Entities;

public class User : BaseEntity
{
    [BsonElement("name")]
    public string Name { get; set; }

    [BsonElement("document")]
    public string Document { get; set; }

    [BsonElement("type")]
    public UserType Type { get; set; }

    [BsonElement("email")]
    public string Email { get; set; }

    [BsonElement("password")]
    public string Password { get; set; }

    [BsonElement("wallet")]
    public Wallet Wallet { get; set; }
}