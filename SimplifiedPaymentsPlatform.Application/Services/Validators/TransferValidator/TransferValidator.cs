using SimplifiedPaymentsPlatform.Application.Commands;
using SimplifiedPaymentsPlatform.Application.Exceptions;
using SimplifiedPaymentsPlatform.Domain.Enums;
using SimplifiedPaymentsPlatform.Domain.Repositories;

namespace SimplifiedPaymentsPlatform.Application.Services.Validators.TransferValidator;

public class TransferValidator : ITransferValidator
{
    private readonly IUserRepository _userRepository;

    public TransferValidator(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task CheckTransferIsValid(TransferCommand transfer)
    {
        var usersOfTransfer = await _userRepository.GetUsersByIds(transfer.PayerId, transfer.PayeeId);

        var payer = usersOfTransfer.FirstOrDefault(u => u.Id == transfer.PayerId);
        var payee = usersOfTransfer.FirstOrDefault(u => u.Id == transfer.PayeeId);

        if (transfer.PayeeId == transfer.PayerId) throw new TransferDestinationException();

        if (payer?.Type == UserType.Seller) throw new UserTypeNotAllowedToTransferException();
        
        if (transfer.Value > payer?.Wallet.AvailableBalance || transfer.Value <= 0)
            throw new WalletBalanceInsufficientException();
    }
}