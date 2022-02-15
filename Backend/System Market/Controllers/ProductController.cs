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
    [Route("api/products")]
    public class ProductController: ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IProductService _productService;
        
        public ProductController(IMapper mapper, IProductService productService)
        {
            _mapper = mapper;
            _productService = productService;
           
        }

        [HttpGet]
        public async Task<IEnumerable<ProductResource>> GetAll()
        {
            var products = await _productService.ListAsync();
            var response = _mapper.Map<IEnumerable<Product>, IEnumerable<ProductResource>>(products);
            return response;
            
        }
        
        [HttpGet("{id}")]
        public async Task<ProductResource> GetById(int id)
        {
            var products = await _productService.FindByIdAsync(id);
            var response = _mapper.Map<Product, ProductResource>(products);
            return response;
            
        }
        

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] SaveProductResource resource)
        {
            
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var product = _mapper.Map<SaveProductResource, Product>(resource);
            
            var result = await _productService.SaveAsync(product);

            if (!result.Success)
                return BadRequest(result.Message);

            var productResource = _mapper.Map<Product, ProductResource>(result.Product);
           
            return Ok(productResource);
        }
        
        
    }
}
