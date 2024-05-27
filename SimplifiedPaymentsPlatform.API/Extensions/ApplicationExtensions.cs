using SimplifiedPaymentsPlatform.Application;
using SimplifiedPaymentsPlatform.Infrastructure.Data;

namespace SimplifiedPaymentsPlatform.API.Extensions;

public static class ApplicationExtensions
{
    public static IServiceCollection AddApplication(this IServiceCollection services, ConfigurationManager configuration)
    {
        services.AddSingleton(provider =>
        {
            string connectionString = configuration.GetConnectionString("MongoDB");
            string databaseName = configuration
                .GetSection("MongoDBSettings").GetValue<string>("DatabaseName");

            return new SimplifiedPaymentsDbContext(connectionString, databaseName);
        });

        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(ApplicationAssemblyReference).Assembly));

        return services;
    }
}