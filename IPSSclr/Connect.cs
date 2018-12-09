using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;
using System.Data;
namespace IPSS
{
    public partial class Connect
    {
        private static Connect instance;
        public static String g_strConnect;
        public static SqlConnection m_conn;
        public static String g_user;
        /////////////////////////////////////////////////////////////////////////////////////////////////////
        public static Connect Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Connect();
                }
                return instance;
            }
        }
        /////////////////////////////////////////////////////////////////////////////////////////////////////
        void Connect_()
        {
            if (!string.IsNullOrEmpty(g_strConnect) && m_conn.State != ConnectionState.Open)
            {
                m_conn.Open();
            }
        }
        /////////////////////////////////////////////////////////////////////////////////////////////////////
        public void Disconnect()
        {
            if(g_strConnect !="" && m_conn.State != ConnectionState.Closed)
            {
                m_conn.Close();
            }   
        }
        /////////////////////////////////////////////////////////////////////////////////////////////////////
        public bool Init()
        {
            if (!File.Exists(Application.StartupPath + "\\setting.ini"))
                return false;
            g_strConnect = File.ReadAllText(Application.StartupPath + "\\setting.ini");
            m_conn = new SqlConnection(g_strConnect);
            try
            {
                Connect_();
                Disconnect();
                return true;
            }
            catch ( Exception ex)
            {
                MessageBox.Show("Có lỗi: " + ex.Message);
                return false;
            }
            
        }
        /////////////////////////////////////////////////////////////////////////////////////////////////////
        public object Find(string sql)
        {
            SqlCommand comm = new SqlCommand(sql, m_conn);
            Connect_();
            return comm.ExecuteScalar();
        }
        /////////////////////////////////////////////////////////////////////////////////////////////////////
        public bool RunSQL(string sql)
        {
            SqlCommand comm = new SqlCommand(sql, m_conn);
            Connect_();
            try
            {
                comm.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra: " + ex.Message);
                return false;
            }
        }
        /////////////////////////////////////////////////////////////////////////////////////////////////////
        public void ShowDGV(string sql, DataGridView dgv)
        {
            dgv.Columns.Clear();
            DataTable ds = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(sql, m_conn);
            da.Fill(ds);
            //Đổ dữ liệu vào bảng mới tạo
            dgv.DataSource = ds;
            Disconnect();
        }
        /////////////////////////////////////////////////////////////////////////////////////////////////////
        public DataTable GetDataTable(string sql)
        {
            DataTable ds = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(sql, m_conn);
            da.Fill(ds);
            //Đổ dữ liệu vào bảng mới tạo
            Disconnect();
            return ds;
        }
        /////////////////////////////////////////////////////////////////////////////////////////////////////
        public void ShowCB(string sql, System.Windows.Forms.ComboBox cb)
        {
            cb.Items.Clear();
            SqlCommand comm = new SqlCommand(sql, m_conn);
            Connect_();
            SqlDataReader dr = comm.ExecuteReader();
            while (dr.Read())
            {
                for (int i = 0; i <= dr.FieldCount - 1; i++)
                {
                    cb.Items.Add(dr.GetValue(i));
                }
            }
            Disconnect();
        }
    }
}
