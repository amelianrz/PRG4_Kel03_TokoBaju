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
                        /*id = Convert.ToInt32(reader["id"].ToString()),
                        nama = reader["nama_baju"].ToString(),
                        idjenis = reader["id_jenis_baju"].ToString(),
                        harga = reader["harga"].ToString(),
                        ukuran = reader["ukuran"].ToString(),
                        stok = reader["stock"].ToString(),*/
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

        public BajuModel getData(string id)
        {
            BajuModel bajumodel = new BajuModel();
            try
            {
                string query = "select * from Baju where id = @p1";
                SqlCommand command = new SqlCommand(query, _connection);
                command.Parameters.AddWithValue("@p1", id);
                _connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    /*bajumodel.id = Convert.ToInt32(reader["id"].ToString());
                    bajumodel.nama = reader["nama_baju"].ToString();
                    bajumodel.idjenis = reader["id_jenis_baju"].ToString();
                    bajumodel.harga = reader["harga"].ToString();
                    bajumodel.ukuran = reader["ukuran"].ToString();
                    bajumodel.stok = reader["stock"].ToString();*/
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
                string query = "insert into Anggota values(@p1,@p2,@p3,@p4,@p5)";
                SqlCommand command = new SqlCommand(query, _connection);
                command.Parameters.AddWithValue("@p1", bajumodel.nama);
                command.Parameters.AddWithValue("@p2", bajumodel.idjenis);
                command.Parameters.AddWithValue("@p3", bajumodel.harga);
                command.Parameters.AddWithValue("@p4", bajumodel.ukuran);
                command.Parameters.AddWithValue("@p5", bajumodel.stok);

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
                    ",stock = @p" +
                    " where id = @p1";
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
                string query = "delete from Baju where id = @p1";
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
