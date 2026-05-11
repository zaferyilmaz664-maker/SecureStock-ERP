using System.Data.SqlClient;

namespace SecureStock.DataAccess
{
    public class DbHelper
    {
        // Merkezi bağlantı cümlemiz
        private static readonly string ConnectionString = @"Server=.\SQLEXPRESS;Database=SecureStockDB;Integrated Security=True;";

        // İhtiyaç anında bağlantı nesnesi üreten metod
        public static SqlConnection GetConnection()
        {
            return new SqlConnection(ConnectionString);
        }
    }
}