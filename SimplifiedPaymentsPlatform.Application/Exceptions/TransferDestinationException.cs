namespace SimplifiedPaymentsPlatform.Application.Exceptions;

public class TransferDestinationException : Exception
{
    public TransferDestinationException() : base("A conta de destino não pode ser a mesma da origem.")
    {        
    }
}