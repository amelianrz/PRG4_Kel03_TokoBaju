using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace PRG4_Kel03_TokoBaju.Models
{
    public class Baju : Controller
    {
        private readonly string _connectionString;
        private readonly SqlConnection _connection;
        public IActionResult Index()
        {
            return View();
        }
    }
}
