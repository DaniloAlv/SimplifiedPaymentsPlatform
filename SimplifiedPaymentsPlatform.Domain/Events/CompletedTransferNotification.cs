using MediatR;

namespace SimplifiedPaymentsPlatform.Domain.Events;

public class CompletedTransferNotification : INotification
{
    public CompletedTransferNotification(string message)
    {
        Message = message;    
    }

    public string Message { get; set; }
}