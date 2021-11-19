using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class ProbenController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
