using MediatR;
using MongoDB.Driver;
using SimplifiedPaymentsPlatform.Application.Commands;
using SimplifiedPaymentsPlatform.Application.Mappings;
using SimplifiedPaymentsPlatform.Application.Services.Interface;
using SimplifiedPaymentsPlatform.Application.Services.Validators.TransferValidator;
using SimplifiedPaymentsPlatform.Domain.Entities;
using SimplifiedPaymentsPlatform.Domain.Repositories;

namespace SimplifiedPaymentsPlatform.Application.CommandHandlers;

public class TransferCommandHandler : IRequestHandler<TransferCommand>
{
    private readonly ITransferRepository _transferRepository;
    private readonly IUserRepository _userRepository;
    private readonly IBaseRepository _baseRepository;
    private readonly ITransferValidationService _transferValidationService;
    private readonly ITransferConfirmationService _transferConfirmationService;
    private readonly ITransferValidator _transferValidator;

    public TransferCommandHandler(ITransferRepository transferRepository,
                                  IBaseRepository baseRepository,
                                  IUserRepository userRepository,
                                  ITransferValidationService transferValidationService,
                                  ITransferConfirmationService transferConfirmationService,
                                  ITransferValidator transferValidator)
    {
        _transferRepository = transferRepository;
        _baseRepository = baseRepository;
        _userRepository = userRepository;
        _transferValidationService = transferValidationService;
        _transferConfirmationService = transferConfirmationService;
        _transferValidator = transferValidator;
    }

    public async Task Handle(TransferCommand request, CancellationToken cancellationToken)
    {
        using var session = await _baseRepository.StartSessionAsync();
        session.StartTransaction();

        try
        {
            await _transferValidator.CheckTransferIsValid(request);

            await TransferBetweenAccounts(session, request);

            var authorizeTransfer = await _transferValidationService.Authorize();

            if (!authorizeTransfer.Authorized)
                throw new Exception("Transferência não autorizada");

            var transfer = request.CommandToTransfer();
            await _transferRepository.CreateWithTransactionAsync(session, transfer);

            await session.CommitTransactionAsync(cancellationToken);
            await _transferConfirmationService.Confirmation(request.Value);
        }
        catch (MongoWriteException ex)
        {
            Console.WriteLine(ex.WriteError.Message);
            Console.WriteLine(ex.Message);
            await session.AbortTransactionAsync();
            throw;
        }
    }

    private async Task TransferBetweenAccounts(IClientSessionHandle session, TransferCommand request)
    {
        var usersOfTransfer = await _userRepository.GetUsersByIds(request.PayerId, request.PayeeId);

        var payer = usersOfTransfer.FirstOrDefault(u => u.Id == request.PayerId);
        var payee = usersOfTransfer.FirstOrDefault(u => u.Id == request.PayeeId);

        payer?.Wallet.DecreaseBalance(request.Value);
        payee?.Wallet.IncreaseBalance(request.Value);

        await Task.WhenAll(
            UpdateWalletBalance(session, payer?.Id, payer.Wallet.AvailableBalance),
            UpdateWalletBalance(session, payee?.Id, payee.Wallet.AvailableBalance)
        );
    }

    private async Task UpdateWalletBalance(IClientSessionHandle session, string userId, decimal balance)
    {
        var filterDefinition = Builders<User>.Filter.Eq(u => u.Id, userId);

        var updateDefinition =
            Builders<User>.Update
                .Set(u => u.Wallet.AvailableBalance, balance);

        await _userRepository.UpdateWithTransactionAsync(session, filterDefinition, updateDefinition);
    }
}