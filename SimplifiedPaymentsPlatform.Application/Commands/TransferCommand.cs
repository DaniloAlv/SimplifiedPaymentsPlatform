using MediatR;

namespace SimplifiedPaymentsPlatform.Application.Commands;

public class TransferCommand : IRequest
{
    public decimal Value { get; set; }
    public string PayerId { get; set; }
    public string PayeeId { get; set; }
}