using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

namespace QuanLyCuaHangMayTinh
{
    internal class Function
    {
        public static SqlConnection Conn;
        public static string connString;

        public static string GetConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["DefaultConnection"]?.ConnectionString
                ?? ConfigurationManager.ConnectionStrings["QuanLyCuaHangMayTinhConnectionString"]?.ConnectionString
                ?? "Data Source=.;Initial Catalog=QuanLyCuaHangMayTinhDB;Integrated Security=True;Encrypt=True;TrustServerCertificate=True";
        }

        public static void Connect()
        {
            if (Conn != null && Conn.State == ConnectionState.Open) return;
            connString = GetConnectionString();
            Conn = new SqlConnection(connString);
            Conn.Open();
        }

        public static void Disconnect()
        {
            if (Conn != null && Conn.State == ConnectionState.Open)
            {
                Conn.Close();
                Conn.Dispose();
            }
            Conn = null;
        }

        public static DataTable GetDataToTable(string sql)
        {
            Connect();
            using (SqlDataAdapter adapter = new SqlDataAdapter(sql, Conn))
            {
                DataTable table = new DataTable();
                adapter.Fill(table);
                return table;
            }
        }

        public static DataTable GetDataToTable(string sql, params SqlParameter[] parameters)
        {
            Connect();
            using (SqlCommand command = new SqlCommand(sql, Conn))
            {
                if (parameters != null && parameters.Length > 0)
                    command.Parameters.AddRange(parameters);
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    DataTable table = new DataTable();
                    adapter.Fill(table);
                    return table;
                }
            }
        }

        public static bool CheckKey(string sql)
        {
            DataTable table = GetDataToTable(sql);
            return table.Rows.Count > 0;
        }

        public static void RunSql(string sql)
        {
            Connect();
            using (SqlCommand cmd = new SqlCommand(sql, Conn))
            {
                try { cmd.ExecuteNonQuery(); }
                catch (Exception ex) { MessageBox.Show(ex.Message, "Lỗi SQL", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }

        public static void RunSql(string sql, params SqlParameter[] parameters)
        {
            Connect();
            using (SqlCommand cmd = new SqlCommand(sql, Conn))
            {
                if (parameters != null && parameters.Length > 0)
                    cmd.Parameters.AddRange(parameters);
                try { cmd.ExecuteNonQuery(); }
                catch (Exception ex) { MessageBox.Show(ex.Message, "Lỗi SQL", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }

        public static void RunSqlDel(string sql)
        {
            Connect();
            using (SqlCommand cmd = new SqlCommand(sql, Conn))
            {
                try { cmd.ExecuteNonQuery(); }
                catch (Exception) { MessageBox.Show("Dữ liệu đang được dùng, không thể xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop); }
            }
        }

        public static string ConvertDateTime(string d)
        {
            string[] parts = d.Split('/');
            return string.Format("{0}/{1}/{2}", parts[1], parts[0], parts[2]);
        }

        public static string GetFieldValues(string sql)
        {
            Connect();
            using (SqlCommand cmd = new SqlCommand(sql, Conn))
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                return reader.Read() ? reader.GetValue(0).ToString() : null;
            }
        }

        public static double? GetFieldValues1(string sql)
        {
            Connect();
            using (SqlCommand cmd = new SqlCommand(sql, Conn))
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                if (reader.Read() && !reader.IsDBNull(0))
                    return Convert.ToDouble(reader[0]);
                return null;
            }
        }

        public static bool IsDate(string date)
        {
            DateTime temp;
            return DateTime.TryParseExact(date, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out temp);
        }

        public static void FillCombo(string sql, ComboBox cbo, string ma, string ten)
        {
            DataTable table = GetDataToTable(sql);
            cbo.DataSource = table;
            cbo.ValueMember = ma;
            cbo.DisplayMember = ten;
            cbo.Refresh();
        }

        public static DataTable ExecuteQuery(string sql, object[] parameter = null)
        {
            Connect();
            DataTable data = new DataTable();
            using (SqlCommand command = new SqlCommand(sql, Conn))
            {
                if (parameter != null)
                {
                    string[] listPara = sql.Split(' ');
                    int i = 0;
                    foreach (string item in listPara)
                    {
                        if (item.Contains('@') && i < parameter.Length)
                        {
                            command.Parameters.AddWithValue(item.TrimEnd(',', ')', ';'), parameter[i]);
                            i++;
                        }
                    }
                }
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(data);
                }
            }
            return data;
        }

        public static DataTable GetBillListByDate(DateTime checkIn, DateTime checkOut)
        {
            return ExecuteQuery("exec usp_GetListBillByDate @checkIn , @checkOut", new object[] { checkIn, checkOut });
        }

        public static string ChuyenSoSangChu(string sNumber)
        {
            int mLen, mDigit;
            string mTemp = "";
            string[] mNumText;
            sNumber = sNumber.Replace(",", "");
            sNumber = new string(sNumber.Where(char.IsDigit).ToArray());
            if (string.IsNullOrEmpty(sNumber)) return "Không đồng";
            mNumText = "không;một;hai;ba;bốn;năm;sáu;bảy;tám;chín".Split(';');
            mLen = sNumber.Length - 1;
            for (int i = 0; i <= mLen; i++)
            {
                mDigit = Convert.ToInt32(sNumber.Substring(i, 1));
                mTemp = mTemp + " " + mNumText[mDigit];
                if (mLen == i) break;
                switch ((mLen - i) % 9)
                {
                    case 0:
                        mTemp += " tỷ";
                        if (sNumber.Substring(i + 1, Math.Min(3, mLen - i)) == "000") i += 3;
                        if (i < mLen && sNumber.Substring(i + 1, Math.Min(3, mLen - i)) == "000") i += 3;
                        if (i < mLen && sNumber.Substring(i + 1, Math.Min(3, mLen - i)) == "000") i += 3;
                        break;
                    case 6:
                        mTemp += " triệu";
                        if (sNumber.Substring(i + 1, Math.Min(3, mLen - i)) == "000") i += 3;
                        if (i < mLen && sNumber.Substring(i + 1, Math.Min(3, mLen - i)) == "000") i += 3;
                        break;
                    case 3:
                        mTemp += " nghìn";
                        if (sNumber.Substring(i + 1, Math.Min(3, mLen - i)) == "000") i += 3;
                        break;
                    default:
                        switch ((mLen - i) % 3)
                        {
                            case 2: mTemp += " trăm"; break;
                            case 1: mTemp += " mươi"; break;
                        }
                        break;
                }
            }
            mTemp = mTemp.Replace("không mươi không ", "");
            mTemp = mTemp.Replace("không mươi không", "");
            mTemp = mTemp.Replace("không mươi ", "linh ");
            mTemp = mTemp.Replace("mươi không", "mươi");
            mTemp = mTemp.Replace("một mươi", "mười");
            mTemp = mTemp.Replace("mươi bốn", "mươi tư");
            mTemp = mTemp.Replace("linh bốn", "linh tư");
            mTemp = mTemp.Replace("mươi năm", "mươi lăm");
            mTemp = mTemp.Replace("mươi một", "mươi mốt");
            mTemp = mTemp.Replace("mười năm", "mười lăm");
            mTemp = mTemp.Trim();
            return mTemp.Substring(0, 1).ToUpper() + mTemp.Substring(1) + " đồng";
        }
    }
}
