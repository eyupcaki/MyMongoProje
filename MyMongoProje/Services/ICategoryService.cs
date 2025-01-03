using MyMongoProje.Dtos.CategoryDtos;

namespace MyMongoProje.Services
{
    public interface ICategoryService
    {
        Task CreateCategoryAsync(CreateCategoryDto createCategoryDto);
    }
}
