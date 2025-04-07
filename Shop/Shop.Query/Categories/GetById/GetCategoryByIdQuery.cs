using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Query;
using Shop.Query.Categories.DTOs;

namespace Shop.Query.Categories.GetById
{
    public record GetCategoryByIdQuery(long CategoryId) : IQuery<CategoryDto>;
}
