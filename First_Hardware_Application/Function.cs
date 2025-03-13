using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace First_Hardware_Application
{
    class Function
    {
        private SqlConnection Con;
        private SqlCommand Cmd;
        private DataTable dt;
        private string ConStr;
        private SqlDataAdapter Sda;

        public Function()
        {
            ConStr = @"Data Source=DESKTOP-OP7MDE7\SQLEXPRESS;Initial Catalog=HardwareBD;Integrated Security=True;Encrypt=True;TrustServerCertificate=True;";
            
            Con = new SqlConnection(ConStr);
            Cmd = new SqlCommand();
            Cmd.Connection = Con;
        }
        public DataTable GetData(string Query)
        {
            dt = new DataTable();
            Sda = new SqlDataAdapter(Query, ConStr);
            Sda.Fill(dt);
            return dt;
        }
        public int SetData(string Query)
        {
            int Cnt;
            if (Con.State == ConnectionState.Closed)
            {
                Con.Open();
            }
            Cmd.CommandText = Query;
            Cnt = Cmd.ExecuteNonQuery();
            Con.Close();
            return Cnt;
        }
        
    }
}
