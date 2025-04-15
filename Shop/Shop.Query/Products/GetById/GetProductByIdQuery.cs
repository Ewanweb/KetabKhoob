using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Query;
using Shop.Query.Products.DTOs;

namespace Shop.Query.Products.GetById
{
    public record GetProductByIdQuery(long ProductId) : IQuery<ProductDto?>;
}
