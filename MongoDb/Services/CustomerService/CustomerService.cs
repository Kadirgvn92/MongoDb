using AutoMapper;
using MongoDb.DTOs.CustomerDTOs;
using MongoDb.Entities;
using MongoDb.Settings;
using MongoDB.Driver;

namespace MongoDb.Services.CustomerService;

public class CustomerService : ICustomerService
{
    private readonly IMongoCollection<Customer> _CustomerCollection;
    private readonly IMapper _mapper;

    public CustomerService(IMapper mapper, IDatabaseSettings _databaseSettings)
    {
        var client = new MongoClient(_databaseSettings.ConnectionString);
        var database = client.GetDatabase(_databaseSettings.DatabaseName);
        _CustomerCollection = database.GetCollection<Customer>(_databaseSettings.CustomerCollectionName);
        _mapper = mapper;

    }

    public async Task CreateCustomerAsync(CreateCustomerDTO DTO)
    {
        var values = _mapper.Map<Customer>(DTO);
        await _CustomerCollection.InsertOneAsync(values);
    }

    public async Task DeleteCustomerAsync(string id)
    {
        await _CustomerCollection.DeleteOneAsync(x => x.CustomerId == id);
    }

    public async Task<List<ResultCustomerDTO>> GetAllCustomerAsync()
    {
        var values = await _CustomerCollection.Find(x => true).ToListAsync();
        return _mapper.Map<List<ResultCustomerDTO>>(values);
    }

    public async Task<GetByIdCustomerDTO> GetByIdCustomerAsync(string id)
    {
        var value = await _CustomerCollection.Find<Customer>(x => x.CustomerId == id).FirstOrDefaultAsync();
        return _mapper.Map<GetByIdCustomerDTO>(value);
    }

    public async Task UpdateCustomerAsync(UpdateCustomerDTO DTO)
    {
        var values = _mapper.Map<Customer>(DTO);
        await _CustomerCollection.FindOneAndReplaceAsync(y => y.CustomerId == DTO.CustomerId, values);
    }
}
