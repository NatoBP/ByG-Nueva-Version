using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos.Clases
{
    public class DTOPropiedad
    {
        private string calle;
        private int numeroCalle;
        private string ciudad;
        private string provincia;
        private string observaciones;
        private string tipoPropiedad;
        private int piso;
        private string dpto;
        private double superficie;

        public string Calle { get => calle; set => calle = value; }
        public int NumeroCalle { get => numeroCalle; set => numeroCalle = value; }
        public string Ciudad { get => ciudad; set => ciudad = value; }
        public string Provincia { get => provincia; set => provincia = value; }
        public string Observaciones { get => observaciones; set => observaciones = value; }
        public string TipoPropiedad { get => tipoPropiedad; set => tipoPropiedad = value; }
        public int Piso { get => piso; set => piso = value; }
        public string Dpto { get => dpto; set => dpto = value; }
        public double Superficie { get => superficie; set => superficie = value; }

        public DTOPropiedad(string calle, int numeroCalle, string ciudad, string provincia, string observaciones, string tipoPropiedad, int piso, string dpto, double superficie)
        {
            this.Calle = calle;
            this.NumeroCalle = numeroCalle;
            this.Ciudad = ciudad;
            this.Provincia = provincia;
            this.Observaciones = observaciones;
            this.TipoPropiedad = tipoPropiedad;
            this.Piso = piso;
            this.Dpto = dpto;
            this.Superficie = superficie;
        }

        public DTOPropiedad()
        {
            this.Calle = "";
            this.NumeroCalle = 0;
            this.Ciudad = "";
            this.Provincia = "";
            this.Observaciones = "";
            this.TipoPropiedad = "";
            this.Piso = 0;
            this.Dpto = "";
            this.Superficie = 0;
        }

    }
}
