using Microsoft.AspNetCore.Mvc;
using MyMongoProje.Services;

namespace MyMongoProje.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        public async Task<IActionResult> Index()
        {
            var values=await _customerService.GetAllCustomerAsync();
            return View(values);
        }
    }
}
