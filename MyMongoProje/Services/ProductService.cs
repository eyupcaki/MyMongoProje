﻿using AutoMapper;
using MongoDB.Driver;
using MyMongoProje.Dtos.ProductDtos;
using MyMongoProje.Entities;
using MyMongoProje.Settings;
using System.Security.AccessControl;

namespace MyMongoProje.Services
{
    public class ProductService : IProductService
    {
        private readonly IMongoCollection<Product>  _productCollection;
        private readonly IMongoCollection<Category>  _categoryCollection;
     
        private readonly IMapper _mapper;

        public ProductService (IMapper mapper, IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _productCollection = database.GetCollection<Product>(_databaseSettings.ProductCollectionName); 
            _categoryCollection = database.GetCollection<Category>(_databaseSettings.CategoryCollectionName); 
            _mapper = mapper;
        }

        public async Task CreateProductAsync(CreateProductDto createProductDto)
        {
            var value=_mapper.Map<Product>(createProductDto);
            await _productCollection.InsertOneAsync(value);
        }

        public async Task DeleteProductAsync(string id)
        {
           await _productCollection.DeleteOneAsync(x=>x.ProductId==id);
        }

        public async Task<GetByIdProductDto> GetByIdProductAsync(string id)
        {
            var values=await _productCollection.Find(x=>x.ProductId==id).FirstOrDefaultAsync();
            return _mapper.Map<GetByIdProductDto>(values);
        }

        public async Task<List<ResultProductDto>> GetResultProductAsync()
        {
            var values=await _productCollection.Find(x=>true).ToListAsync();
            return _mapper.Map<List<ResultProductDto>>(values);
        }

		public async Task<List<ResultProductWithCategoryDto>> GetResultProductWithCategoryAsync()
		{
            var values = await _productCollection.Find(x => true).ToListAsync();
            foreach (var item in values)
            {
                item.Category=await _categoryCollection.Find<Category>(x=>x.CategoryId==item.CategoryId).FirstAsync();
            }
            return _mapper.Map<List<ResultProductWithCategoryDto>>(values);

		}

		public async Task UpdateProductAsync(UpdateProductDto updateProductDto)
        {
           var values=_mapper.Map<Product>(updateProductDto);
            await _productCollection.FindOneAndReplaceAsync(x => x.ProductId == updateProductDto.ProductId, values);
        }
    }
}
