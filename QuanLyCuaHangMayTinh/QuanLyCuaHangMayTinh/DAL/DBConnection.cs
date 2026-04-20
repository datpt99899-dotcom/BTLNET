using System.Configuration;
using System.Data.SqlClient;

namespace QuanLyCuaHangMayTinh.DAL
{
    internal static class DBConnection
    {
        public static string ConnectionString => ConfigurationManager.ConnectionStrings["DefaultConnection"]?.ConnectionString
            ?? ConfigurationManager.ConnectionStrings["QuanLyCuaHangMayTinhConnectionString"]?.ConnectionString
            ?? "Data Source=.;Initial Catalog=QuanLyCuaHangMayTinhDB;Integrated Security=True;Encrypt=True;TrustServerCertificate=True";

        public static SqlConnection CreateConnection() => new SqlConnection(ConnectionString);
    }
}
