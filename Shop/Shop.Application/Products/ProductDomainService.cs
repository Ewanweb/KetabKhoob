﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shop.Domain.ProductAgg.ProductDomainService;
using Shop.Domain.ProductAgg.Repository;

namespace Shop.Application.Products
{
    public class ProductDomainService : IProductDomainService
    {
        private readonly IProductRepository _repository;

        public ProductDomainService(IProductRepository repository)
        {
            _repository = repository;
        }
        public bool SlugIsExist(string slug)
        {
            return _repository.Exists(s => s.Slug == slug);
        }
    }
}
