using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace PRG4_Kel03_TokoBaju.Models
{
    public class Baju
    {
        private readonly string _connectionString;
        private readonly SqlConnection _connection;
        public Baju(IConfiguration configuration)
        {
            _connectionString =
                configuration.GetConnectionString
                ("DefaultConnection");

            _connection = new SqlConnection(_connectionString);
        }

        public List<JenisModel> getAllDataJenis()
        {
            List<JenisModel> JenisList = new List<JenisModel>();
            try
            {
                string query = "select id_jenis_baju, nama_jenis_baju from JenisBaju";
                SqlCommand command = new SqlCommand(query, _connection);
                _connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    JenisModel jenis = new JenisModel
                    {
                        id = reader["id_jenis_baju"].ToString(),
                        nama = reader["nama_jenis_baju"].ToString()
                    };
                    JenisList.Add(jenis);
                }
                reader.Close();
                _connection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return JenisList;
        }

        public List<BajuModel> getAllData()
        {
            List<BajuModel> BajuList = new List<BajuModel>();
            try
            {
                string query = "select * from Baju";
                SqlCommand command = new SqlCommand(query, _connection);
                _connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    BajuModel baju = new BajuModel
                    {
                        id = reader["id_baju"].ToString(),
                        nama = reader["nama_baju"].ToString(),
                        idjenis = reader["id_jenis_baju"].ToString(),
                        harga = Convert.ToDouble(reader["harga"]),
                        ukuran = reader["ukuran"].ToString(),
                        stok = Convert.ToInt32(reader["stock"])
                    };
                    BajuList.Add(baju);
                }
                reader.Close();
                _connection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return BajuList;
        }

        public BajuModel getData(string id)
        {
            BajuModel bajumodel = new BajuModel();
            try
            {
                string query = "select * from Baju where id_baju = @p1";
                SqlCommand command = new SqlCommand(query, _connection);
                command.Parameters.AddWithValue("@p1", id);
                _connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    bajumodel.id = reader["id_baju"].ToString();
                    bajumodel.nama = reader["nama_baju"].ToString();
                    bajumodel.idjenis = reader["id_jenis_baju"].ToString();
                    bajumodel.harga = Convert.ToInt32(reader["harga"]);
                    bajumodel.ukuran = reader["ukuran"].ToString();
                    bajumodel.stok = Convert.ToInt32(reader["stock"]);
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

        public void insertData(BajuModel bajumodel)
        {
            try
            {
                string query = "insert into Baju values(@p1,@p2,@p3,@p4,@p5,@p6)";
                SqlCommand command = new SqlCommand(query, _connection);
                command.Parameters.AddWithValue("@p1", bajumodel.id);
                command.Parameters.AddWithValue("@p2", bajumodel.nama);
                command.Parameters.AddWithValue("@p3", bajumodel.idjenis);
                command.Parameters.AddWithValue("@p4", bajumodel.harga);
                command.Parameters.AddWithValue("@p5", bajumodel.ukuran);
                command.Parameters.AddWithValue("@p6", bajumodel.stok);

                _connection.Open();
                command.ExecuteNonQuery();
                _connection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void updateData(BajuModel bajumodel)
        {
            try
            {
                string query = "update Baju " +
                    "set nama_baju = @p2" +
                    ",id_jenis_baju = @p3" +
                    ",harga = @p4" +
                    ",ukuran = @p5" +
                    ",stock = @p6" +
                    " where id_baju = @p1";
                using SqlCommand command = new SqlCommand(query, _connection);
                command.Parameters.AddWithValue("@p1", bajumodel.id);
                command.Parameters.AddWithValue("@p2", bajumodel.nama);
                command.Parameters.AddWithValue("@p3", bajumodel.idjenis);
                command.Parameters.AddWithValue("@p4", bajumodel.harga);
                command.Parameters.AddWithValue("@p5", bajumodel.ukuran);
                command.Parameters.AddWithValue("@p6", bajumodel.stok);

                _connection.Open();
                command.ExecuteNonQuery();
                _connection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void deleteData(string id)
        {
            try
            {
                string query = "delete from Baju where id_baju = @p1";
                using SqlCommand command = new SqlCommand(query, _connection);
                command.Parameters.AddWithValue("@p1", id);
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
