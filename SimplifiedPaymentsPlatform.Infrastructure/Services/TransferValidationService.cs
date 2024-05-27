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

    public async Task Authorize() => await _httpClient.GetFromJsonAsync<AuthorizedTransferResponse>("");
}
