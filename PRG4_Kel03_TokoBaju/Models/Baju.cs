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

        public Baju(IConfiguration configuration)
        {
            _connectionString =
                configuration.GetConnectionString
                ("DefaultConnection");

            _connection = new SqlConnection(_connectionString);
        }

        public List<BajuModel> getAllData()
        {
            List<BajuModel> bajumodel = new List<BajuModel>();
            try
            {
                string query = "SELECT * FROM Baju";
                SqlCommand command = new SqlCommand(query, _connection);
                _connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    BajuModel baju = new BajuModel
                    {
                        id = Convert.ToInt32(reader["id"].ToString()),
                        nama = reader["nama_baju"].ToString(),
                        idjenis = reader["id_jenis_baju"].ToString(),
                        harga = reader["harga"].ToString(),
                        ukuran = reader["ukuran"].ToString(),
                        stok = reader["stock"].ToString(),
                    };
                    bajumodel.Add(baju);
                }
                reader.Close();
                _connection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return bajumodel;
        }

        public BajuModel getData(int id)
        {
            BajuModel bajumodel = new BajuModel();
        }
    }
}
