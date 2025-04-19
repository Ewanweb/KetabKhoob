using Common.Query;
using Dapper;
using Shop.Infrastructure.Persistent.Dapper;
using Shop.Query.Users.DTOs;

namespace Shop.Query.Users.Addresses.GetById;

public class GetUserAddressByIdQueryHandler : IQueryHandler<GetUserAddressByIdQuery, AddressDto?>
{
    private readonly DapperContext _dapper;
    public GetUserAddressByIdQueryHandler(DapperContext dapper)
    {
        _dapper = dapper;
    }
    public async Task<AddressDto?> Handle(GetUserAddressByIdQuery request, CancellationToken cancellationToken)
    {
        var sql = $"SELECT top 1 * from {_dapper.UserAddresses} where id=@id";
        var context = _dapper.CreateConnection();
        return await context.QueryFirstOrDefaultAsync<AddressDto>(sql, new { id = request.AddressId });
    }
}