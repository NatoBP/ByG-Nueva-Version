using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos.Clases
{
    public class CaracteristicaPropiedad
    {
        int id;
        string caracteristica;
        string descripcion;
        int valor;

        public CaracteristicaPropiedad()
        {
            id = 0;
            caracteristica = "";
            descripcion = "";
            valor = 0;
        }

        public CaracteristicaPropiedad(int idCaracteristica, string nombre, int valor)
        {
            this.id = idCaracteristica;
            this.caracteristica = nombre;
            this.valor = valor;

        }

        public CaracteristicaPropiedad(int idCaracteristica, string nombre, string descripcion)
        {
            this.id = idCaracteristica;
            this.caracteristica = nombre;
            this.descripcion = descripcion;
        }

        public CaracteristicaPropiedad(int idCaracteristica, int valor)
        {
            this.id = idCaracteristica;
            this.caracteristica = "";
            this.valor = valor;
        }

        //PROPIEDADES
        public int pId
        {
            set { id = value; }
            get { return id; }
        }

        public string pCaracteristica
        {
            set { caracteristica = value; }
            get { return caracteristica; }
        }

        public string pDescripcion
        {
            set { descripcion = value; }
            get { return descripcion; }
        }

        public int pValor
        {
            set { valor = value; }
            get { return valor; }
        }


        //TO STRING
        public override string ToString()
        {
            return caracteristica + " = " + valor;

        }
    }
}

