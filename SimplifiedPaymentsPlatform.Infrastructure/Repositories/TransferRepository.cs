using MongoDB.Driver;
using SimplifiedPaymentsPlatform.Domain.Entities;
using SimplifiedPaymentsPlatform.Domain.Repositories;
using SimplifiedPaymentsPlatform.Infrastructure.Data;

namespace SimplifiedPaymentsPlatform.Infrastructure.Repositories;

public class TransferRepository : ITransferRepository
{
    private readonly SimplifiedPaymentsDbContext _context;

    public TransferRepository(SimplifiedPaymentsDbContext context)
    {
        _context = context;
    }

    public async Task CreateWithTransactionAsync(IClientSessionHandle sessionHandle, Transfer transfer)
    {
        await _context.Transfers.InsertOneAsync(sessionHandle, transfer);
    }
}