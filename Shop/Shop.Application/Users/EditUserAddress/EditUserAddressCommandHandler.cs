using Common.Application;
using Shop.Domain.UserAgg;
using Shop.Domain.UserAgg.Repository;

namespace Shop.Application.Users.EditUserAddress;

public class EditUserAddressCommandHandler : IBaseCommandHandler<EditUserAddressCommand>
{
    private readonly IUserRepository _repository;

    public EditUserAddressCommandHandler(IUserRepository repository)
    {
        _repository = repository;
    }
    public async Task<OperationResult> Handle(EditUserAddressCommand request, CancellationToken cancellationToken)
    {
        var user = await _repository.GetTracking(request.UserId);

        if (user is null)
            return OperationResult.NotFound();

        var address = new UserAddress(request.Shire, request.City, request.PostalCode, request.PostalAddress, request.PhoneNumber, request.Name, request.Family, request.Nationalcode);

        user.EditAddress(address, request.Id);

        await _repository.Save();

        return OperationResult.Success();
    }
}