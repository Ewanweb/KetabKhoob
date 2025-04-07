using Common.Application;
using Shop.Domain.UserAgg;
using Shop.Domain.UserAgg.Repository;
using Shop.Domain.UserAgg.Services;

namespace Shop.Application.Users.Register;

public class RegisterUserCommandHandler(IUserRepository repository, IDomainUserService domainService) : IBaseCommandHandler<RegisterUserCommand>
{
    private readonly IUserRepository _repository = repository;
    private readonly IDomainUserService _domainService = domainService;

    public async Task<OperationResult> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
    {
        var user = User.RegisterUser(request.PhoneNumber, request.Password, _domainService);

        await _repository.AddAsync(user);

        return OperationResult.Success();
    }
}