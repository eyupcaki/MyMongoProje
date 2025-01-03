using AutoMapper;
using MongoDB.Driver;
using MyMongoProje.Dtos.CategoryDtos;
using MyMongoProje.Dtos.ProductDtos;
using MyMongoProje.Entities;
using MyMongoProje.Settings;

namespace MyMongoProje.Services
{
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

       

        public async Task CreateCategoryAsync(CreateCategoryDto createCategoryDto)
        {
            var value = _mapper.Map<Category>(createCategoryDto);
            await _categoryCollection.InsertOneAsync(value);
               // InsertOneAsync(value);
        }
    }
}
