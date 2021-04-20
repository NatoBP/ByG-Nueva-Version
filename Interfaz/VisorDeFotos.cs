using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AccesoDatos.Clases;
using AccesoDatos;
using System.IO;

namespace Interfaz
{
    public partial class VisorDeFotos : Form
    {
        PropiedadAD pAd = new PropiedadAD();
        List<Foto> listaFotos = new List<Foto>();

        int posicion = 1;
        int items = 0;

        public VisorDeFotos(int id)
        {
            InitializeComponent();
            listaFotos = pAd.buscarFoto(id);

            if (listaFotos.Count == 0)
            {
                MessageBox.Show("No se han cargado fotos de esta propiedad");
                noHayFotos();
            }
            else
            {
                foreach (var item in listaFotos)
                {
                    pctFotos.Image = convertir(item.pFotoBinaria);
                    break;
                }
                items = listaFotos.Count;
            }
        }

        private void pctCerrar_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void btnAdelantar_Click(object sender, EventArgs e)
        {
            if (posicion < items - 1 && listaFotos.Count != 0)
            {
                posicion++;
                pctFotos.Image = convertir(listaFotos[posicion].pFotoBinaria);
            }

        }

        private void btnRetroceder_Click(object sender, EventArgs e)
        {
            if (posicion > 0 && listaFotos.Count != 0)
            {
                posicion--;

                pctFotos.Image = convertir(listaFotos[posicion].pFotoBinaria);
            }
        }

        public Image convertir(byte[] bytesArr)
        {
            using (MemoryStream memstr = new MemoryStream(bytesArr))
            {
                Image img = Image.FromStream(memstr);
                return img;
            }
        }

        public int noHayFotos()
        {
            int num = listaFotos.Count;
            return num;
        }

        
        
    }
}
