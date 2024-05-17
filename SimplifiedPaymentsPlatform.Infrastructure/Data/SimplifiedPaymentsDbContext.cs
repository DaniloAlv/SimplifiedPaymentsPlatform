using MongoDB.Driver;
using SimplifiedPaymentsPlatform.Domain.Entities;

namespace SimplifiedPaymentsPlatform.Infrastructure.Data;

public class SimplifiedPaymentsDbContext
{
    private readonly IMongoDatabase _mongoDatabase;
    private readonly IMongoClient _mongoClient;

    public SimplifiedPaymentsDbContext(string connectionString, string databaseName)
    {
        _mongoClient = new MongoClient(connectionString);
        _mongoDatabase = _mongoClient.GetDatabase(databaseName);
    }

    public IMongoCollection<Transfer> Transfers => _mongoDatabase.GetCollection<Transfer>("transfers");
    public IMongoCollection<User> Users => _mongoDatabase.GetCollection<User>("users");

    
    public async Task<IClientSessionHandle> StartSessionAsync()
    {
        return await _mongoClient.StartSessionAsync();
    }
}