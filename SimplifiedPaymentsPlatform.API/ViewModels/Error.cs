namespace SimplifiedPaymentsPlatform.API.ViewModels;

public class Error
{
    public Error(string description)
    {
        Description = description;
    }

    public string Description { get; private set; }
}