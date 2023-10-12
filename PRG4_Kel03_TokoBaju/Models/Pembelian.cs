using System.Data.SqlClient;

namespace PRG4_Kel03_TokoBaju.Models
{
    public class Pembelian
    {
        private readonly string _connectionString;

        // koneksi sql
        private readonly SqlConnection _connection;

        //constructor kelas yang akan kita gunakan untuk mengsetup connection string
        public Pembelian(IConfiguration configuration)
        {
            //mengambil konfigurasi connection string dari appsetting.json
            _connectionString = configuration.GetConnectionString("DefaultConnection");

            //koneksi sql menggunakan connection string
            _connection = new SqlConnection(_connectionString);
        }

        public List<BajuModel> getAllDatabaju()
        {
            List<BajuModel> pembelianList = new List<BajuModel>();
            try
            {
                string query = "select * from Baju";
                SqlCommand command = new SqlCommand(query, _connection);
                _connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    BajuModel pembelian = new BajuModel
                    { 
                        id = reader["id_baju"].ToString(),
                        nama = reader["nama_baju"].ToString(),
                        harga = Convert.ToDouble(reader["harga"].ToString()),
                    };
                    pembelianList.Add(pembelian);
                }
                reader.Close();
                _connection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return pembelianList;
        }


            public List<PembelianModel> getAllData()
            {
            List<PembelianModel> pembelianList = new List<PembelianModel>();
            try
            {
                string query = "select * from Pembelian";
                SqlCommand command = new SqlCommand(query, _connection);
                _connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    PembelianModel pembelian = new PembelianModel
                    {
                        id_trs = reader["id_pembelian"].ToString(),
                        id = reader["id_baju"].ToString(),
                        jumlah = Convert.ToInt32(reader["jumlah"].ToString()),
                        tanggal = Convert.ToDateTime(reader["tanggal"].ToString()),
                        total = Convert.ToDouble(reader["total"].ToString()),
                    };
                    pembelianList.Add(pembelian);
                }
                reader.Close();
                _connection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return pembelianList;
            }

        public PembelianModel getData(int id)
        {
            PembelianModel pembelianModel = new PembelianModel();
            try
            {
                string query = "select * from Pembelian where id_pembeiian = @p1";
                SqlCommand command = new SqlCommand(query, _connection);
                command.Parameters.AddWithValue("@p1", id);
                _connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                reader.Read();
                pembelianModel.id_trs = reader["id_pembelian"].ToString();
                pembelianModel.id = reader["id_baju"].ToString();
                pembelianModel.jumlah = Convert.ToInt32(reader["jumlah"].ToString());
                pembelianModel.tanggal = Convert.ToDateTime(reader["tanggal"].ToString());
                pembelianModel.total = Convert.ToDouble(reader["total"].ToString());
                reader.Close();
                _connection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return pembelianModel;
        }
        
        public void insertData(PembelianModel pembelianModel)
        {
            try
            {
                string query = "insert into Pembelian (id_pembelian,id_baju,jumlah,tanggal,total) values(@p1,@p2,@p3,@p4,@p5)";
                SqlCommand command = new SqlCommand(query, _connection);
                command.Parameters.AddWithValue("@p1", pembelianModel.id_trs);
                command.Parameters.AddWithValue("@p2", pembelianModel.id);
                command.Parameters.AddWithValue("@p3", pembelianModel.jumlah);
                command.Parameters.AddWithValue("@p4", pembelianModel.tanggal);
                command.Parameters.AddWithValue("@p5", pembelianModel.total);
                _connection.Open();
                command.ExecuteNonQuery();
                _connection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}