using AutoMapper;
using MongoDb.DTOs.ProductDTOs;
using MongoDb.DTOs.ProductDTOs;
using MongoDB.Driver;
using MongoDb.Entities;
using MongoDb.Settings;

namespace MongoDb.Services.ProductService;

public class ProductService : IProductService
{
    private readonly IMongoCollection<Product> _ProductCollection;
    private readonly IMapper _mapper;

    public ProductService(IMapper mapper, IDatabaseSettings _databaseSettings)
    {
        var client = new MongoClient(_databaseSettings.ConnectionString);
        var database = client.GetDatabase(_databaseSettings.DatabaseName);
        _ProductCollection = database.GetCollection<Product>(_databaseSettings.ProductCollectionName);
        _mapper = mapper;

    }

    public async Task CreateProductAsync(CreateProductDTO DTO)
    {
        var values = _mapper.Map<Product>(DTO);
        await _ProductCollection.InsertOneAsync(values);
    }

    public async Task DeleteProductAsync(string id)
    {
        await _ProductCollection.DeleteOneAsync(x =>  x.ProductId == id);
    }

    public async Task<List<ResultProductDTO>> GetAllProductAsync()
    {
        var values = await _ProductCollection.Find(x => true).ToListAsync();
        return _mapper.Map<List<ResultProductDTO>>(values);
    }

    public async Task<GetByIdProductDTO> GetByIdProductAsync(string id)
    {
        var value = await _ProductCollection.Find<Product>(x => x.ProductId == id).FirstOrDefaultAsync();
        return _mapper.Map<GetByIdProductDTO>(value);
    }

    public async Task UpdateProductAsync(UpdateProductDTO DTO)
    {
        var values = _mapper.Map<Product>(DTO);
        await _ProductCollection.FindOneAndReplaceAsync(y => y.ProductId == DTO.ProductId, values);
    }
}
