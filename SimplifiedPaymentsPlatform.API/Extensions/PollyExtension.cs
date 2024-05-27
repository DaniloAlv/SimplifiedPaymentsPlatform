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
            .OrResult(result => CheckIfResponseIsValid<AuthorizedTransferResponse>(result))
            .OrResult(result => CheckIfResponseIsValid<ReceivedTransferResponse>(result))
            .WaitAndRetryAsync(5, retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)));
    }

    public static IAsyncPolicy<HttpResponseMessage> RequestTimeout() => Policy.TimeoutAsync<HttpResponseMessage>(10);

    private static bool CheckIfResponseIsValid<T>(HttpResponseMessage result)
    {
        var responseStream = result.Content.ReadAsStream();
        var response = JsonSerializer.Deserialize<T>(responseStream);

        var property = typeof(T)
            .GetProperties()
            .Where(prop => prop.PropertyType == typeof(bool))
            .First();

        // var instance = Activator.CreateInstance<T>();

        var value = (bool)property.GetValue(response);

        return !value;
    }
}