using MongoDB.Bson.Serialization.Attributes;

namespace SimplifiedPaymentsPlatform.Domain.Entities;

public class Wallet
{
    public Wallet(decimal balance)
    {
        AvailableBalance = balance;
    }
    
    [BsonElement("balance")]
    public decimal AvailableBalance { get; set; }


    public void IncreaseBalance(decimal transferValue)
    {
        AvailableBalance += transferValue;
    }

    public void DecreaseBalance(decimal transferValue)
    {
        AvailableBalance -= transferValue;
    }
}