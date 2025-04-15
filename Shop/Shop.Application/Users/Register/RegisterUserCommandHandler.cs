using Common.Application;
using Shop.Domain.UserAgg;
using Shop.Domain.UserAgg.Repository;
using Shop.Domain.UserAgg.Services;

namespace Shop.Application.Users.Register;

public class RegisterUserCommandHandler(IUserRepository repository, IUserDomainService userDomainService) : IBaseCommandHandler<RegisterUserCommand>
{
    private readonly IUserRepository _repository = repository;
    private readonly IUserDomainService _userDomainService = userDomainService;

    public async Task<OperationResult> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
    {
        var user = User.RegisterUser(request.PhoneNumber, request.Password, _userDomainService);

        await _repository.AddAsync(user);

        return OperationResult.Success();
    }
}