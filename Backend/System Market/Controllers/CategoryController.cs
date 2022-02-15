using System;
using Super_Market.Domain.Models;
using Super_Market.Domain.Services;
using Super_Market.Extensions;
using Super_Market.Resources;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace Super_Market.Controllers
{
    [ApiController]
    [Authorize]
    [EnableCors("MyPolicy")]
    [Route("api/categories")]
    public class CategoryController : ControllerBase
    {

        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;
        
        public CategoryController(ICategoryService categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }
        
        
        [HttpGet]
        public async Task<IEnumerable<CategoryResource>> GetAllAsync()
        {
            var categories = await _categoryService.ListAsync();
            return  _mapper.Map<IEnumerable<Category>, IEnumerable<CategoryResource>>(categories);
              
        }
        
        [HttpGet("{id}")]
        public async Task<CategoryResource> GetById(int id)
        {
            var category = await _categoryService.FindByIdAsync(id);
            var resource = _mapper.Map<Category, CategoryResource>(category);
            return resource;
        }
        
        
        [HttpPost]
        public async Task<ActionResult> PostAsync([FromBody] SaveCategoryResource resource)
        {
            
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var category = _mapper.Map<SaveCategoryResource, Category>(resource);
            var result = await _categoryService.SaveAsync(category);
            
            if (!result.Success)
                return BadRequest(result.Message);

            var categoryResource = _mapper.Map<Category, CategoryResource>(result.Category);
            return Ok(categoryResource);
        }
        
        [HttpPut("{id}")]
        public async Task<ActionResult> PutAsync(int id, SaveCategoryResource resource)
        {
            
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var category = _mapper.Map<SaveCategoryResource, Category>(resource);
            var result = await _categoryService.UpdateAsync(id, category);

            if (!result.Success)
                return BadRequest(result.Message);

            var categoryResource = _mapper.Map<Category, CategoryResource>(result.Category);
            return Ok(categoryResource);
        }

        
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var result = await _categoryService.DeleteAsync(id);

            if (!result.Success)
                return BadRequest(result.Message);
            
            var categoryResource = _mapper.Map<Category, CategoryResource>(result.Category);
            return Ok(categoryResource);

        }
        
    }
}