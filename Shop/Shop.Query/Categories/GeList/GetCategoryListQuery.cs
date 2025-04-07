using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Query;
using Microsoft.EntityFrameworkCore;
using Shop.Infrastructure.Persistent.Ef;
using Shop.Query.Categories.DTOs;

namespace Shop.Query.Categories.GeList
{
    public record GetCategoryListQuery : IQuery<List<CategoryDto>>;

    internal class GetCategoryListQueryHandler(ShopContext context) : IQueryHandler<GetCategoryListQuery, List<CategoryDto>>
    {
        private readonly ShopContext _context = context;
        public async Task<List<CategoryDto>> Handle(GetCategoryListQuery request, CancellationToken cancellationToken)
        {
            var model = await _context.Categories.OrderByDescending(d => d.Id).ToListAsync(cancellationToken : cancellationToken);

            return model.Map();
        }
    }
}
