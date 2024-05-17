using MongoDB.Driver;
using SimplifiedPaymentsPlatform.Domain.Entities;

namespace SimplifiedPaymentsPlatform.Domain.Repositories;

public interface IUserRepository
{
    Task<User> GetByIdAsync(string id);
    Task<IEnumerable<User>> GetUsersByIds(params string[] ids);
    Task Register(User user);
    Task UpdateAsync(FilterDefinition<User> filterDefinition, UpdateDefinition<User> updateDefinition);
    Task UpdateWithTransactionAsync(IClientSessionHandle session, FilterDefinition<User> filterDefinition, UpdateDefinition<User> updateDefinition);
}