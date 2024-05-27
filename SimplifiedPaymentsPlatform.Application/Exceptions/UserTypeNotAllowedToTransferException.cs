using SimplifiedPaymentsPlatform.Domain.Enums;

namespace SimplifiedPaymentsPlatform.Application.Exceptions;

public class UserTypeNotAllowedToTransferException : Exception
{
    public UserTypeNotAllowedToTransferException() 
        : base($"Usuários do tipo {nameof(UserType.Seller)} não podem efetuar transferências.") {}
}