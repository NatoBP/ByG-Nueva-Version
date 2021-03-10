using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace AccesoDatos
{
    public abstract class Conexion
    {
        protected SqlConnection getConnection()
        {
            return new SqlConnection(@"Data Source=localhost;Initial Catalog=BustosGuidoneInmobiliaria;Integrated Security=True");
        }

    }
}
