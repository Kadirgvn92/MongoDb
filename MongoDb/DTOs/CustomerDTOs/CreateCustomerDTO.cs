using MongoDb.Entities;

namespace MongoDb.DTOs.CustomerDTOs;

public class CreateCustomerDTO
{
    public string FullName { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }

}
