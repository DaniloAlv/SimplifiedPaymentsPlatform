using SimplifiedPaymentsPlatform.Domain.Enums;
using SimplifiedPaymentsPlatform.Domain.Exceptions;

namespace SimplifiedPaymentsPlatform.Infrastructure.Strategies;

public class SellerUserStrategy : IDocumentUserStrategy
{
    private const int DOCUMENT_LENGHT = 14;
    public void ValidateDocument(string document)
    {
        if (document.Length != DOCUMENT_LENGHT)
            throw new InvalidUserDocumentException(nameof(UserType.Seller), DOCUMENT_LENGHT);
    }
}
