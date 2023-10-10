using Microsoft.AspNetCore.Mvc;

namespace PRG4_Kel03_TokoBaju.Controllers
{
    public class BajuController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
