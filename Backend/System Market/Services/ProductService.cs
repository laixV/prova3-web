using System;
using Super_Market.Domain.Models;
using Super_Market.Domain.Repositories;
using Super_Market.Domain.Services;
using Super_Market.Domain.Services.Communication;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Super_Market.Services
{
    public class ProductService: IProductService
    {
        private readonly IProductRepository _productRepository;
        
        private readonly IUnityOfWork _unityOfWork;

        public ProductService(IProductRepository productRepository, IUnityOfWork unityOfWork)
        {
            _productRepository = productRepository;
            _unityOfWork = unityOfWork;
            
        }
        
        public async Task<ProductResponse> SaveAsync(Product product)
        {
            try
            {
                await _productRepository.AddAsync(product);
                await _unityOfWork.CompleteAsync();
                return new ProductResponse(product);
            }
            catch (Exception e)
            {
                return new ProductResponse($"problem occured {e.Message}");
            }
        }

        
        public async Task<Product> FindByIdAsync(int id)
        {
            return await _productRepository.FindByIdAsync(id);
        }

        public async Task<ProductResponse> UpdateAsync(int id, Product product)
        {
            try
            {
                var _product = await _productRepository.FindByIdAsync(id);

                if (_product != null)
                {
                    _product.Name = product.Name;
                    _product.QuantityInPackage = product.QuantityInPackage;
                    _product.UnityOfMeasurement = product.UnityOfMeasurement;
                    _productRepository.Update(_product);
                    
                    await _unityOfWork.CompleteAsync();
                    
                    return new ProductResponse(_product);
                }

                return new ProductResponse($"Product by id {id} not found!");

            } 
            catch (Exception e)
            {
                return new ProductResponse($"Problem occured : {e.Message}");
            }
        }
        

        public async Task<ProductResponse> DeleteAsync(int id)
        {
            try
            {
                var product = await _productRepository.FindByIdAsync(id);

                if (product == null) 
                    return new ProductResponse($"Product cannot be deleted, id = {id} not exists!");
               
                _productRepository.Delete(product);
                await _unityOfWork.CompleteAsync();
                    
                return new ProductResponse(product);
            }
            catch (Exception e)
            {
                return new ProductResponse($"An error occurred {e.Message}");
            }
        }

        public async Task<IEnumerable<Product>> ListAsync()
        {
            return await _productRepository.ListAsync();
        }
    }
}