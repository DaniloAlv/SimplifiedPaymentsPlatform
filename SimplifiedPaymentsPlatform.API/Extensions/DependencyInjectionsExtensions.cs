using SimplifiedPaymentsPlatform.Application.Services.Validators.TransferValidator;
using SimplifiedPaymentsPlatform.Domain.Repositories;
using SimplifiedPaymentsPlatform.Domain.Services;
using SimplifiedPaymentsPlatform.Infrastructure.Repositories;
using SimplifiedPaymentsPlatform.Infrastructure.Strategies;
using SimplifiedPaymentsPlatform.Infrastructure.Strategies.Context;

namespace SimplifiedPaymentsPlatform.API.Extensions;

public static class DependencyInjectionsExtension
{
    public static IServiceCollection AddDependencyInjections(this IServiceCollection services)
    {
        services.AddScoped<ITransferRepository, TransferRepository>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IBaseRepository, BaseRepository>();

        services.AddScoped<IUserDocumentValidator, UserDocumentValidator>();
        services.AddTransient<ITransferValidator, TransferValidator>();

        services.AddTransient<CommonUserStrategy>();
        services.AddTransient<SellerUserStrategy>();

        return services;
    }
}