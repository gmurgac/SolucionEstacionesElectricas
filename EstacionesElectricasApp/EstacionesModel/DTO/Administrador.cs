using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstacionesModel.DTO
{
    class Administrador
    {
        private string rut;
        private string nombre;
        private string apellido;

        public void ReasignarPuntoDeCarga(PuntoDeCarga ptoDCarga, EstacionDeCarga estDCarga)
        {

        }

        public void RegistrarMonitor()
        {

        }
        public void VerMonitores()
        {

        }
        public void ModificarMonitor()
        {

        }
        public void DeshabilitarMonitor()
        {

        }
        public void RegistrarEstacion()
        {

        }
        public void VerEstaciones()
        {

        }
        public void ModificarEstacion()
        {

        }
        public void DeshabilitarEstacion()
        {

        }



        public string Rut
        {
            get
            {
                return rut;
            }

            set
            {
                rut = value;
            }
        }

        public string Nombre
        {
            get
            {
                return nombre;
            }

            set
            {
                nombre = value;
            }
        }

        public string Apellido
        {
            get
            {
                return apellido;
            }

            set
            {
                apellido = value;
            }
        }
    }
}
