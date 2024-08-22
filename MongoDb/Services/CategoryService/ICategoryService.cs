using MongoDb.DTOs.CategoryDTOs;

namespace MongoDb.Services.CategoryService;

public interface ICategoryService
{
    Task<List<ResultCategoryDTO>> GetAllCategoryAsync(); 
    Task CreateCategoryAsync(CreateCategoryDTO DTO); 
    Task UpdateCategoryAsync(UpdateCategoryDTO DTO); 
    Task DeleteCategoryAsync(string id); 
    Task <GetByIdCategoryDTO> GetByIdCategoryAsync(string id); 
}
