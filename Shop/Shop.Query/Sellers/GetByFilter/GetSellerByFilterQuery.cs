using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Query;
using Microsoft.EntityFrameworkCore;
using Shop.Domain.SellerAgg;
using Shop.Domain.SellerAgg.Repository;
using Shop.Infrastructure.Persistent.Ef;
using Shop.Query.Sellers.DTOs;

namespace Shop.Query.Sellers.GetByFilter
{
    public class GetSellerByFilterQuery : QueryFilter<SellerFilterResult, SellerFilterParams>
    {
        public GetSellerByFilterQuery(SellerFilterParams filterParams) : base(filterParams)
        {
        }
    }

    public class SellerByFilterQueryHandler : IQueryHandler<GetSellerByFilterQuery, SellerFilterResult>
    {
        private readonly ShopContext _context;

        public SellerByFilterQueryHandler(ShopContext context)
        {
            _context = context;
        }

        public async Task<SellerFilterResult> Handle(GetSellerByFilterQuery request,
            CancellationToken cancellationToken)
        {
            var @params = request.FilterParams;
            var result = _context.Sellers.OrderByDescending(d => d.Id).AsQueryable();

            if (string.IsNullOrWhiteSpace(@params.NationalCode))
                result = result.Where(w => w.NationalCode.Contains(@params.NationalCode));

            if (string.IsNullOrWhiteSpace(@params.ShopName))
                result = result.Where(w => w.ShopName.Contains(@params.ShopName));

            var skip = (@params.PageId - 1) * @params.Take;

            var sellerResult = new SellerFilterResult()
            {
                FilterParams = @params,
                Data = await result.Skip(skip).Take(@params.Take).Select(seller => new SellerDto()
                {
                    Id = seller.Id,
                    CreationDate = seller.CreationDate,
                    ShopName = seller.ShopName,
                    Status = seller.Status,
                    NationalCode = seller.NationalCode,
                    UserId = seller.UserId
                }).ToListAsync(cancellationToken: cancellationToken),
            };

            sellerResult.GeneratePaging(result, @params.Take, @params.PageId);

            return sellerResult;
        }
    }
}
