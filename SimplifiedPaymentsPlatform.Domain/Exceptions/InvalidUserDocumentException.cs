namespace SimplifiedPaymentsPlatform.Domain.Exceptions;

public class InvalidUserDocumentException : InvalidOperationException
{
    public InvalidUserDocumentException(string userType, int documentLenght) 
            : base($"O documento para usuários do tipo {userType} precisa ter {documentLenght} digitos.")
    {}
}