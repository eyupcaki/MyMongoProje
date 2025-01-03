using Microsoft.AspNetCore.Mvc;
using MyMongoProje.Dtos.ProductDtos;
using MyMongoProje.Services;

namespace MyMongoProje.Controllers
{
    public class ProductController : Controller
    {
     private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public IActionResult CreateProduct()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(CreateProductDto createProductDto)
        {
            await _productService.CreateProductAsync(createProductDto);
            return RedirectToAction("ProductList");
        }

        public async Task<IActionResult> ProductList()
        {
            var values = await _productService.GetResultProductAsync();
            return View(values);
        }


        public async Task<IActionResult> DeleteProduct(string id)
        {
            await _productService.DeleteProductAsync(id);
            return RedirectToAction("ProductList");
        }


        [HttpGet]
        
        public async Task<IActionResult> UpdateProduct(string id)
        {
            var value =await _productService.GetByIdProductAsync(id);
            return View(value);
        }
        
        [HttpPost]
        public async Task<IActionResult> UpdateProduct(UpdateProductDto updateProductDto)
        {
            await _productService.UpdateProductAsync(updateProductDto);
            return RedirectToAction("ProductList");
        }

        public async  Task<IActionResult> ResultProductWithCategory()
        {
            var values = await _productService.GetResultProductWithCategoryAsync();
            return  View(values);
        }

	}
}
