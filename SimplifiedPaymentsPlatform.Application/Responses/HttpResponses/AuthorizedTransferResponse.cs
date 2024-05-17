namespace SimplifiedPaymentsPlatform.Application.Responses.HttpResponses;

public class AuthorizedTransferResponse
{
    public bool Authorized { get; set; }
    public string Message { get; set; }
}