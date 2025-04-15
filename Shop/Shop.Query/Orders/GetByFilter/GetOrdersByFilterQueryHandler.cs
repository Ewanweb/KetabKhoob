using Common.Query;
using Microsoft.EntityFrameworkCore;
using Shop.Infrastructure.Persistent.Ef;
using Shop.Query.Orders.DTOs;

namespace Shop.Query.Orders.GetByFilter;

public class GetOrdersByFilterQueryHandler(ShopContext context) : IQueryHandler<GetOrdersByFilterQuery, OrderFilterResult>
{
    private readonly ShopContext _context = context;
    public async Task<OrderFilterResult> Handle(GetOrdersByFilterQuery request, CancellationToken cancellationToken)
    {
        var @params = request.FilterParams;
        var result =  _context.Orders.OrderByDescending(d => d.Id).AsQueryable();

        switch (@params)
        {
            case var p when p.Status is not null:
                result = result.Where(r => r.Status == @params.Status);
                break;

            case var p when p.UserId is not null:
                result = result.Where(r => r.UserId == @params.UserId);
                break;

            case var p when p.StartDate is not null:
                result = result.Where(r => r.CreationDate.Date >= @params.StartDate!.Value.Date);
                break;

            case var p when p.EndDate is not null:
                result = result.Where(r => r.CreationDate.Date <= @params.EndDate!.Value.Date);
                break;
        }

        var skip = (@params.PageId - 1) * @params.Take;
        var model = new OrderFilterResult()
        {
            Data = await result.Skip(skip).Take(@params.Take)
                .Select(order => order.MapFilterData(_context))
                .ToListAsync(cancellationToken),
            FilterParams = @params
        };
        model.GeneratePaging(result, @params.Take, @params.PageId);
        return model;

    }
}