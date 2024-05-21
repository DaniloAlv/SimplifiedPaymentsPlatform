namespace SimplifiedPaymentsPlatform.Infrastructure.Strategies;

public interface IDocumentUserStrategy
{
    public void ValidateDocument(string document);
}