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
        DataTable dt = new DataTable();
        Propiedad p;


        //PROPIEDADES
        public void InsertarPropiedad(Propiedad p)
        {
            try
            {
                cmd.Connection = cn.Conectar();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "CargarPropiedad";

                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@fkdueñoDNI", p.pDni);
                cmd.Parameters.AddWithValue("@fkTipoDNI", p.pTipoDNI);
                cmd.Parameters.AddWithValue("@calle", p.pCalle);
                cmd.Parameters.AddWithValue("@numeroCalle", p.pNumeroCalle);
                cmd.Parameters.AddWithValue("@fkbarrio", p.pBarrio);
                cmd.Parameters.AddWithValue("@descripcion", p.pDescripcion);
                cmd.Parameters.AddWithValue("@fk_tipoPropiedad", p.TipoPropiedad);
                cmd.Parameters.AddWithValue("@dpto", p.pDpto);
                cmd.Parameters.AddWithValue("@piso", p.pPiso);
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

        public void ModificarPropiedad(Propiedad p)
        {
            try
            {
                cmd.Connection = cn.Conectar();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "modificarPropiedad";

                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@idPropiedad",p.pId_propiedad);
                cmd.Parameters.AddWithValue("@calle", p.pCalle);
                cmd.Parameters.AddWithValue("@numeroCalle", p.pNumeroCalle);
                cmd.Parameters.AddWithValue("@barrio", p.pBarrio);
                cmd.Parameters.AddWithValue("@descripcion", p.pDescripcion);
                cmd.Parameters.AddWithValue("@tipoPropiedad", p.TipoPropiedad);
                cmd.Parameters.AddWithValue("@depto", p.pDpto);
                cmd.Parameters.AddWithValue("@piso", p.pPiso);

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
            return lista;
        }

        public List<LocadorDTO> BuscarPropiedadPorNombreDireccion(string apellido, string direccion)
        {
            List<LocadorDTO> lista = new List<LocadorDTO>();

            try
            {
                cmd.Connection = cn.Conectar();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "buscarPropiedadApellidoDireccion";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@apellido", apellido);
                cmd.Parameters.AddWithValue("@direccion", direccion);
                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    Int32 Id = dr.GetInt32(0);
                    string Apellido = dr.GetString(1);
                    string Nombre = dr.GetString(2);
                    string Calle = dr.GetString(3);
                    Int32 Nro = dr.GetInt32(4);
                    Int32 piso = dr.GetInt32(5);
                    string depto = dr.GetString(6);
                    string descripcion = dr.GetString(7);
                    Int32 tipoPropiedad = Convert.ToInt32(dr.GetValue(8));
                    Int32 idBarrio = dr.GetInt32(9);
                    string Barrio = dr.GetString(10);
                    string Ciudad = dr.GetString(11);
                    string deparatamento = dr.GetString(12);
                    string provincia = dr.GetString(13);
                    Int32 TipoDni = Convert.ToInt32(dr.GetValue(14));
                    Int32 Dni = Convert.ToInt32(dr.GetValue(15));

                    LocadorDTO prop = new LocadorDTO(Id, Dni, TipoDni, Nombre, Apellido, Calle, Nro, piso, depto, descripcion, tipoPropiedad, idBarrio, Barrio, Ciudad, deparatamento, provincia);
                    lista.Add(prop);
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
            return lista;
        }

        public int BuscarIdPropiedad()
        {
            int id = 0;
            try
            {
                cmd.Connection = cn.Conectar();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "Select Max(id_Propiedad) from Propiedades";

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
        } //Busca el ID de la última propiedad registrada

        public DTOPropiedad buscarDTOPropiedad(int id) //Busca la propiedad para armar el Contrato
        {
            DTOPropiedad prop = new DTOPropiedad();
            try
            {
                cmd.Connection = cn.Conectar();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "cargarDtoPropiedad";

                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@idPropiedad", id);
                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    prop.Calle = Convert.ToString(dr.GetValue(0));
                    prop.NumeroCalle = Convert.ToInt32(dr.GetValue(1));
                    prop.Ciudad = Convert.ToString(dr.GetValue(2));
                    prop.Provincia = Convert.ToString(dr.GetValue(3));
                    prop.Observaciones = Convert.ToString(dr.GetValue(4));
                    prop.TipoPropiedad = Convert.ToString(dr.GetValue(5));
                    prop.Piso = Convert.ToInt32(dr.GetValue(6));
                    prop.Dpto = Convert.ToString(dr.GetValue(7));
                    prop.Superficie = Convert.ToInt32(dr.GetValue(8));
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
            return prop;
        } 

        public bool VerificarPropiedad(string calle, Int32 numero, Int32 piso, string depto, Int32 ciudad)
        {
            bool existe = false;

            try
            {
                cmd.Connection = cn.Conectar();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "buscarPropiedadDuplicada";

                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@calle", calle);
                cmd.Parameters.AddWithValue("@numero", numero);
                cmd.Parameters.AddWithValue("@piso", piso);
                cmd.Parameters.AddWithValue("@depto", depto);
                cmd.Parameters.AddWithValue("@ciudad", ciudad);

                if (Convert.ToInt32(cmd.ExecuteScalar()) > 0)
                    existe = true;

                else
                    existe = false;
            }
            catch (Exception e)
            {
                MessageBox.Show("Error: " + e.ToString());
            }
            finally
            {
                cn.Desconectar();
            }
            return existe;
        }

        //CARACTERISTICAS
        public void InsertarCaracteristicas(CaracteristicaPropiedad c, int id)
        {
            try
            {
                cmd.Connection = cn.Conectar();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "CargarCaracteristicas"; //El mismo método sirve para inserciones nuevas o actualizaciones

                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@idCaracteristic", c.pId);
                cmd.Parameters.AddWithValue("@idPropiedad", id);
                cmd.Parameters.AddWithValue("@valor", c.pValor);

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

        public List<CaracteristicaPropiedad> CargarCaracteristicas(int id)
        {
            p = new Propiedad();
            try
            {
                cmd.Connection = cn.Conectar();

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "mostrarCaracteristicas";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@idProp", id);

                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    CaracteristicaPropiedad c = new CaracteristicaPropiedad();

                    c.pId = dr.GetInt32(0);
                    c.pValor = dr.GetInt32(1);
                    c.pCaracteristica = dr.GetString(2);

                    p.agregarCaracteristica(c);
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
            return p.Caracteristicas;
        }

        //FOTOS
        public List<Foto> buscarFoto(int idPropiedad) //Busca las fotos para el visor
        {
            p = new Propiedad();
            try
            {
                cmd.Connection = cn.Conectar();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT idFoto, foto FROM Fotos WHERE fkidPropiedad = @idPropiedad";

                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@idPropiedad", idPropiedad);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    int id = dr.GetInt32(0);
                    byte[] foto = (byte[])dr["foto"];
                    String descripcion = "";
                    Foto f = new Foto(id, descripcion, foto);
                    p.agregarFotos(f);
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
            return p.ListaFotos;
        }

        public void guardarFoto(byte[] foto, int idPropiedad)
        {
            try
            {
                cmd.Connection = cn.Conectar();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "INSERT INTO Fotos (fkidPropiedad,foto) values (@idPropiedad,@Foto)";

                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@Foto", foto);
                cmd.Parameters.AddWithValue("@idPropiedad", idPropiedad);

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


        //public Propiedad buscarDatosPropiedad(Int32 idProp) //carga dgv de propiedadesAlta
        //{
        //    DatosTotalesProp prop = null;
        //    try
        //    {
        //        Conectar();
        //        string comandoSql = "SELECT p.calle, p.numeroCalle, p.piso, p.dpto, p.descripcion, t.id_tipoPropiedad, b.id_barrio, c.id_ciudad, d.id_departamento, pr.id_provincia" +
        //                                 " FROM Propiedades p JOIN Barrios b ON b.id_barrio = p.fkbarrio" +
        //                                             " JOIN Ciudades c ON c.id_ciudad = b.ciudad" +
        //                                             " JOIN Departamentos d ON c.departamento = d.id_departamento" +
        //                                             " JOIN Provincias pr ON d.provincia = pr.id_provincia" +
        //                                             " JOIN TipoPropiedades t ON p.fk_tipoPropiedad = t.id_tipoPropiedad" +
        //                                     " WHERE p.id_propiedad = " + idProp;

        //        cmd.CommandText = comandoSql;
        //        dr = cmd.ExecuteReader();
        //        if (dr.Read())
        //        {
        //            String calle = dr.GetString(0);
        //            Int32 nro = Convert.ToInt32(dr.GetValue(1));
        //            Int32 piso = Convert.ToInt32(dr.GetValue(2));
        //            String dpto = dr.GetString(3);
        //            String obs = dr.GetString(4);
        //            Int32 tipo = Convert.ToInt32(dr.GetValue(5));
        //            Int32 barrio = Convert.ToInt32(dr.GetValue(6));
        //            Int32 ciudad = Convert.ToInt32(dr.GetValue(7));
        //            Int32 departamento = Convert.ToInt32(dr.GetValue(8));
        //            Int32 provincia = Convert.ToInt32(dr.GetValue(9));

        //            prop = new DatosTotalesProp(calle, nro, piso, dpto, obs, tipo, barrio, ciudad, departamento, provincia);
        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        MessageBox.Show("Error: " + e.ToString());
        //    }
        //    finally
        //    {
        //        Desconectar();
        //    }
        //    return prop;
        //}
    }
}
