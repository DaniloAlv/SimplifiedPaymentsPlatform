namespace SimplifiedPaymentsPlatform.Application.Services.Validators;

public abstract class BaseValidator
{
    private IList<string> _errorMessages;

    public bool IsValid { get { return !_errorMessages.Any(); } }

    protected BaseValidator()
    {
        _errorMessages = new List<string>();
    }

    public void AddErrorMessage(string message) => _errorMessages.Add(message);

    public IEnumerable<string> GetErrorMessages() =>  _errorMessages;
}