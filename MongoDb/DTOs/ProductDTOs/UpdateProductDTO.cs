namespace MongoDb.DTOs.ProductDTOs;

public class UpdateProductDTO
{
    public string ProductId { get; set; }
    public string Name { get; set; }
    public int Stock { get; set; }
    public decimal Price { get; set; }
    public string ImageUrl { get; set; }
}
