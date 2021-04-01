using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace AccesoDatos
{
    class Conexion
    {
        private SqlConnection cn = new SqlConnection(@"Data Source=localhost;Initial Catalog=BustosGuidoneInmobiliaria;Integrated Security=True");

        public SqlConnection Conectar()
        {

            
            if (cn.State == ConnectionState.Closed)
                cn.Open();
            return cn;
        }


        public SqlConnection Desconectar()
        {
            if (cn.State == ConnectionState.Open)
                cn.Close();
            return cn;
        }
    }
}
