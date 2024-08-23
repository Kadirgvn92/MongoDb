using MongoDb.DTOs.ProductDTOs;

namespace MongoDb.Services.ProductService;

public interface IProductService
{
    Task<List<ResultProductDTO>> GetAllProductAsync();
    Task CreateProductAsync(CreateProductDTO DTO);
    Task UpdateProductAsync(UpdateProductDTO DTO);
    Task DeleteProductAsync(string id);
    Task<GetByIdProductDTO> GetByIdProductAsync(string id);
}
