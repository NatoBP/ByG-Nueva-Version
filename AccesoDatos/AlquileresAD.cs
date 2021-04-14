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
                else if (apellido == "" && nombre != "")
                {
                    ds = new DataSet(); ;
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
                    cmd.CommandText = "buscarAlquileresV";
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
                else if (apellido == "" && nombre != "")
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
                    cmd.CommandText = "buscarAlquileresV";
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

        public void insertarContrato(Persona p)
        {
            try
            {
                cmd.Connection = cn.Conectar();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "insertarContrato";
                cmd.Parameters.Clear();
                //cmd.Parameters.Add();


                //var param = new SqlParameter[] { new SqlParameter("@idPropiedad", c.IdPropiedad),
                //                 new SqlParameter("@dniInquilino", c.DniInquilino),
                //                 new SqlParameter("@tipoDni", c.TipoDniInquilino),
                //                 new SqlParameter("@duracion", c.Duracion),
                //                 new SqlParameter("@precio", c.PrecioAlquiler),
                //                 new SqlParameter("@interesDiario", c.InteresDiario),
                //                 new SqlParameter("@deposito", c.Deposito),
                //                 new SqlParameter("@usoPropiedad", c.UsoPropiedad),
                //                 new SqlParameter("@vigencia", c.Vigencia),
                //                 new SqlParameter("@1raFecha", c.Fecha1raActualizacion),
                //                 new SqlParameter("@1erAumento", c.Aumento1raActualizacion),
                //                 new SqlParameter("@2daFecha", c.Fecha2daActualizacion),
                //                 new SqlParameter("@2doAumento", c.Aumento2daActualizacion),
                //                 new SqlParameter("@bajalogica", 1),
                //                 new SqlParameter("@fechaBaja", c.Vigencia),
                //                 new SqlParameter("@fechaInicio", c.FechaInicioContrato)};

                //ad.ExecProcedure("insertarContrato", param, ref data);


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
    }
}
