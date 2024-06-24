using Microsoft.AspNetCore.Mvc;

namespace BackendTest.API.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
