using SimplifiedPaymentsPlatform.Application.Responses.HttpResponses;
using SimplifiedPaymentsPlatform.Application.Services.Interface;
using System.Net.Http.Json;

namespace SimplifiedPaymentsPlatform.Infrastructure.Services;

public class TransferValidationService : ITransferValidationService
{
    private readonly HttpClient _httpClient;

    public TransferValidationService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task Authorize()
    {
        var transfer = await _httpClient.GetFromJsonAsync<AuthorizedTransferResponse>("");

        if (!transfer.Authorized) throw new InvalidOperationException("Transação não autorizada!");
    } 
}
