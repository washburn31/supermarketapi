using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Supermarket.API.Domain.Models;
using Supermarket.API.Domain.Services;
using Supermarket.API.Resources;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Supermarket.API.Controllers
{
    [Route("api/[controller]")]
    public class CategoriesController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        public CategoriesController(ICategoryService categoryService, IMapper mapper)
        {
            this._categoryService = categoryService;
            this._mapper = mapper;
        }

        public async Task<IEnumerable<CategoryResource>> ListAsync()
        {
            var categories = await this._categoryService.ListAsync();
            var resources = _mapper.Map<IEnumerable<Category>, IEnumerable<CategoryResource>>(categories);
            return resources;
        }
    }
}
