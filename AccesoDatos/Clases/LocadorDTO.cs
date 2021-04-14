using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos.Clases
{
    public class LocadorDTO
    {
        Int32 id;
        Int32 dni;
        Int32 tipoDni;
        string nombre;
        string apellido;
        string calle;
        Int32 nro;
        Int32 piso;
        string depto;
        string descripcion;
        Int32 tipoPropiedad;
        Int32 idBarrio;
        string barrio;
        string ciudad;
        string departamento;
        string provincia;


        public LocadorDTO(Int32 id, Int32 dni, Int32 tipoDni, string nombre, string apellido, string calle, Int32 nro, Int32 piso, string depto, string descripcion, Int32 tipoPropiedad, Int32 idBarrio, string barrio, string ciudad, string departamento, string provincia )
        {
            this.id = id;
            this.dni = dni;
            this.tipoDni = tipoDni;
            this.nombre = nombre;
            this.apellido = apellido;
            this.calle = calle;
            this.nro = nro;
            this.piso = piso;
            this.depto = depto;
            this.descripcion = descripcion;
            this.tipoPropiedad = tipoPropiedad;
            this.idBarrio = idBarrio;
            this.barrio = barrio;
            this.ciudad = ciudad;
            this.departamento = departamento;
            this.provincia = provincia;
        }

        public LocadorDTO()
        {
            dni = 0;
            tipoDni = 0;
            nombre = "";
            apellido = "";
            calle = "";
            nro = 0;
            Piso = 0;
            Depto = "";
            Descripcion = "";
            TipoPropiedad = 0;
            idBarrio = 0;
            barrio = "";
            ciudad = "";
            departamento = "";
            provincia = "";
        }
        public Int32 Id { get => id; set => id = value; }

        public Int32 Dni { get => dni; set => dni = value; }

        public Int32 TipoDni { get => tipoDni; set => tipoDni = value; }

        public string Nombre { get => nombre; set => nombre = value; }

        public string Apellido { get => apellido; set => apellido = value; }

        public string Calle { get => calle; set => calle = value; }

        public Int32 Nro { get => nro; set => nro = value; }
        
        public Int32 Piso { get => piso; set => piso = value; }

        public string Depto { get => depto; set => depto = value; }

        public string Descripcion { get => descripcion; set => descripcion = value; }

        public Int32 TipoPropiedad { get => tipoPropiedad; set => tipoPropiedad = value; }

        public Int32 IdBarrio { get => idBarrio; set => idBarrio = value; }

        public string Barrio { get => barrio; set => barrio = value; }

        public string Ciudad { get => ciudad; set => ciudad = value; }

        public string Departamento { get => departamento; set => departamento = value; }

        public string Provincia { get => provincia; set => provincia = value; }
    }
}
