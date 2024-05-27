using MongoDB.Driver;

namespace SimplifiedPaymentsPlatform.Domain.Repositories;

public interface IBaseRepository
{
    Task<IClientSessionHandle> StartSessionAsync();
}