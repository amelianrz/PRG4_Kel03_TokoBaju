using Microsoft.AspNetCore.Mvc;
using PRG4_Kel03_TokoBaju.Models;

namespace PRG4_Kel03_TokoBaju.Controllers
{
    public class BajuController : Controller
    {
        private readonly Baju _bukuRepository;

        public BajuController(IConfiguration configuration)
        {
            _bukuRepository = new Baju(configuration);
        }
        public IActionResult Index()
        {
            return View(_bukuRepository.getAllData());
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(BajuModel bajumodel)
        {
            if (ModelState.IsValid)
            {
                _bukuRepository.insertData(bajumodel);
                TempData["SuccesMessage"] = "Data berhasil ditambahkan";
                return RedirectToAction("Index");
            }
            return View(bajumodel);
        }
        [HttpPost]
        public IActionResult Delete(string id)
        {
            var response = new { success = false, message = "Gagal menghapus Baju." };
            try
            {
                if (id != null)
                {
                    _bukuRepository.deleteData(id);
                    response = new { success = true, message = "Baju berhasil dihapus." };
                }
                else
                {
                    response = new { success = false, message = "Baju tidak ditemukan." };
                }
            }
            catch (Exception ex)
            {
                response = new { success = false, message = ex.Message };
            }
            return Json(response);
        }
        [HttpGet]
        public IActionResult Edit(string id)
        {
            BajuModel bukuModel = _bukuRepository.getData(id);

            if (bukuModel == null)
            {
                return NotFound();
            }
            return View(bukuModel);
        }
        [HttpPost]
        public IActionResult Edit(BajuModel bajumodel)
        {
            if (ModelState.IsValid)
            {
                BajuModel newBukuModel = _bukuRepository.getData(bajumodel.id);

                if (newBukuModel == null)
                {
                    return NotFound();
                }

                newBukuModel.nama = bajumodel.nama;
                newBukuModel.idjenis = bajumodel.idjenis;
                newBukuModel.harga = bajumodel.harga;
                newBukuModel.ukuran = bajumodel.ukuran;
                newBukuModel.stok = bajumodel.stok;
                _bukuRepository.updateData(newBukuModel);
                TempData["SuccessMessage"] = "Baju berhasil diupdate";
                return RedirectToAction("Index");
            }
            return View(bajumodel);
        }
    }
}
