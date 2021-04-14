using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos.Clases
{
    public class Comprobante
    {
        Int32 id_comprobante;
        Int32 dni;
        Int32 tipoDNI;
        DateTime fecha;
        string nombre;
        string direccion;
        List<CaracteristicaPropiedad> itemRecibo;
        string descripcion;
        Int32 idContrato;

        Comprobante(Int32 id_compr, Int32 dni, Int32 tipoDNI, DateTime fec, string nom, string dire, List<CaracteristicaPropiedad> itemRec,
            string descri, Int32 idCont)
        {
            this.id_comprobante = id_compr;
            this.dni = dni;
            this.tipoDNI = tipoDNI;
            this.fecha = fec;
            this.nombre = nom;
            this.direccion = dire;
            itemRecibo = itemRec;
            this.descripcion = descri;
            idContrato = idCont;

        }
        public Comprobante()
        {
            id_comprobante = 0;
            dni = 0;
            tipoDNI = 0;
            fecha = DateTime.Today;
            nombre = "";
            direccion = "";
            itemRecibo = new List<CaracteristicaPropiedad>();
            descripcion = "";
            idContrato = 0;
        }

        public double calcularTotal()
        {
            double totalC = 0;
            foreach (var item in itemRecibo)
            {
                totalC += item.pImporte;
            }
            return totalC;
        }

        public void agregarItems(CaracteristicaPropiedad cp)
        {
            itemRecibo.Add(cp);
        }

        public List<CaracteristicaPropiedad> pItem
        {
            get { return itemRecibo; }
        }

        public Int32 pidComprobante
        {
            set { id_comprobante = value; }
            get { return id_comprobante; }
        }

        public Int32 pdni
        {
            set { dni = value; }
            get { return dni; }
        }

        public Int32 ptipoDNI
        {
            set { tipoDNI = value; }
            get { return tipoDNI; }
        }

        public DateTime pfecha
        {
            get { return fecha; }
            set { fecha = value; }
        }

        public string pNombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        public string pDireccion
        {
            get { return direccion; }
            set { direccion = value; }
        }

        public string pDescripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }

        public Int32 pidContrato
        {
            set { idContrato = value; }
            get { return idContrato; }
        }


        //TO STRING
        public string toStringComprobante()
        {
            return "Comprobante: \n" +
                "Total: " + calcularTotal() + "\n" +
                "Descripción: " + pDescripcion;
        }
    }
}

