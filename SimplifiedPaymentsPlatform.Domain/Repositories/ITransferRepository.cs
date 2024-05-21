using MongoDB.Driver;
using SimplifiedPaymentsPlatform.Domain.Entities;

namespace SimplifiedPaymentsPlatform.Domain.Repositories;

public interface ITransferRepository
{
    Task CreateWithTransactionAsync(IClientSessionHandle sessionHandle, Transfer transfer);
}