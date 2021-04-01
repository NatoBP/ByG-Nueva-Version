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
    }
}

