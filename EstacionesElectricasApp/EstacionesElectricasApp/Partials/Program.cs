using EstacionesElectricasApp.Hilos;
using EstacionesModel.DAL;
using EstacionesModel.DTO;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EstacionesElectricasApp
{
    public partial class Program
    {
        static void IniciarServicio()
        {
            int puerto;
            Console.Write("Elija puerto de escucha del servicio(Defecto 2500): ");
            string leerPuerto = Console.ReadLine().Trim();
            if (!leerPuerto.Equals(""))
            {
                try
                {
                    puerto = Convert.ToInt32(leerPuerto);
                }
                catch (Exception ex)
                {
                    puerto = Convert.ToInt32(ConfigurationManager.AppSettings["puerto"]);
                }

            }
            else
            {
                puerto = Convert.ToInt32(ConfigurationManager.AppSettings["puerto"]);
            }



            HiloServer hiloServer = new HiloServer(puerto);
            Thread t = new Thread(new ThreadStart(hiloServer.Ejecutar));
            t.IsBackground = true;
            t.Start();
        }

        static void VerRegistros()
        {

                Console.Write("Ver lecturas Trafico(Press 1) Consumo(Press 2): ");
                string leer = Console.ReadLine().Trim();
                if (leer == "1")
                {
                    List<Medicion> lecturas = dalMediciones.ObtenerLecturasTrafico();
                    lecturas.ForEach(l =>
                    {
                        Console.WriteLine(l);

                    });
                }
                else if (leer == "2")
                {
                    List<Medicion> lecturas = dalMediciones.ObtenerLecturasConsumo();
                    lecturas.ForEach(l =>
                    {
                        Console.WriteLine(l);

                    });
                }
                
            }


        }
    }
