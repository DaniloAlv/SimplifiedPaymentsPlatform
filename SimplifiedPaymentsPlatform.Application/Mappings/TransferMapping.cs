using SimplifiedPaymentsPlatform.Application.Commands;
using SimplifiedPaymentsPlatform.Domain.Entities;

namespace SimplifiedPaymentsPlatform.Application.Mappings;

public static class TransferMapping
{
    public static Transfer CommandToTransfer(this TransferCommand command)
    {
        return new Transfer
        {
            PayeeId = command.PayeeId, 
            PayerId = command.PayerId,
            Value = command.Value,
        };
    }
}