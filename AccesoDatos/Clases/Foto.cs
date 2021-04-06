using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos.Clases
{
    public class Foto
    {
        int idPropiedad;
        string descripcion;
        byte[] fotoBinaria;

        public Foto()
        {
            this.idPropiedad = 0;
            this.fotoBinaria = null;
            this.descripcion = "";
        }

        public Foto(int idPropiedad, string descripcion, byte[] fotoB)
        {
            this.idPropiedad = idPropiedad;
            this.descripcion = descripcion;
            this.fotoBinaria = fotoB;
        }
        
        public int pIdPropiedad { get => idPropiedad; set => idPropiedad = value; }

        public byte[] pFotoBinaria { get => fotoBinaria; set => fotoBinaria = value; }

        public string pDescripcion { get => descripcion; set => descripcion = value; }

        public override string ToString()
        {
            return "Descripción: " + pDescripcion + "\n" +
                   "ID-propiedad: " +  pIdPropiedad;
        }
    }
}
