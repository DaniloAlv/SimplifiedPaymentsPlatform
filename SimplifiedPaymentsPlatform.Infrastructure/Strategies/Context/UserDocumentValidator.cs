using Microsoft.Extensions.DependencyInjection;
using SimplifiedPaymentsPlatform.Domain.Enums;
using SimplifiedPaymentsPlatform.Domain.Services;

namespace SimplifiedPaymentsPlatform.Infrastructure.Strategies.Context;

public class UserDocumentValidator : IUserDocumentValidator
{
    private readonly IDictionary <UserType, IDocumentUserStrategy> _strategies;
    private IDocumentUserStrategy _documentUserStrategy;
    private readonly IServiceProvider _serviceProvider;

    public UserDocumentValidator(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
        _strategies = new Dictionary<UserType, IDocumentUserStrategy>
        {
            { UserType.Common, _serviceProvider.GetRequiredService<CommonUserStrategy>() }, 
            { UserType.Seller, _serviceProvider.GetRequiredService<SellerUserStrategy>() }
        };        
    }

    public void SetStrategyService(UserType userType)
    {
        _documentUserStrategy = GetUserStrategy(userType);
    }

    public IDocumentUserStrategy GetUserStrategy(UserType userType)
    {
        _strategies.TryGetValue(userType, out IDocumentUserStrategy userStrategy);
        return userStrategy;
    }

    public void ValidateDocument(UserType userType, string document)
    {
        SetStrategyService(userType);
        _documentUserStrategy.ValidateDocument(document);
    }
}