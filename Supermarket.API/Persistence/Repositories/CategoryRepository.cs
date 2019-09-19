using Microsoft.EntityFrameworkCore;
using Supermarket.API.Domain.Models;
using Supermarket.API.Domain.Repositories;
using Supermarket.API.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket.API.Persistence.Repositories
{
    public class CategoryRepository : BaseRepository, ICategoryRepository
    {
        public CategoryRepository(AppDbContext context) : base(context) { }

        public Task AddAsync(Category category)
        {
            await this._context.Categories.AddAsync(category);
        }

        public async Task<IEnumerable<Category>> ListAsync()
        {
            return await this._context.Categories.ToListAsync();
        }
    }
}
