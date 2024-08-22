using AutoMapper;
using MongoDb.DTOs.CategoryDTOs;
using MongoDb.Entities;
using MongoDb.Settings;
using MongoDB.Driver;

namespace MongoDb.Services.CategoryService;

public class CategoryService : ICategoryService
{
    private readonly IMongoCollection<Category> _categoryCollection;
    private readonly IMapper _mapper;

    public CategoryService(IMapper mapper, IDatabaseSettings _databaseSettings)
    {
        var client = new MongoClient(_databaseSettings.ConnectionString);
        var database = client.GetDatabase(_databaseSettings.DatabaseName);
        _categoryCollection = database.GetCollection<Category>(_databaseSettings.CategoryCollectionName);
        _mapper = mapper;

    }

    public async Task CreateCategoryAsync(CreateCategoryDTO DTO)
    {
       var values = _mapper.Map<Category>(DTO);
        await _categoryCollection.InsertOneAsync(values);
    }

    public Task DeleteCategoryAsync(string id)
    {
        throw new NotImplementedException();
    }

    public async Task<List<ResultCategoryDTO>> GetAllCategoryAsync()
    {
       var values = await _categoryCollection.Find(x => true).ToListAsync();    
        return _mapper.Map<List<ResultCategoryDTO>>(values);    
    }

    public Task<GetByIdCategoryDTO> GetByIdCategoryAsync(string id)
    {
        throw new NotImplementedException();
    }

    public Task UpdateCategoryAsync(UpdateCategoryDTO DTO)
    {
        throw new NotImplementedException();
    }
}
