using AutoMapper;
using MyMongoProje.Dtos;
using MyMongoProje.Dtos.ProductDtos;
using MyMongoProje.Entities;

namespace MyMongoProje.Mapping
{
    public class GeneralMapping : Profile
    {
        public GeneralMapping() 
        {
           
            CreateMap<Customer, ResultCustomerDto>().ReverseMap();
            CreateMap<Customer, CreateCustomerDto>().ReverseMap();
            CreateMap<Customer, UpdateCustomerDto>().ReverseMap();
            CreateMap<Customer, GetByIdCustomerDto>().ReverseMap();
            
            CreateMap<Product, ResultProductDto>().ReverseMap();
            CreateMap<Product, CreateProductDto>().ReverseMap();
            CreateMap<Product, UpdateProductDto>().ReverseMap();
            CreateMap<Product, GetByIdProductDto>().ReverseMap();
        }
    }
}
