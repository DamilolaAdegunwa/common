using Microsoft.AspNetCore.Mvc;

namespace MongoMission.Controllers
{
    public class EcommerceController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
