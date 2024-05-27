using MediatR;
using SimplifiedPaymentsPlatform.Application.Commands;
using SimplifiedPaymentsPlatform.Application.Mappings;
using SimplifiedPaymentsPlatform.Application.Responses;
using SimplifiedPaymentsPlatform.Domain.Repositories;
using SimplifiedPaymentsPlatform.Domain.Services;

namespace SimplifiedPaymentsPlatform.Application.CommandHandlers;

public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, UserViewModel>
{
    private readonly IUserRepository _userRepository;
    private readonly IUserDocumentValidator _userDocumentValidator;

    public CreateUserCommandHandler(IUserRepository userRepository, 
                                    IUserDocumentValidator userDocumentValidator)
    {
        _userRepository = userRepository;
        _userDocumentValidator = userDocumentValidator;
    }

    public async Task<UserViewModel> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var user = request.CommandToUser();

        _userDocumentValidator.ValidateDocument(user.Type, user.Document);

        await _userRepository.Register(user);

        return user.UserToModel();
    }
}
