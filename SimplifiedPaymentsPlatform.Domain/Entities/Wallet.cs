namespace SimplifiedPaymentsPlatform.Domain.Entities;

public class Wallet : BaseEntity
{
    public decimal AvailableBalance { get; set; }
    public Guid UserId { get; set; }
}