using MongoDb.Entities;

namespace MongoDb.DTOs.CustomerDTOs;

public class GetByIdCustomerDTO
{
    public string CustomerId { get; set; }
    public string FullName { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }
}
