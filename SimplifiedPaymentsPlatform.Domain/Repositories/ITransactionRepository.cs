using System.Transactions;

namespace SimplifiedPaymentsPlatform.Domain.Repositories;

public interface ITransactionRepository
{
    Task<Transaction> Create(Transaction transaction);
}