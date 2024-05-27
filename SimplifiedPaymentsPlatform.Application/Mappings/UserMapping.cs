using SimplifiedPaymentsPlatform.Application.Commands;
using SimplifiedPaymentsPlatform.Application.Responses;
using SimplifiedPaymentsPlatform.Domain.Entities;
using SimplifiedPaymentsPlatform.Domain.Enums;

namespace SimplifiedPaymentsPlatform.Application.Mappings;

public static class UserMapping
{
    public static User CommandToUser(this CreateUserCommand command)
    {
        return new User
        {
            Name = command.Name,
            Document = command.Document,
            Email = command.Email,
            Password = command.Password,
            Type = (UserType)Enum.ToObject(typeof(UserType), command.Type),
            Wallet = new Wallet(command.WalletBalance)
        };
    }

    public static UserViewModel UserToModel(this User user)
    {
        return new UserViewModel
        {
            Id = user.Id,
            Name = user.Name,
            Document = user.Document,
            Email = user.Email,
            Wallet = user.Wallet.WalletToModel(),
            Type = Enum.GetName(typeof(UserType), user.Type)
        };
    }

    public static WalletViewModel WalletToModel(this Wallet wallet)
    {
        return new WalletViewModel{ Balance = wallet.AvailableBalance };
    }
}
