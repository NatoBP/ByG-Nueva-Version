using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos.Clases
{
    public class CaracteristicaPropiedad
    {
        Int32 id;
        string caracteristica;
        string descripcion;
        Int32 valor;
        double importe;

        public CaracteristicaPropiedad()
        {
            id = 0;
            caracteristica = "";
            descripcion = "";
            valor = 0;
            importe = 0;
        }

        public CaracteristicaPropiedad(Int32 id, string nombre, Int32 valor)
        {
            this.id = id;
            this.caracteristica = nombre;
            this.valor = valor;

        }

        public CaracteristicaPropiedad(Int32 id, string nombre, string descripcion, double importe)
        {
            this.id = id;
            this.caracteristica = nombre;
            this.descripcion = descripcion;
            this.importe = importe;
        }

        public CaracteristicaPropiedad(Int32 id, Int32 valor)
        {
            this.id = id;
            this.caracteristica = "";
            this.valor = valor;
        }

        //PROPIEDADES
        public Int32 pId
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

        public Int32 pValor
        {
            set { valor = value; }
            get { return valor; }
        }

        public double pImporte
        {
            set { importe = value; }
            get { return importe; }
        }


        //TO STRING
        public override string ToString()
        {
            return caracteristica + " = " + valor;

        }
    }
}

