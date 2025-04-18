using Common.Application;
using Shop.Application.Users.AddAddress;
using Shop.Application.Users.DeleteUserAddress;
using Shop.Application.Users.EditUserAddress;
using Shop.Query.Users.DTOs;

namespace Shop.Presentation.Facade.Users.Addresses
{
    public interface IUserAddressFacade
    {
        Task<OperationResult> AddAddress(AddUserAddressCommand command);

        Task<OperationResult> EditAddress(EditUserAddressCommand command);
        Task<OperationResult> DeleteAddress(DeleteUserAddressCommand command);

        //Task<AddressDto?> GetById(long userAddressId);
        //Task<List<AddressDto>> GetList(long userId);
        ////Task<OperationResult> SetActiveAddress(SetActiveUserAddressCommand command);
    }
}