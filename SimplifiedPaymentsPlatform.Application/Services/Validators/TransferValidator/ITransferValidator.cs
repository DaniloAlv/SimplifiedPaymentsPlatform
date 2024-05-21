using SimplifiedPaymentsPlatform.Application.Commands;

namespace SimplifiedPaymentsPlatform.Application.Services.Validators.TransferValidator;

public interface ITransferValidator
{
    Task CheckTransferIsValid(TransferCommand transfer);
}