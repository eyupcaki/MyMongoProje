using MyMongoProje.Dtos.ProductDtos;

namespace MyMongoProje.Services
{
    public interface IProductService
    {
        Task<List<ResultProductDto>> GetResultProductAsync();
        Task CreateProductAsync(CreateProductDto createProductDto);
        Task UpdateProductAsync(UpdateProductDto updateProductDto);

        Task DeleteProductAsync(string id);
        Task<GetByIdProductDto> GetByIdProductAsync(string id);

        Task<List<ResultProductWithCategoryDto>> GetResultProductWithCategoryAsync();
    }
}
