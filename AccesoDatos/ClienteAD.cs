using AccesoDatos.Clases;
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

        Persona p;

        //Verficicar Existencia en BD
        public int VerificarPersona(Int32 tipoDNI, Int32 dni)
        {
            int i = 0;
            try
            {
                cmd.Connection = cn.Conectar();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "Select Count(*) From Personas Where tipoDNI = @tipo AND id_DNI = @dni and bajaLogica = 1";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@tipo", tipoDNI);
                cmd.Parameters.AddWithValue("@dni", dni);

                if (Convert.ToInt32(cmd.ExecuteScalar()) > 0)
                    i = 1;

                else
                    i = 0;
            }
            catch (Exception e)
            {
                MessageBox.Show("Error: " + e.ToString());
            }
            finally
            {
                cn.Desconectar();
            }
            return i;
        }

        //Buscar Persona por DNI
        public Persona BuscarPersona(Int32 tipoDNI, Int32 dni )
        {
            p = new Persona();
            try
            {
                cmd.Connection = cn.Conectar();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "BuscarTodo";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@tipo", tipoDNI);
                cmd.Parameters.AddWithValue("@dni", dni);
                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    p.pDNI = dr.GetInt32(0);
                    p.pTipoDNI = Convert.ToInt32(dr.GetValue(1));
                    p.pApellido = Convert.ToString(dr.GetValue(2));
                    p.pNombre = Convert.ToString(dr.GetValue(3));
                    p.pDireccion = Convert.ToString(dr.GetValue(4));
                    p.pAltura = Convert.ToInt32(dr.GetValue(5));
                    p.pPiso = dr.GetInt32(6);
                    p.pDepto = Convert.ToString(dr.GetValue(7));
                    p.pMail = Convert.ToString(dr.GetValue(8));
                    p.pBarrio = Convert.ToInt32(dr.GetValue(9));
                    p.pciudad = Convert.ToInt32(dr.GetValue(10));
                    p.pdepartamento = Convert.ToInt32(dr.GetValue(11));
                    p.pProvincia = Convert.ToInt32(dr.GetValue(12));
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
            return p;
        }

        //Buscar Persona por Apellido
        public Persona BuscarPersonaPorApellido(string apellido)
        {
            p = new Persona();
            try
            {
                cmd.Connection = cn.Conectar();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "buscarPersonaPorApellido";

                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@apellido", apellido);
                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    p.pDNI = dr.GetInt32(0);
                    p.pTipoDNI = Convert.ToInt32(dr.GetValue(1));
                    p.pApellido = Convert.ToString(dr.GetValue(2));
                    p.pNombre = Convert.ToString(dr.GetValue(3));
                    p.pDireccion = Convert.ToString(dr.GetValue(4));
                    p.pAltura = Convert.ToInt32(dr.GetValue(5));
                    p.pPiso = dr.GetInt32(6);
                    p.pDepto = Convert.ToString(dr.GetValue(7));
                    p.pMail = Convert.ToString(dr.GetValue(8));
                    p.pBarrio = Convert.ToInt32(dr.GetValue(9));
                    p.pciudad = Convert.ToInt32(dr.GetValue(10));
                    p.pdepartamento = Convert.ToInt32(dr.GetValue(11));
                    p.pProvincia = Convert.ToInt32(dr.GetValue(12));
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
            return p;
        }
        
        //Insertar Persona
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
                cn.Desconectar();

                if (p.pTelefono.Count > 0)
                    InsertarTelefono(p.pTelefono);
            }
            catch (Exception e)
            {
                MessageBox.Show("Error: " + e.ToString());
            }
            
        }

        //Modificar Persona
        public void modificarPersona(Persona p)
        {
            try
            {
                cmd.Connection = cn.Conectar();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "modificarPersona";

                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@dni", p.pDNI);
                cmd.Parameters.AddWithValue("@tipDNI", p.pTipoDNI);
                cmd.Parameters.AddWithValue("@nombre", p.pNombre);
                cmd.Parameters.AddWithValue("@apellidos", p.pApellido);
                cmd.Parameters.AddWithValue("@calle", p.pDireccion);
                cmd.Parameters.AddWithValue("@numeroCalle", p.pAltura);
                cmd.Parameters.AddWithValue("@barrio", p.pBarrio);
                cmd.Parameters.AddWithValue("@mail", p.pMail);
                cmd.Parameters.AddWithValue("@piso", p.pPiso);
                cmd.Parameters.AddWithValue("@depto", p.pDepto);

                cmd.ExecuteNonQuery();
                cn.Desconectar();

                if (p.pTelefono.Count > 0)
                    InsertarTelefono(p.pTelefono);
            }
            catch (Exception e)
            {
                MessageBox.Show("Error: " + e.ToString());
            }
            
        }

        //Borrar Persona
        public void borrarPersona(Persona p)
        {
            try
            {
                cmd.Connection = cn.Conectar();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "BajaPersona";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@dni", p.pDNI);
                cmd.Parameters.AddWithValue("@tipoDNI", p.pTipoDNI);
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

        //Buscar Teléfono
        public List<Telefono> buscarTelefonos(int tipoDNI, int dni) 
        {
            Persona p = new Persona();
            p.pTelefono.Clear();
            try
            {
                cmd.Connection = cn.Conectar();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "mostrarTelefonos";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@dni", dni);
                cmd.Parameters.AddWithValue("@tipoDNI", tipoDNI);
                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    Telefono t = new Telefono();
                    
                    t.pIdTelefono = Convert.ToInt32(dr.GetValue(0));
                    t.pfkIdDocumento = Convert.ToInt32(dr.GetValue(1));
                    t.pfkIdTipoDNI = Convert.ToInt32(dr.GetValue(2));
                    t.pnumero = Convert.ToString(dr.GetValue(3));
                    t.pcodigoArea = Convert.ToString(dr.GetValue(4));
                    p.agregarTelefono(t);
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
            return p.pTelefono;
        }

        //Insertar / Modificar Teléfono
        public void InsertarTelefono(List<Telefono> telefono)
        {
            try
            {
                foreach (var item in telefono)
                {
                    cmd.Connection = cn.Conectar();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "insertarTelefono";
                    cmd.Parameters.Clear();

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

        //Borrar Teléfono
        public void BorrarTelefono(Int32 id)
        {
            try
            {
                cmd.Connection = cn.Conectar();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "borrarTelefono";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@idTelefono", id);
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
