using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Query;
using Shop.Query.Products.DTOs;
using Shop.Query.Products.GetById;

namespace Shop.Query.Products.GetBySlug
{
    public record GetProductBySlugQuery(string Slug) : IQuery<ProductDto?>;
}
