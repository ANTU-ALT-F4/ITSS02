using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ITSS02
{
    class ChuoiKetNoi
    {
        // xóa làm lại 10 lần không nhìn
        public static string Sqlcon = @"Data Source=FIT;Initial Catalog=ITSS02;User ID=sa;Password=123456";
        private static SqlConnection cn;

        public void Open()
        {
            cn.Open();
        }

        public void Close() 
        {
            cn.Close();
        }

        public static SqlDataAdapter ad;
        public static DataTable dt;
        public static SqlCommandBuilder bd;
        public static SqlCommand cmd;

        public static void hienthi(string chuoi, DataGridView db1)
        {
            ad = new SqlDataAdapter(chuoi, Sqlcon);
            dt = new DataTable();
            bd = new SqlCommandBuilder(ad);
            ad.Fill(dt);
            db1.DataSource = dt;
        }

        public static void xulycbb(string chuoi, ComboBox cbx)
        {
            try
            {
                ad = new SqlDataAdapter(chuoi, Sqlcon);
                dt = new DataTable();

                ad.Fill(dt);
                cbx.DataSource = dt;
            }catch(Exception ex)
            {
                MessageBox.Show("Có Lỗi " + ex);
            }
        }

        public static void GuiYeuCau(string sql)
        {
            cn = new SqlConnection(Sqlcon);
            cn.Open();
            SqlCommand cmd = new SqlCommand(sql, cn);
            cmd.ExecuteNonQuery();
            cn.Close();
        }
    }
}
