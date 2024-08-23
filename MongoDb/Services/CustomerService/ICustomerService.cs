using MongoDb.DTOs.CustomerDTOs;

namespace MongoDb.Services.CustomerService;

public interface ICustomerService
{
    Task<List<ResultCustomerDTO>> GetAllCustomerAsync();
    Task CreateCustomerAsync(CreateCustomerDTO DTO);
    Task UpdateCustomerAsync(UpdateCustomerDTO DTO);
    Task DeleteCustomerAsync(string id);
    Task<GetByIdCustomerDTO> GetByIdCustomerAsync(string id);
}
