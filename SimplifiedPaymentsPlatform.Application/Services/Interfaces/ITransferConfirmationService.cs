namespace SimplifiedPaymentsPlatform.Application.Services.Interface;

public interface ITransferConfirmationService
{
    Task Confirmation(decimal transferValue);
}