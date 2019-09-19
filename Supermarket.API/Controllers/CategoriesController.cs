using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Supermarket.API.Domain.Models;
using Supermarket.API.Domain.Services;
using Supermarket.API.Extensions;
using Supermarket.API.Resources;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Supermarket.API.Controllers
{
    [Route("api/[controller]")]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        public CategoriesController(ICategoryService categoryService, IMapper mapper)
        {
            this._categoryService = categoryService;
            this._mapper = mapper;
        }

        /// <summary>
        /// Gets all categories.
        /// </summary>
        /// <returns></returns>
        /// <response code="200">Categories returned</response>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<CategoryResource>), 200)]
        public async Task<IEnumerable<CategoryResource>> ListAsync()
        {
            var categories = await this._categoryService.ListAsync();
            var resources = this._mapper.Map<IEnumerable<Category>, IEnumerable<CategoryResource>>(categories);
            return resources;
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveCategoryResource resource)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState.GetErrorMessages());
            }

            var category = this._mapper.Map<SaveCategoryResource, Category>(resource);
            var result = await this._categoryService.SaveAsync(category);

            if (!result.Success)
            {
                return this.BadRequest(result.Message);
            }

            var categoryResource = this._mapper.Map<Category, CategoryResource>(result.Category);
            return this.Ok(categoryResource);
        }
    }
}
