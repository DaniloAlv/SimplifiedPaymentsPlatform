using System.Text.Json;
using Polly;
using Polly.Extensions.Http;
using Polly.Timeout;
using SimplifiedPaymentsPlatform.Application.Responses.HttpResponses;

namespace SimplifiedPaymentsPlatform.API.Extensions;

public static class PollyExtensions
{
    public static IAsyncPolicy<HttpResponseMessage> BuildRetryPolicy()
    {
        return HttpPolicyExtensions
            .HandleTransientHttpError()
            .Or<TimeoutRejectedException>()
            .OrResult(result => 
            {
                var responseStream = result.Content.ReadAsStream();
                var authorizeResonse = JsonSerializer.Deserialize<AuthorizedTransferResponse>(responseStream);

                return !authorizeResonse.Authorized;
            })
            .WaitAndRetryAsync(5, retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)));
    }

    public static IAsyncPolicy<HttpResponseMessage> RequestTimeout() => Policy.TimeoutAsync<HttpResponseMessage>(10);
}