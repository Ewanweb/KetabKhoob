using Common.Application;
using Shop.Domain.UserAgg;
using Shop.Domain.UserAgg.Repository;

namespace Shop.Application.Users.ChargeUserWallet;

public class ChargeUserWalletCommandHandler(IUserRepository repository) : IBaseCommandHandler<ChargeUserWalletCommand>
{
    private readonly IUserRepository _userRepository = repository;
    public async Task<OperationResult> Handle(ChargeUserWalletCommand request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetTracking(request.UserId);

        if (user is null)
            return OperationResult.NotFound();

        var wallet = new Wallet(request.Price, request.Description, request.IsFinally, request.Type);

        user.ChargeWallet(wallet);

        return OperationResult.Success();
    }
}