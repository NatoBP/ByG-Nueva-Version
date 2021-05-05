using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using AccesoDatos.Clases;

namespace AccesoDatos
{
    public class EstadoCuentaAD
    {
        private Conexion cn = new Conexion();
        SqlCommand cmd = new SqlCommand();
        DataSet ds;
        SqlDataAdapter da;
        SqlDataReader dr;

        public DataSet buscarEstadoCuenta(int dni, int tipoDNI)
        {
            try
            {
                ds = new DataSet();
                cmd.Connection = cn.Conectar();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "EstadoCuentaPersona_1";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id_dni", dni);
                cmd.Parameters.AddWithValue("@tipoDNI", tipoDNI);
                da = new SqlDataAdapter(cmd);
                da.Fill(ds);
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


        //INSERCIÓN DE DEUDAS

        public void insertarAsientoDeuda(Comprobante c)
        {
            try
            {
                cmd.Connection = cn.Conectar();

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "insertarAsientoDeudaPersona";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@dni", c.pdni);
                cmd.Parameters.AddWithValue("@tipo", c.ptipoDNI);
                cmd.Parameters.AddWithValue("@fecha", c.pfecha);
                cmd.Parameters.AddWithValue("@descripcion", c.pDescripcion);

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

        public void guardarItemAsiento(List<CaracteristicaPropiedad> itemReci)
        {
            int idDeuda = consultaIdDeuda();
            try
            {
                for (int i = 0; i < itemReci.Count; i++)
                {
                    cmd.Connection = cn.Conectar();

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "cargarItemAsientoDeuda";
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@fk_comprobante", idDeuda);
                    cmd.Parameters.AddWithValue("@fk_itemComprobante", itemReci[i].pId);
                    cmd.Parameters.AddWithValue("@importe", itemReci[i].pImporte);
                    cmd.Parameters.AddWithValue("@descripcion", itemReci[i].pDescripcion);

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

        public DataSet consultaAsientoDeudaCompleto(int id)
        {
            try
            {
                ds = new DataSet();
                cmd.Connection = cn.Conectar();

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "buscarDeudaPorIdDeuda";

                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", id);
                da = new SqlDataAdapter(cmd);

                da.Fill(ds);
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

        private Int32 consultaIdDeuda()
        {
            Int32 id = 0;
            try
            {
                cmd.Connection = cn.Conectar();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "Select Max(id_DeudaPersona) from DeudasPersonas";

                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    id = dr.GetInt32(0);
                    break;
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

            return id;
        }



        //INSERCIÓN DE COMPROBANTES

        public void insertarComprobante(Comprobante c)
        {
            try
            {
                cmd.Connection = cn.Conectar();

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "insertarComprobante";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@dni", c.pdni);
                cmd.Parameters.AddWithValue("@tipo", c.ptipoDNI);
                cmd.Parameters.AddWithValue("@fecha", c.pfecha);
                cmd.Parameters.AddWithValue("@descripcion", c.pDescripcion);

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

        public void guardarItemRecibo(List<CaracteristicaPropiedad> itemReci)
        {
            int idComprobante = consultaIdComprobante();
            try
            {
                for (int i = 0; i < itemReci.Count; i++)
                {
                    cmd.Connection = cn.Conectar();

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "cargarItemRecibo";
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@fk_comprobante", idComprobante);
                    cmd.Parameters.AddWithValue("@fk_itemComprobante", itemReci[i].pId);
                    cmd.Parameters.AddWithValue("@importe", itemReci[i].pImporte);
                    cmd.Parameters.AddWithValue("@descripcion", itemReci[i].pDescripcion);

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

        public DataSet consultaComprobanteCompleto(int id)
        {
            try
            {
                ds = new DataSet();
                cmd.Connection = cn.Conectar();

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "buscarComprobantePorId";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", id);

                da = new SqlDataAdapter(cmd);

                da.Fill(ds);
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

        private Int32 consultaIdComprobante()
        {
            Int32 id = 0;
            try
            {
                cmd.Connection = cn.Conectar();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "Select Max(id_comprobante) from Comprobantes";

                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    id = dr.GetInt32(0);
                    break;
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

            return id;
        }
    }
}
