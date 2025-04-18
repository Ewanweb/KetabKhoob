﻿using Common.Domain.Exceptions;
using Common.Query;
using Microsoft.EntityFrameworkCore;
using Shop.Infrastructure.Persistent.Ef;
using Shop.Query.Categories.DTOs;

namespace Shop.Query.Categories.GetById;

internal class GetCategoryByIdQueryHandler(ShopContext context) : IQueryHandler<GetCategoryByIdQuery, CategoryDto>
{
    private readonly ShopContext _context = context;
    public async Task<CategoryDto> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
    {
        var model = await _context.Categories.FirstOrDefaultAsync(f => f.Id == request.CategoryId, cancellationToken : cancellationToken);

        if (model is null)
            throw new NullOrEmptyDomainDataException("دسته بندی یافت نشد");

        return model.Map();
    }
}