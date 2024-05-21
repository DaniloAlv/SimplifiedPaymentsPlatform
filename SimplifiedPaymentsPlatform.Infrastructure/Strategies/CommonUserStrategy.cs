using SimplifiedPaymentsPlatform.Domain.Enums;
using SimplifiedPaymentsPlatform.Domain.Exceptions;

namespace SimplifiedPaymentsPlatform.Infrastructure.Strategies;

public class CommonUserStrategy : IDocumentUserStrategy
{
    private const int DOCUMENT_LENGHT = 11;
    public void ValidateDocument(string document)
    {
        if (document.Length != DOCUMENT_LENGHT) 
            throw new InvalidUserDocumentException(nameof(UserType.Common), DOCUMENT_LENGHT);
    }
}