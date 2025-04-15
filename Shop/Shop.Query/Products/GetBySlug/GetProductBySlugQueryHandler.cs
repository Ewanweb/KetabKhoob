using Common.Query;
using Microsoft.EntityFrameworkCore;
using Shop.Infrastructure.Persistent.Ef;
using Shop.Query.Products.DTOs;

namespace Shop.Query.Products.GetBySlug;

public class GetProductBySlugQueryHandler(ShopContext context) : IQueryHandler<GetProductBySlugQuery, ProductDto?>
{
    private readonly ShopContext _context = context;
    public async Task<ProductDto?> Handle(GetProductBySlugQuery request, CancellationToken cancellationToken)
    {
        var product = await _context.Products
            .FirstOrDefaultAsync(f => f.Slug == request.Slug, cancellationToken: cancellationToken);

        var model = product.Map();

        if (model is null)
            return null;

        await model.SetCategories(_context);

        return model;
    }
}