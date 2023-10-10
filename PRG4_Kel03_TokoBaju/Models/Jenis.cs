using System.Data.SqlClient;

namespace PRG4_Kel03_TokoBaju.Models
{
    public class Jenis
    {
        private readonly string _connectionString;

        private readonly SqlConnection _connection;

        public Jenis(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");

            _connection = new SqlConnection(_connectionString);
        }

        public List<JenisModel> getAllData()
        {
            List<JenisModel> bukulist = new List<JenisModel>();
            try
            {
                string query = "select * from JenisBaju";
                SqlCommand command = new SqlCommand(query, _connection);
                _connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    JenisModel buku = new JenisModel
                    {
                        id = reader["id_jenis_baju"].ToString(),
                        nama = reader["nama_jenis_baju"].ToString(),
                    };
                    bukulist.Add(buku);
                }
                reader.Close();
                _connection.Close();
            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return bukulist;
        }
        public JenisModel getData(string id)
        {
            JenisModel bukuModel = new JenisModel();
            try
            {
                string query = "select * from JenisBaju where id_jenis_baju = @p1";
                SqlCommand command = new SqlCommand(query, _connection);
                command.Parameters.AddWithValue("@p1",id);
                _connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                reader.Read();
                bukuModel.id = reader["id_jenis_baju"].ToString();
                bukuModel.nama = reader["nama_jenis_baju"].ToString();
                reader.Close() ;
                _connection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return bukuModel;
        }
        public void insertData(JenisModel bukuModel)
        {
            try
            {
                string query = "insert into JenisBaju values (@p1,@p2)";
                SqlCommand command = new SqlCommand(query, _connection);
                command.Parameters.AddWithValue("@p1", bukuModel.id);
                command.Parameters.AddWithValue("@p2", bukuModel.nama);
                _connection.Open();
                command.ExecuteNonQuery();
                _connection.Close() ;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void updateData(JenisModel bukuModel)
        {
            try
            {
                string query = "update JenisBaju " +
                    "set nama_jenis_baju = @p2" +
                    " where id_jenis_baju = @p1";
                using SqlCommand command = new SqlCommand(query, _connection);
                command.Parameters.AddWithValue("@p1", bukuModel.id);
                command.Parameters.AddWithValue("@p2", bukuModel.nama);
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
                string query = "delete from JenisBaju where id_jenis_baju = @p1";
                SqlCommand command = new SqlCommand(query, _connection);
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
