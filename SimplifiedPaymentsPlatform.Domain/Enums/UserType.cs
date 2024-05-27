using MongoDB.Bson.Serialization.Attributes;

namespace SimplifiedPaymentsPlatform.Domain.Enums;

public enum UserType
{
    [BsonRepresentation(MongoDB.Bson.BsonType.String)]
    Common = 1,

    [BsonRepresentation(MongoDB.Bson.BsonType.String)]
    Seller = 2,
}