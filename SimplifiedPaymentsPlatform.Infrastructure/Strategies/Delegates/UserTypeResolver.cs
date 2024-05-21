using SimplifiedPaymentsPlatform.Domain.Enums;

namespace SimplifiedPaymentsPlatform.Infrastructure.Strategies.Delegates;

public delegate IDocumentUserStrategy UserTypeResolver(UserType userType);