using MongoDB.Driver;
using SimplifiedPaymentsPlatform.Domain.Repositories;
using SimplifiedPaymentsPlatform.Infrastructure.Data;

namespace SimplifiedPaymentsPlatform.Infrastructure.Repositories;

public class BaseRepository : IBaseRepository
{
    private readonly SimplifiedPaymentsDbContext _context;

    public BaseRepository(SimplifiedPaymentsDbContext context)
    {
        _context = context;
    }

    public async Task<IClientSessionHandle> StartSessionAsync()
    {
        return await _context.StartSessionAsync();
    }
}
