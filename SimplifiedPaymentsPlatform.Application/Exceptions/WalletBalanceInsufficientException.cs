namespace SimplifiedPaymentsPlatform.Application.Exceptions;

public class WalletBalanceInsufficientException : Exception
{
    public WalletBalanceInsufficientException() 
        : base("Você não possui saldo suficiente em conta ou o valor da transferência é inválido.") { }
}