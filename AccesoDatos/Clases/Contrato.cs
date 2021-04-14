using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos.Clases
{
    public class Contrato
    {

        Int32 idPropiedad;
        Int32 idContrato;
        Int32 dniInquilino;
        Int32 tipoDniInquilino;
        Int32 duracion;
        double precioAlquiler;
        Decimal interesDiario;
        double deposito;
        DateTime vigencia;
        Int32 usoPropiedad;
        Int32 diaDeVencimiento;
        DateTime fechaInicioContrato;
        DateTime fecha1raActualizacion;
        double aumento1raActualizacion;
        DateTime fecha2daActualizacion;
        double aumento2daActualizacion;
        List<Persona> listaGarante;
        DateTime fechaFin;


        public Contrato()
        {
            idPropiedad = 0;
            idContrato = 0;
            dniInquilino = 0;
            tipoDniInquilino = 0;
            duracion = 0;
            precioAlquiler = 0;
            interesDiario = 0;
            deposito = 0;
            diaDeVencimiento = 0;
            fechaInicioContrato = DateTime.Today;
            fecha1raActualizacion = DateTime.Today;
            aumento1raActualizacion = 0;
            fecha2daActualizacion = DateTime.Today;
            aumento2daActualizacion = 0;
            vigencia = DateTime.Today;
            usoPropiedad = 0;
            listaGarante = new List<Persona>();
            fechaFin = DateTime.Today;
        }

        public Contrato(Int32 idPropiedad, Int32 idContrato, Int32 dniInquilino, Int32 tipoDniInquilino,
            Int32 duracion, double precioAlquiler, Decimal interesDiario, double deposito, Int32 diaDeVencimiento,
            DateTime fechaInicioContrato, Int32 periodoActualizacion, double porcentajeActualizacion,
            DateTime fecha1raActualizacion, double aumento1raActualizacion, DateTime fecha2daActualizacion,
            double aumento2daActualizacion, DateTime vigencia, Int32 usoPropiedad, DateTime fecFin)
        {
            this.idPropiedad = idPropiedad;
            this.idContrato = idContrato;
            this.dniInquilino = dniInquilino;
            this.tipoDniInquilino = tipoDniInquilino;
            this.duracion = duracion;
            this.precioAlquiler = precioAlquiler;
            this.interesDiario = interesDiario;
            this.deposito = deposito;
            this.diaDeVencimiento = diaDeVencimiento;
            this.fechaInicioContrato = fechaInicioContrato;
            this.fecha1raActualizacion = fecha1raActualizacion;
            this.aumento1raActualizacion = aumento1raActualizacion;
            this.fecha2daActualizacion = fecha2daActualizacion;
            this.aumento2daActualizacion = aumento2daActualizacion;
            this.vigencia = vigencia;
            this.usoPropiedad = usoPropiedad;
            fechaFin = fecFin;
        }

        public void agregarGarante(Persona g)
        {
            listaGarante.Add(g);
        }

        public List<Persona> devolverGarante()
        {
            return listaGarante;
        }

        public int IdPropiedad { get => idPropiedad; set => idPropiedad = value; }

        public int IdContrato { get => idContrato; set => idContrato = value; }

        public int DniInquilino { get => dniInquilino; set => dniInquilino = value; }

        public int TipoDniInquilino { get => tipoDniInquilino; set => tipoDniInquilino = value; }

        public int Duracion { get => duracion; set => duracion = value; }

        public double PrecioAlquiler { get => precioAlquiler; set => precioAlquiler = value; }

        public Decimal InteresDiario { get => interesDiario; set => interesDiario = value; }

        public double Deposito { get => deposito; set => deposito = value; }

        public DateTime Vigencia { get => vigencia; set => vigencia = value; }

        public Int32 UsoPropiedad { get => usoPropiedad; set => usoPropiedad = value; }

        public DateTime Fecha1raActualizacion { get => fecha1raActualizacion; set => fecha1raActualizacion = value; }

        public double Aumento1raActualizacion { get => aumento1raActualizacion; set => aumento1raActualizacion = value; }

        public DateTime Fecha2daActualizacion { get => fecha2daActualizacion; set => fecha2daActualizacion = value; }

        public double Aumento2daActualizacion { get => aumento2daActualizacion; set => aumento2daActualizacion = value; }

        public int DiaDeVencimiento { get => diaDeVencimiento; set => diaDeVencimiento = value; }

        public DateTime FechaInicioContrato { get => fechaInicioContrato; set => fechaInicioContrato = value; }

        public DateTime FechaFin { get => fechaFin; set => fechaFin = value; }

        public string toStringContrato()
        {
            return "Id Propiedad: " + idPropiedad + "\n" +
                "Id Contrato: " + idContrato + "\n" +
                "Dni Inquilino: " + dniInquilino + "\n" +
                "Precio Alquiler: " + precioAlquiler;
        }
    }

}
