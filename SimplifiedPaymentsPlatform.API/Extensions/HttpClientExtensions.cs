using Polly;
using SimplifiedPaymentsPlatform.Application.Services.Interface;
using SimplifiedPaymentsPlatform.Infrastructure.Services;

namespace SimplifiedPaymentsPlatform.API.Extensions;

public static class HttpClientExtensions
{
    public static IServiceCollection AddHttpClientServices(this IServiceCollection services, ConfigurationManager configuration)
    {
        services
            .AddHttpClient<ITransferValidationService, TransferValidationService>(client => 
                ConfigureHttpClient(client, configuration, "EndpointValidateTransfer"))
            .AddResiliencePolicies();

        services
            .AddHttpClient<ITransferConfirmationService, TransferConfirmationService>(client =>
                ConfigureHttpClient(client, configuration, "EndpointReceivedTransfer"))
            .AddResiliencePolicies();

        return services;
    }


    private static void ConfigureHttpClient(HttpClient client, ConfigurationManager configuration, string endpointName)
    {
        string url = configuration.GetValue<string>(endpointName);
        client.BaseAddress = new Uri(url);
        client.Timeout = TimeSpan.FromSeconds(60);
    }

    private static IHttpClientBuilder AddResiliencePolicies(this IHttpClientBuilder builder)
    {
        builder
            .AddPolicyHandler(PollyExtensions.BuildRetryPolicy())
            .AddPolicyHandler(PollyExtensions.RequestTimeout())
            .AddTransientHttpErrorPolicy(policy => policy.CircuitBreakerAsync(5, TimeSpan.FromSeconds(30)));

        return builder;
    }
}