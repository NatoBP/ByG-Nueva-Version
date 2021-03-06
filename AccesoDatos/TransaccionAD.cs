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
    public class TransaccionAD
    {
        private Conexion cn = new Conexion();
        SqlCommand cmd;
        DataTable dt;
        SqlDataReader dr;

        //INSERTAR BARRIO
        public void insertarBarrio(string nombre, int id_ciudad)
        {
            try
            {
                cmd = new SqlCommand();
                cmd.Connection = cn.Conectar();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "insertarBarrio";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@nombreB", nombre);
                cmd.Parameters.AddWithValue("@idCiudad", id_ciudad);
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

        //TRAER COMBOS UBICACIÓN
        public void traerCombo(ComboBox cbo, string nombreTabla, string id_tabla, string display, string condicion, int idfk)
        {
            try
            {
                if (idfk == -1)
                {
                    cmd = new SqlCommand();
                    cmd.Connection = cn.Conectar();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "SELECT * FROM " + nombreTabla;
                    dt = new DataTable();
                    cn.Conectar();
                    dt.Load(cmd.ExecuteReader());
                    cbo.ValueMember = id_tabla;
                    cbo.DisplayMember = display;
                    cbo.DataSource = dt;
                    cbo.DropDownStyle = ComboBoxStyle.DropDownList;
                }
                else
                {
                    cmd = new SqlCommand();
                    cmd.Connection = cn.Conectar();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "SELECT * FROM " + nombreTabla + " where " + condicion + " = " + idfk;
                    dt = new DataTable();
                    cn.Conectar();
                    dt.Load(cmd.ExecuteReader());
                    cbo.ValueMember = id_tabla;
                    cbo.DisplayMember = display;
                    cbo.DataSource = dt;
                    cbo.DropDownStyle = ComboBoxStyle.DropDownList;
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

        //BUSCAR UBICACIÓN POR BARRIO
        public int[] buscarUbicacion(int idBarrio)
        {
            int[] ubicacion = new int[4];
            try
            {
                cmd.Connection = cn.Conectar();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "mostrarUbicacion";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@idBarrio", idBarrio);
                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    ubicacion[0] = dr.GetInt32(0);
                    ubicacion[1] = dr.GetInt32(1);
                    ubicacion[2] = dr.GetInt32(2);
                    ubicacion[3] = dr.GetInt32(3);
                }
                dr.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show("Error: " + e.ToString());
            }
            finally
            {
                cn.Desconectar();
            }
            return ubicacion;
        }

        //BUSCAR NOMBRE CIUDAD
        public string buscarCiudad(int id)
        {
            String valor = "";
            try
            {
                cmd.Connection = cn.Conectar();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "buscarNombreCiudad";

                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@idBarrio", id);

                cmd.Parameters.Add("@nombreCiudad", SqlDbType.VarChar, 50);
                cmd.Parameters["@nombreCiudad"].Direction = ParameterDirection.Output;

                int i = cmd.ExecuteNonQuery();

                valor = Convert.ToString(cmd.Parameters["@nombreCiudad"].Value);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.ToString());
            }
            finally
            {
                cn.Desconectar();
            }
            return valor;
        }

        //BUSCAR NOMBRE
        public string buscarNombre(string campos, string tablas, string condicion)
        {
            string valor = "";
            try
            {
                cmd.Connection = cn.Conectar();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "Select " + campos + " From " + tablas + " Where " + condicion + "";
                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    valor = dr.GetString(0);
                }
                dr.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.ToString());
            }
            finally
            {
                cn.Desconectar();
            }
            return valor;
        }
    }
}

