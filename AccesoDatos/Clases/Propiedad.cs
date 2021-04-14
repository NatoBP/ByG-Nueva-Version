using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos.Clases
{
    public class Propiedad
    {
        Int32 id_propiedad;
        Int32 dni;
        Int32 tipoDNI;
        string calle;
        Int32 numeroCalle;
        Int32 barrio;
        Int32 ciudad;
        Int32 departamento;
        Int32 provincia;
        string descripcion;
        Int32 tipoPropiedad;
        Int32 piso;
        string dpto;
        List<CaracteristicaPropiedad> caracteristicas;
        List<Foto> listaFotos;

        //constructores
        public Propiedad()
        {
            id_propiedad = 0;
            dni = 0;
            tipoDNI = 0;
            calle = "";
            numeroCalle = 0;
            barrio = 0;
            ciudad = 0;
            departamento = 0;
            provincia = 0;
            descripcion = "";
            listaFotos = new List<Foto>();
            caracteristicas = new List<CaracteristicaPropiedad>();
        }

        public Propiedad(Int32 id_propiedad, Int32 dni, Int32 tipoDNI, string calle, Int32 numeroCalle,
                         Int32 barrio, Int32 ciudad, Int32 departamento, Int32 provincia, string descripcion,
                         float precioAlquiler, Int32 tipoPropiedad, Int32 piso, string dpto)
        {
            this.id_propiedad = id_propiedad;
            this.dni = dni;
            this.tipoDNI = tipoDNI;
            this.calle = calle;
            this.numeroCalle = numeroCalle;
            this.barrio = barrio;
            this.ciudad = ciudad;
            this.departamento = departamento;
            this.provincia = provincia;
            this.descripcion = descripcion;
            this.tipoPropiedad = tipoPropiedad;
            this.piso = piso;
            this.dpto = dpto;
        }

        public void agregarCaracteristica(CaracteristicaPropiedad c)
        {
            if (c != null)
                caracteristicas.Add(c);
            else
                return;
        }

        public void agregarFotos(Foto f)
        {
            listaFotos.Add(f);
        }

        public List<CaracteristicaPropiedad> Caracteristicas { get => caracteristicas; }

        public List<Foto> ListaFotos { get => listaFotos; }

        //PROPIEDADES
        public Int32 pId_propiedad
        {
            set { id_propiedad = value; }
            get { return id_propiedad; }
        }
        public Int32 pDni
        {
            set { dni = value; }
            get { return dni; }
        }
        public Int32 pTipoDNI
        {
            set { tipoDNI = value; }
            get { return tipoDNI; }
        }
        public string pCalle
        {
            set { calle = value; }
            get { return calle; }
        }
        public Int32 pNumeroCalle
        {
            set { numeroCalle = value; }
            get { return numeroCalle; }
        }
        public Int32 pPiso
        {
            set { piso = value; }
            get { return piso; }
        }
        public string pDpto
        {
            set { dpto = value; }
            get { return dpto; }
        }
        public Int32 pBarrio
        {
            set { barrio = value; }
            get { return barrio; }
        }
        public Int32 pCiudad
        {
            set { ciudad = value; }
            get { return ciudad; }
        }
        public Int32 pDepartamento
        {
            set { departamento = value; }
            get { return departamento; }
        }
        public Int32 pProvincia
        {
            set { provincia = value; }
            get { return provincia; }
        }
        public string pDescripcion
        {
            set { descripcion = value; }
            get { return descripcion; }
        }

        public Int32 TipoPropiedad
        {
            set { tipoPropiedad = value; }
            get { return tipoPropiedad; }
        }

        //TO STRING
        public override string ToString()
        {
            return barrio + ", " + calle + ", " + numeroCalle;
        }
    }
}

