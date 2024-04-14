namespace SimplifiedPaymentsPlatform.Domain.Entities;

public class Transaction : BaseEntity
{
    public decimal Value { get; set; }
    public Guid PayerId { get; set; }
    public Guid PayeeId { get; set; }
    public DateTime CreatedAt { get; set; }
}