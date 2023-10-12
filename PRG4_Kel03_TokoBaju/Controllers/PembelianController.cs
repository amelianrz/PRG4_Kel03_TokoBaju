using Microsoft.AspNetCore.Mvc;
using PRG4_Kel03_TokoBaju.Models;

namespace PRG4_Kel03_TokoBaju.Controllers
{
    public class PembelianController : Controller
    {
        private readonly Pembelian _pembelianRepository;

        public PembelianController(IConfiguration configuration)
        {
            _pembelianRepository = new Pembelian(configuration);
        }
        public IActionResult Index()
        {
            return View(_pembelianRepository.getAllData());
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.pembelianList = _pembelianRepository.getAllDatabaju();
            return View();
        }

        [HttpPost]
        public IActionResult Create(PembelianModel PembelianModel)
        {

            if (ModelState.IsValid)
            {
                _pembelianRepository.insertData(PembelianModel);
                TempData["SuccesMessage"] = "Data berhasil ditambahkan";
                return RedirectToAction("Index");
            }
            return View(PembelianModel);
        }

    }
}
