using SimplifiedPaymentsPlatform.Application.Responses.HttpResponses;

namespace SimplifiedPaymentsPlatform.Application.Services.Interface;

public interface ITransferValidationService
{
    Task<AuthorizedTransferResponse?> Authorize();
}