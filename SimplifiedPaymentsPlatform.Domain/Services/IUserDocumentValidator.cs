using SimplifiedPaymentsPlatform.Domain.Enums;

namespace SimplifiedPaymentsPlatform.Domain.Services;

public interface IUserDocumentValidator
{
    void ValidateDocument(UserType userType, string document);
}