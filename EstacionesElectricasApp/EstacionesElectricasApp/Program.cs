using EstacionesElectricasApp.Hilos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Configuration;
using EstacionesModel.DAL;
using EstacionesModel.DTO;

namespace EstacionesElectricasApp
{
    public partial class Program
    {
        static IMedicionesDAL dalMediciones = MedicionesDALFactory.CreateDAL();
        public static void Main(string[] args)
        {
            Boolean on = true;
            while (on)
            {
                Console.WriteLine("1. Iniciar Servicio\n2. Ver registro de mediciones");
                string respuesta = Console.ReadLine().Trim();
                switch (respuesta)
                {
                    case "1":
                        IniciarServicio();
                        break;
                    case "2":
                        VerRegistros();
                        break;
                }
            }
            
            
            
        }
    }
}
