using MediatR;
using SimplifiedPaymentsPlatform.Domain.Events;

namespace SimplifiedPaymentsPlatform.Application.NotificationHandlers;

public class CompletedTransferNotificationHandler : INotificationHandler<CompletedTransferNotification>
{
    public CompletedTransferNotificationHandler() { }

    public Task Handle(CompletedTransferNotification notification, CancellationToken cancellationToken)
    {
        Console.WriteLine(notification.Message);
        return Task.CompletedTask;
    }
}