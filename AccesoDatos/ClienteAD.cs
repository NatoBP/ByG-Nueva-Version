using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AccesoDatos
{
    public class ClienteAD
    {
        private Conexion cn = new Conexion();
        SqlCommand cmd = new SqlCommand();
        SqlDataReader dr;
        SqlDataAdapter da;
        DataTable dt;
                     
        //VERIFICAR EXISTENCIA EN BD
        public int VerificarPersona(Int32 tipoDNI, Int32 dni)
        {
            cmd.Connection = cn.Conectar();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Select Count(*) From Personas Where tipoDNI = @tipo AND id_DNI = @dni";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@tipo", tipoDNI);
            cmd.Parameters.AddWithValue("@dni", dni);
            cmd.ExecuteScalar();

            if (Convert.ToInt32(cmd.ExecuteScalar()) > 0)
            {
                cn.Desconectar();
                return 1;
            }

            else
            {
                cn.Desconectar();
                return 0;
            }
        }

        //BUSCA UNA PERSONA Y LA CARGA EN UN DATATABLE
        public DataTable BuscarPersona(Int32 tipoDNI, Int32 dni )
        {
            dt = new DataTable();

            try
            {
                cmd.Connection = cn.Conectar();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "exec BuscarTodo";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@tipoDNI", tipoDNI);
                cmd.Parameters.AddWithValue("@dni", dni);
                dt.Load(cmd.ExecuteReader());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.ToString());
            }
            finally
            {
                cn.Desconectar();
            }
            return dt;
        }

        public void InsertarPersona(Persona p)
        {
            try
            {
                cmd.Connection = cn.Conectar();

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "incertarPersona";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@dni", p.pDNI);
                cmd.Parameters.AddWithValue("@tipDNI", p.pTipoDNI);
                cmd.Parameters.AddWithValue("@nombre", p.pNombre);
                cmd.Parameters.AddWithValue("@apellidos", p.pApellido);
                cmd.Parameters.AddWithValue("@calle", p.pDireccion);
                cmd.Parameters.AddWithValue("@numeroCalle", p.pAltura);
                if (p.pBarrio == 0)
                {
                    p.pBarrio = 3;
                    cmd.Parameters.AddWithValue("@barrio", p.pBarrio);
                }
                else
                    cmd.Parameters.AddWithValue("@barrio", p.pBarrio);
                cmd.Parameters.AddWithValue("@mail", p.pMail);
                cmd.Parameters.AddWithValue("@piso", p.pPiso);
                cmd.Parameters.AddWithValue("@depto", p.pDepto);

                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                MessageBox.Show("Error: " + e.ToString());
            }
            finally
            {
                cn.Desconectar();
            }
        }

        public void InsertarTelefono(List<Telefono> telefono)
        {
            try
            {
                cmd.Connection = cn.Conectar();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "insertarTelefono";
                cmd.Parameters.Clear();
                foreach (var item in telefono)
                {
                    cmd.Parameters.AddWithValue("@idTelefono", item.pIdTelefono);
                    cmd.Parameters.AddWithValue("@idDNI", item.pfkIdDocumento);
                    cmd.Parameters.AddWithValue("@idtipoDNI", item.pfkIdTipoDNI);
                    cmd.Parameters.AddWithValue("@numero", item.pnumero);
                    cmd.Parameters.AddWithValue("@codigoArea", item.pcodigoArea);
                    cmd.ExecuteNonQuery();
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
        }
    }


}
