﻿using Supermarket.API.Domain.Models;
using Supermarket.API.Domain.Repositories;
using Supermarket.API.Domain.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Supermarket.API.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            this._productRepository = productRepository;
        }

        public async Task<IEnumerable<Product>> ListAsync()
        {
            return await this._productRepository.ListAsync();
        }
    }
}
