﻿using Microsoft.EntityFrameworkCore;
using Shop.Domain.CategoryAgg;
using Shop.Infrastructure._Utilities;

namespace Shop.Infrastructure.Persistent.Ef.CategoryAgg;

internal class CategoryRepository : BaseRepository<Category>, ICategoryRepository
{
    private readonly ShopContext _context;
    public CategoryRepository(ShopContext context) : base(context)
    {
        _context = context;
    }

    public async Task<bool> DeleteCategory(long categoryId)
    {
        var category =await _context.Categories
            .Include(c=>c.Childs)
            .ThenInclude(c=>c.Childs).FirstOrDefaultAsync(f => f.Id == categoryId);
        if (category == null)
            return false;


        var isExistProduct = await _context.Products
            .AnyAsync(f => f.CategoryId == categoryId ||
                           f.SubCategoryId == categoryId ||
                           f.SecondarySubCategoryId == categoryId);

        if (isExistProduct)
            return false;

        if (category.Childs.Any(c => c.Childs.Any()))
        {
            _context.RemoveRange(category.Childs.SelectMany(s=>s.Childs));
        }
        _context.RemoveRange(category.Childs);
        _context.RemoveRange(category);
        return true;
    }
}