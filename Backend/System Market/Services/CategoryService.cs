using System;
using Super_Market.Domain.Models;
using Super_Market.Domain.Repositories;
using Super_Market.Domain.Services;
using Super_Market.Domain.Services.Communication;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Super_Market.Services
{
    public class CategoryService : ICategoryService
    {

        private readonly IUnityOfWork _unityOfWork;
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository, IUnityOfWork unityOfWork)
        {
            _categoryRepository = categoryRepository;
            _unityOfWork = unityOfWork;
        }
        
        public async Task<CategoryResponse> SaveAsync(Category category)
        {
            try
            {
                await _categoryRepository.AddAsync(category);
                await _unityOfWork.CompleteAsync();
                return new CategoryResponse(category);
            }
            catch (Exception e)
            {
                return new CategoryResponse($"An error occurred when saving the category: {e.Message}");
            }
            
        }

        public async Task<CategoryResponse> UpdateAsync(int id, Category category)
        {
            try
            {
                var _category = await _categoryRepository.FindByIdAsync(id);

                if (_category != null)
                {
                    _category.Name = category.Name;
                    _categoryRepository.Update(_category);
                    await _unityOfWork.CompleteAsync();
                    return new CategoryResponse(_category);
                }

                return new CategoryResponse($" Category by id {id} not found");
            }
            catch (Exception e)
            {
                return new CategoryResponse($" An error occurred when updating the category: {e.Message}");
            }
        }

        
        public async Task<CategoryResponse> DeleteAsync(int id)
        {
            try
            {
                var category = await _categoryRepository.FindByIdAsync(id);
                if (category != null)
                {
                    _categoryRepository.Delete(category);
                    await _unityOfWork.CompleteAsync();
                    return new CategoryResponse(category);
                }

                return new CategoryResponse($"Category by {id} not found");
            }
            catch (Exception e)
            {
                return new CategoryResponse($"An error occurred when deleting the category: {e.Message}");
            }
        }


        public async Task<IEnumerable<Category>> ListAsync()
        {
            return await _categoryRepository.ListAsync();
        }

        public async Task<Category> FindByIdAsync(int id)
        {
            return await _categoryRepository.FindByIdAsync(id);
        }
        
    }
}