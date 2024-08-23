using AutoMapper;
using MongoDb.DTOs.CategoryDTOs;
using MongoDb.DTOs.CustomerDTOs;
using MongoDb.DTOs.ProductDTOs;
using MongoDb.Entities;

namespace MongoDb.Mapping;

public class GeneralMapping : Profile
{
    public GeneralMapping()
    {
        CreateMap<Category, ResultCategoryDTO>().ReverseMap();
        CreateMap<Category, CreateCategoryDTO>().ReverseMap();
        CreateMap<Category, UpdateCategoryDTO>().ReverseMap();
        CreateMap<Category, GetByIdCategoryDTO>().ReverseMap();

        CreateMap<Product, ResultProductDTO>().ReverseMap();
        CreateMap<Product, CreateProductDTO>().ReverseMap();
        CreateMap<Product, UpdateProductDTO>().ReverseMap();
        CreateMap<Product, GetByIdProductDTO>().ReverseMap();

        CreateMap<Customer, ResultCustomerDTO>().ReverseMap();
        CreateMap<Customer, CreateCustomerDTO>().ReverseMap();
        CreateMap<Customer, UpdateCustomerDTO>().ReverseMap();
        CreateMap<Customer, GetByIdCustomerDTO>().ReverseMap();
    }
}
