using Common.Application;
using Common.Application.SecurityUtil;
using Shop.Domain.UserAgg;
using Shop.Domain.UserAgg.Repository;
using Shop.Domain.UserAgg.Services;

namespace Shop.Application.Users.Create;

public class CreateUserCommandHandler : IBaseCommandHandler<CreateUserCommand>
{
    private readonly IUserRepository _userRepository;
    private readonly IDomainUserService _domainService;

    public CreateUserCommandHandler(IUserRepository userRepository, IDomainUserService domainService)
    {
        _userRepository = userRepository;
        _domainService = domainService;
    }
    public async Task<OperationResult> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var password = Sha256Hasher.Hash(request.Password);
        var user = new User(request.Name, request.Family, request.PhoneNumber, request.Email, password, request.Gender, _domainService);

        await _userRepository.AddAsync(user);
        await _userRepository.Save();

        return OperationResult.Success();
    }
}