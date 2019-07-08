using Microsoft.AspNetCore.Mvc;

namespace HigoApi.Controllers
{
    public class OperacionesMockController : Controller
    {
        // GET
        public IActionResult Index()
        {
            return
            View();
        }
    }
}