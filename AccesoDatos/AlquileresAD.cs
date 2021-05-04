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
    public class AlquileresAD
    {

        private Conexion cn = new Conexion();
        SqlCommand cmd = new SqlCommand();
        DataTable dt;
        DataSet ds;
        SqlDataAdapter da;

        public DataSet buscarContratoVigente(string apellido, string nombre)
        {
            try
            {
                if (nombre == "" && apellido != "")
                {
                    ds = new DataSet();
                    cmd.Connection = cn.Conectar();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "BuscarPorApellido";
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@apellido", apellido);
                    da = new SqlDataAdapter(cmd);
                    da.Fill(ds);
                }
                else if (nombre != "" && apellido == "")
                {
                    ds = new DataSet(); 
                    cmd.Connection = cn.Conectar();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "BuscarPorNombre";
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@nombre", nombre);
                    da = new SqlDataAdapter(cmd);
                    da.Fill(ds);
                }
                else
                {
                    ds = new DataSet();
                    cmd.Connection = cn.Conectar();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "BuscarAlquileresV";
                    cmd.Parameters.Clear();
                    da = new SqlDataAdapter(cmd);
                    da.Fill(ds);
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

            return ds;
        }

        public DataSet buscarContratoNoVigente(string apellido, string nombre)
        {
            try
            {
                if (nombre == "" && apellido != "")
                {
                    ds = new DataSet();
                    cmd.Connection = cn.Conectar();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "BuscarPorApellidoNoV";
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@apellido", apellido);
                    da = new SqlDataAdapter(cmd);
                    da.Fill(ds);
                }
                else if (nombre != "" && apellido == "")
                {
                    ds = new DataSet(); ;
                    cmd.Connection = cn.Conectar();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "BuscarPorNombreNoV";
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@nombre", nombre);
                    da = new SqlDataAdapter(cmd);
                    da.Fill(ds);
                }
                else
                {
                    ds = new DataSet();
                    cmd.Connection = cn.Conectar();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "buscarAlquileresNoV";
                    cmd.Parameters.Clear();
                    da = new SqlDataAdapter(cmd);
                    da.Fill(ds);
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

            return ds;
        }

        public int buscarIdContrato()
        {
            int id = 0;

            try
            {
                cmd.Connection = cn.Conectar();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "Select Max(id_Contrato) from ContratosAlquiler";
                id = Convert.ToInt32(cmd.ExecuteScalar());
            }
            catch (Exception e)
            {
                MessageBox.Show("Error: " + e.ToString());
            }
            finally
            {
                cn.Desconectar();
            }

            return id;
        }

        public void insertarContrato(Contrato c)
        {
            try
            {
                cmd.Connection = cn.Conectar();
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.CommandText = "insertarContrato";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@idPropiedad", c.IdPropiedad);
                cmd.Parameters.AddWithValue("@dniInquilino", c.DniInquilino);
                cmd.Parameters.AddWithValue("@tipoDni", c.TipoDniInquilino);
                cmd.Parameters.AddWithValue("@duracion", c.Duracion);
                cmd.Parameters.AddWithValue("@precio",c.PrecioAlquiler);
                cmd.Parameters.AddWithValue("@interesDiario", c.InteresDiario);
                cmd.Parameters.AddWithValue("@deposito", c.Deposito);
                cmd.Parameters.AddWithValue("@usoPropiedad", c.UsoPropiedad);
                cmd.Parameters.AddWithValue("@vigencia", c.Vigencia);
                cmd.Parameters.AddWithValue("@1raFecha", c.Fecha1raActualizacion);
                cmd.Parameters.AddWithValue("@1erAumento", c.Aumento1raActualizacion);
                cmd.Parameters.AddWithValue("@2daFecha", c.Fecha2daActualizacion);
                cmd.Parameters.AddWithValue("@2doAumento", c.Aumento2daActualizacion);
                cmd.Parameters.AddWithValue("@bajalogica", 1);
                cmd.Parameters.AddWithValue("@fechaBaja", c.Vigencia);
                cmd.Parameters.AddWithValue("@fechaInicio", c.FechaInicioContrato);

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

        public void bajaContrato(DateTime fecha, Int32 id)
        {
            try
            {
                cmd.Connection = cn.Conectar();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "update ContratosAlquiler set bajaLogica = 0, fechaBaja = @fecha where id_Contrato = @id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@fecha", fecha);
                cmd.Parameters.AddWithValue("@id", id);
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

        public void InsertarGarante(Persona g, int idContrato)
        {
            try
            {
                cmd.Connection = cn.Conectar();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "insertarGarante";

                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@dni", g.pDNI);
                cmd.Parameters.AddWithValue("@tipoDNI", g.pTipoDNI);
                cmd.Parameters.AddWithValue("@sugerencias", "");
                cmd.Parameters.AddWithValue("@idContrato", idContrato);
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
    }
}
