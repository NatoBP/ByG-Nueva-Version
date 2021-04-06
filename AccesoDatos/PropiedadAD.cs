using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using AccesoDatos.Clases;
using System.Windows.Forms;

namespace AccesoDatos
{
    public class PropiedadAD
    {
        private Conexion cn = new Conexion();
        SqlCommand cmd = new SqlCommand();
        SqlDataReader dr;


        public List<Propiedad> CargarListaPropiedades(Int32 dni, Int32 tipoDNI)
        {
            List<Propiedad> lista = new List<Propiedad>();

            try
            {
                cmd.Connection = cn.Conectar();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "mostrarPropiedades";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("dueñoDNI", dni);
                cmd.Parameters.AddWithValue("dueñoTipoDNI", tipoDNI);

                if (cn != null && cn.Conectar().State == ConnectionState.Closed)
                {
                    cn.Conectar();
                }
                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    Propiedad p = new Propiedad();
                    p.pId_propiedad = Convert.ToInt32(dr.GetValue(0));
                    p.pDni = Convert.ToInt32(dr.GetValue(1));
                    p.pTipoDNI = Convert.ToInt32(dr.GetValue(2));
                    p.pCalle = Convert.ToString(dr.GetValue(3));
                    p.pNumeroCalle = Convert.ToInt32(dr.GetValue(4));
                    p.pBarrio = Convert.ToInt32(dr.GetValue(5));
                    p.pDescripcion = Convert.ToString(dr.GetValue(6));
                    p.TipoPropiedad = Convert.ToInt32(dr.GetValue(7));
                    p.pDpto = Convert.ToString(dr.GetValue(8));
                    p.pPiso = Convert.ToInt32(dr.GetValue(9));

                    lista.Add(p);
                }

            }
            catch (Exception e)
            {
                MessageBox.Show("Error: " + e.ToString());
            }
            finally
            {
                cn.Desconectar();
            }
            return lista;
        }
    }
}
