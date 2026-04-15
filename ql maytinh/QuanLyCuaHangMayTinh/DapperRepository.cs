using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;

namespace QuanLyCuaHangMayTinh
{
    internal static class DapperRepository
    {
        private static string ConnectionString => ConfigurationManager.ConnectionStrings["QuanLyCuaHangMayTinh.Properties.Settings.QuanLyBanHangMayTinhConnectionString"]?.ConnectionString
            ?? ConfigurationManager.ConnectionStrings[0]?.ConnectionString
            ?? "Data Source=.;Initial Catalog=QuanLyBanHangMayTinh;Integrated Security=True;Encrypt=True;TrustServerCertificate=True";

        public static SqlConnection CreateConnection() => new SqlConnection(ConnectionString);

        public static List<T> QueryList<T>(string sql, object param = null)
        {
            using (var conn = CreateConnection())
            {
                conn.Open();
                return conn.Query<T>(sql, param).AsList();
            }
        }

        public static int Execute(string sql, object param = null)
        {
            using (var conn = CreateConnection())
            {
                conn.Open();
                return conn.Execute(sql, param);
            }
        }
    }
}
