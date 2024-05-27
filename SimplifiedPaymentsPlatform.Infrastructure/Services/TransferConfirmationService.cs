using System.Globalization;
using System.Net.Http.Json;
using MediatR;
using SimplifiedPaymentsPlatform.Application.Responses.HttpResponses;
using SimplifiedPaymentsPlatform.Application.Services.Interface;
using SimplifiedPaymentsPlatform.Domain.Events;

namespace SimplifiedPaymentsPlatform.Infrastructure.Services;

public class TransferConfirmationService : ITransferConfirmationService
{
    private readonly HttpClient _httpClient;
    private readonly IMediator _mediator;

    public TransferConfirmationService(HttpClient httpClient,
                                       IMediator mediator)
    {
        _httpClient = httpClient;
        _mediator = mediator;
    }

    public async Task Confirmation(decimal transferValue)
    {
        var response = await _httpClient.GetFromJsonAsync<ReceivedTransferResponse?>("");

        if (!response.Received)
            throw new Exception("A transferência não pode ser recebida, por tanto foi cancelada.");

        string messageWithTransferValue = response.Message
            .Replace("VALUE", transferValue.ToString("C2", CultureInfo.GetCultureInfo("pt-BR")))
            .Replace("CREATED_AT", DateTimeOffset.Now.ToString("dd/MM/yyyy HH:mm:ss"));

        await _mediator.Publish(new CompletedTransferNotification(messageWithTransferValue));
    }
}