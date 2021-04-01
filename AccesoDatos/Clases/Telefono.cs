using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos
{
    public class Telefono
    {
        private Int32 idTelefono;
        private Int32 fkIdDocumento;
        private Int32 fkIdTipoDNI;
        private string numero;
        private string codigoArea;
        //constructores
        public Telefono()
        {
            idTelefono = 0;
            fkIdDocumento = 0;
            fkIdTipoDNI = 0;
            numero = "";
            codigoArea = "";
        }
        public Telefono(Int32 idTelefono, Int32 fkIdDocumento, Int32 fkIdTipoDNI, string numero, string codigoArea)
        {
            this.idTelefono = idTelefono;
            this.fkIdDocumento = fkIdDocumento;
            this.fkIdTipoDNI = fkIdTipoDNI;
            this.numero = numero;
            this.codigoArea = codigoArea;
        }//propiedades
        public Int32 pIdTelefono
        {
            set { idTelefono = value; }
            get { return idTelefono; }
        }
        public Int32 pfkIdDocumento
        {
            set { fkIdDocumento = value; }
            get { return fkIdDocumento; }
        }
        public Int32 pfkIdTipoDNI
        {
            set { fkIdTipoDNI = value; }
            get { return fkIdTipoDNI; }
        }
        public string pnumero
        {
            set { numero = value; }
            get { return numero; }
        }
        public string pcodigoArea
        {
            set { codigoArea = value; }
            get { return codigoArea; }
        }
        public override string ToString()
        {
            return codigoArea + " " + numero;
        }
    }
}
