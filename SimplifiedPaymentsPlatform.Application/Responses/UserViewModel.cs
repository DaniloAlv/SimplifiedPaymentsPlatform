namespace SimplifiedPaymentsPlatform.Application.Responses;

public class UserViewModel
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string Document { get; set; }
    public string Type { get; set; }
    public string Email { get; set; }
    public WalletViewModel Wallet { get; set; }
}