using System.Collections.Generic;

namespace MongoDb.DTOs.CustomerDTOs;

public class UpdateCustomerDTO
{
    public string CustomerId { get; set; }
    public string FullName { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }

}
