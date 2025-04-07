using Common.Application;
using Shop.Domain.UserAgg.Repository;

namespace Shop.Application.Users.DeleteUserAddress;

public class DeleteUserAddressCommandHandler(IUserRepository userRepository) : IBaseCommandHandler<DeleteUserAddressCommand>
{
    private readonly IUserRepository _userRepository = userRepository;
    public async Task<OperationResult> Handle(DeleteUserAddressCommand request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetTracking(request.UserId);

        if (user is null)
            return OperationResult.NotFound();

        user.DeleteAddress(request.AddressId);

        await _userRepository.Save();

        return OperationResult.Success();
    }
}