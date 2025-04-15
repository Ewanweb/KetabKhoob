using Common.Query;
using Microsoft.EntityFrameworkCore;
using Shop.Infrastructure.Persistent.Ef;
using Shop.Query.Products.DTOs;

namespace Shop.Query.Products.GetById;

public class GetProductByIdQueryHandler(ShopContext context) : IQueryHandler<GetProductByIdQuery, ProductDto?>
{
    private readonly ShopContext _context = context;
    public async Task<ProductDto?> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
    {
        var product = await _context.Products
            .FirstOrDefaultAsync(f => f.Id == request.ProductId , cancellationToken : cancellationToken);

        var model = product.Map();

        if (model is null)
            return null;

        await model.SetCategories(_context);

        return model;
    }
}