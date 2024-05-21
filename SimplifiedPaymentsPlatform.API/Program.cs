using SimplifiedPaymentsPlatform.Application;
using SimplifiedPaymentsPlatform.Application.Services.Interface;
using SimplifiedPaymentsPlatform.Application.Services.Validators.TransferValidator;
using SimplifiedPaymentsPlatform.Domain.Repositories;
using SimplifiedPaymentsPlatform.Domain.Services;
using SimplifiedPaymentsPlatform.Infrastructure.Data;
using SimplifiedPaymentsPlatform.Infrastructure.Repositories;
using SimplifiedPaymentsPlatform.Infrastructure.Services;
using SimplifiedPaymentsPlatform.Infrastructure.Strategies;
using SimplifiedPaymentsPlatform.Infrastructure.Strategies.Context;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton(provider => 
{
    string connectionString = builder.Configuration.GetConnectionString("MongoDB");
    string databaseName = builder.Configuration
        .GetSection("MondoDBSettings").GetValue<string>("DatabaseName");

    return new SimplifiedPaymentsDbContext(connectionString, databaseName);
});

builder.Services.AddScoped<ITransferRepository, TransferRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IBaseRepository, BaseRepository>();

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(ApplicationAssemblyReference).Assembly));

builder.Services.AddHttpClient<ITransferValidationService, TransferValidationService>(client => 
{
    string transferValidationUrl = builder.Configuration.GetValue<string>("EndpointValidateTransfer");
    client.BaseAddress = new Uri(transferValidationUrl);
    client.Timeout = TimeSpan.FromSeconds(10);
});

builder.Services.AddHttpClient<ITransferConfirmationService, TransferConfirmationService>(client => 
{
    string transferConfirmationUrl = builder.Configuration.GetValue<string>("EndpointReceivedTransfer");
    client.BaseAddress = new Uri(transferConfirmationUrl);
    client.Timeout = TimeSpan.FromSeconds(10);
});

builder.Services.AddScoped<IUserDocumentValidator, UserDocumentValidator>();

builder.Services.AddTransient<CommonUserStrategy>();
builder.Services.AddTransient<SellerUserStrategy>();

builder.Services.AddTransient<ITransferValidator, TransferValidator>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
