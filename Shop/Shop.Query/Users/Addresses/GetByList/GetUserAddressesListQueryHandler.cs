using Common.Query;
using Dapper;
using Shop.Infrastructure.Persistent.Dapper;
using Shop.Query.Users.DTOs;

namespace Shop.Query.Users.Addresses.GetByList;

public class GetUserAddressesListQueryHandler : IQueryHandler<GetUserAddressesListQuery, List<AddressDto>>
{
    private readonly DapperContext _dapper;

    public GetUserAddressesListQueryHandler(DapperContext dapper)
    {
        _dapper = dapper;
    }
    public async Task<List<AddressDto>> Handle(GetUserAddressesListQuery request, CancellationToken cancellationToken)
    {
        var sql = $"SELECT * from {_dapper.UserAddresses} where UserId=@userId";
        var context = _dapper.CreateConnection();
        var result = await context.QueryAsync<AddressDto>(sql, new { id = request.UserId });
        return result.ToList();
    }
}