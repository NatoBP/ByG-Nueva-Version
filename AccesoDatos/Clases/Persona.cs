using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccesoDatos;

namespace AccesoDatos.Clases
{
     public class Persona
    {
         Int32 dni;
         Int32 tipoDni;
         string apellido;
         string nombre;
         List<Telefono> telefono;
         string mail;
         string direccion;
         Int32 altura; //A veces puede no tener número y se guarda como s/n(sin número)
         Int32 piso;
         string depto;
         Int32 barrio;
         Int32 ciudad;
         Int32 departamento;
         Int32 provincia;
         string observaciones;

        
        public Persona()
        {
            dni = 0;
            tipoDni = 0;
            apellido = "";
            nombre = "";
            telefono = new List<Telefono>();
            mail = "";
            direccion = "";
            altura = 0;
            piso = 0;
            depto = "";
            barrio = 0;
            ciudad = 0;
            departamento = 0;
            provincia = 0;
            observaciones = "";
        }

        public Persona(Int32 dni, Int32 tipoDni, string apellido, string nombre, string mail, string direccion,
            Int32 altura, Int32 piso, string depto, Int32 barrio, Int32 ciudad, Int32 departamento, Int32 provincia, string observaciones)
        {
            this.dni = dni;
            this.tipoDni = tipoDni;
            this.apellido = apellido;
            this.nombre = nombre;
            this.mail = mail;
            this.direccion = direccion;
            this.altura = altura;
            this.barrio = barrio;
            this.ciudad = ciudad;
            this.departamento = departamento;
            this.provincia = provincia;
            this.observaciones = observaciones;
        }


        public void agregarTelefono(Telefono t)
        {
            telefono.Add(t);
        }

        public Int32 pDNI
        {
            get { return dni; }
            set { dni = value; }
        }

        public Int32 pTipoDNI
        {
            get { return tipoDni; }
            set { tipoDni = value; }
        }

        public string pApellido
        {
            get { return apellido; }
            set { apellido = value; }
        }

        public string pNombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        public List<Telefono> pTelefono 
        {
            get { return telefono; }
            set { telefono = value; }
        }

        public string pMail
        {
            get { return mail; }
            set { mail = value; }
        }

        public string pDireccion
        {
            get { return direccion; }
            set { direccion = value; }
        }

        public Int32 pAltura
        {
            get { return altura; }
            set { altura = value; }
        }

        public Int32 pPiso
        {
            get { return piso; }
            set { piso = value; }
        }

        public string pDepto
        {
            get { return depto; }
            set { depto = value; }
        }

        public Int32 pBarrio
        {
            get { return barrio; }
            set { barrio = value; }
        }

        public Int32 pciudad
        {
            get { return ciudad; }
            set { ciudad = value; }
        }

        public Int32 pdepartamento
        {
            get { return departamento; }
            set { departamento = value; }
        }

        public Int32 pProvincia
        {
            get { return provincia; }
            set { provincia = value; }
        }

        public string pObservaciones
        {
            get { return observaciones; }
            set { observaciones = value; }
        }

        public override string ToString()
        {
            return "Datos: \n" +
                "" + "D.N.I.: " + pDNI + "\n" +
                "" + "Apellido: " + pApellido + "\n" +
                "" + "Nombre: " + pNombre + "\n" +
                "" + "Teléfono: " + pTelefono + "\n" +
                "" + "e-mail: " + pMail + "\n" +
                "" + "Dirección: " + pDireccion + " n° " + pAltura + "\n" +
                "" + "Barrio: " + pBarrio + "\n" +
                "" + "Localidad: " + pciudad + "\n" +
                "" + "Departamento: " + pdepartamento + "\n" +
                "" + "Provincia: " + pProvincia + "\n" +
                "" + "Observaciones: " + pObservaciones;
        }
    }
}
