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
                if (cn.Conectar().State == ConnectionState.Open)
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
                string comandoSql = "exec  mostrarUbicacion @idBarrio = " + idBarrio + "";
                cmd.CommandText = comandoSql;
                if (cn != null && cn.Conectar().State == ConnectionState.Closed)
                {
                    cn.Conectar();
                }
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    ubicacion[0] = dr.GetInt32(0);
                    ubicacion[1] = dr.GetInt32(1);
                    ubicacion[2] = dr.GetInt32(2);
                    ubicacion[3] = dr.GetInt32(3);
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
            return ubicacion;
        }

    }
}

