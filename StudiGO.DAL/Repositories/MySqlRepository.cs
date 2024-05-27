using MySql.Data.MySqlClient;
using StudiGO.Core.Interfaces;

namespace StudiGO.DAL.Repositories;

public class MySqlRepository : IMySqlRepository
{
    private readonly string _connectionString;

    public MySqlRepository(string connectionString)
    {
        _connectionString = connectionString;
    }
    
    public void CreateUser(string uuid)
    {
        using (var connection = new MySqlConnection(_connectionString))
        {
            connection.Open();
            
            string sql = "INSERT INTO users (uuid) VALUES (@uuid)";

            using (var command = new MySqlCommand(sql, connection))
            {
                command.Parameters.AddWithValue("@uuid", uuid);
                
                command.ExecuteNonQuery();
            }
        }
    }
}