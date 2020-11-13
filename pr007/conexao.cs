using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pr007
{
    public class conexao
    {
        //classe que realiza a conexão e o ato de conectar e desconectar
        SqlConnection conn = new SqlConnection();
        public conexao()
        {
            string stringconn = @"Data Source=(LocalDb)\BDLocal;Initial Catalog=teste;Integrated Security=True";
            conn.ConnectionString = stringconn;

        }
        public SqlConnection conectar()
        {
            if (conn.State==System.Data.ConnectionState.Closed)
            {
                conn.Open();
            }
            return conn;
        }
        public SqlConnection desconectar()
        {
            if (conn.State == System.Data.ConnectionState.Open)
            {
                conn.Close();
            }
            return conn;
        }
    }
}
