using Microsoft.EntityFrameworkCore;
using Supermarket.API.Domain.Models;
using Supermarket.API.Domain.Repositories;
using Supermarket.API.Persistence.Contexts;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Supermarket.API.Persistence.Repositories
{
    public class CategoryRepository : BaseRepository, ICategoryRepository
    {
        public CategoryRepository(AppDbContext context) : base(context) { }

        public async Task AddAsync(Category category)
        {
            await this._context.Categories.AddAsync(category);
        }

        public async Task<IEnumerable<Category>> ListAsync()
        {
            return await this._context.Categories.ToListAsync();
        }

        public async Task<Category> FindByIdAsync(int id)
        {
            return await this._context.Categories.FindAsync(id);
        }

        public void Update(Category category)
        {
            this._context.Categories.Update(category);
        }

        public void Remove(Category category)
        {
            this._context.Categories.Remove(category);
        }
    }
}
