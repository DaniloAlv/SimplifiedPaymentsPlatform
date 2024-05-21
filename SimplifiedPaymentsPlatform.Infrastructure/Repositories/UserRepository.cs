using MongoDB.Driver;
using SimplifiedPaymentsPlatform.Domain.Entities;
using SimplifiedPaymentsPlatform.Domain.Repositories;
using SimplifiedPaymentsPlatform.Infrastructure.Data;

namespace SimplifiedPaymentsPlatform.Infrastructure.Repositories;

public class UserRepository : IUserRepository
{
    private readonly SimplifiedPaymentsDbContext _context;

    public UserRepository(SimplifiedPaymentsDbContext context)
    {
        _context = context;
    }

    public async Task<User> GetByIdAsync(string id)
    {        
        var filter = Builders<User>.Filter.Eq(u => u.Id, id);
        var userFound = await _context.Users.FindAsync(filter);
        return userFound.FirstOrDefault();
    }

    public async Task Register(User user)
    {
        await _context.Users.InsertOneAsync(user);
    }

    public async Task<IList<User>> GetUsersByIds(params string[] ids)
    {
        var filterDefinition = Builders<User>.Filter.In(u => u.Id, ids);
        var users = (await _context.Users.FindAsync(filterDefinition)).ToList();

        return users;
    }

    public async Task UpdateAsync(FilterDefinition<User> filterDefinition, UpdateDefinition<User> updateDefinition)
    {
        await _context.Users.UpdateOneAsync(filterDefinition, updateDefinition);
    }

    public async Task UpdateWithTransactionAsync(IClientSessionHandle session, FilterDefinition<User> filterDefinition, UpdateDefinition<User> updateDefinition)
    {
        await _context.Users.UpdateOneAsync(session, filterDefinition, updateDefinition);
    }
}
