using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedidoresClienteApp
{
    public partial class Program
    {
        static string GetTipo()
        {
            //LEER TIPO
            string tipo = "";
            string respuesta;
            do
            {
                Console.WriteLine("Seleccionar tipo de medidor [1]Trafico, [2]Consumo: ");
                
                respuesta = Console.ReadLine().Trim();
                switch (respuesta)
                {
                    case "1":
                       tipo  = "trafico";
                        break;
                    case "2":
                        tipo = "consumo";
                        break;
                    
                    default:
                        Console.WriteLine("tipo incorecto");
                        respuesta = string.Empty;
                        break;

                }

            } while (respuesta == string.Empty);
            return tipo;
        }

        static string GetFecha()
        {
            Console.Write("Ingresar Año: ");
            string anio = Console.ReadLine().Trim();
            Console.Write("Ingresar mes: ");
            string mes = Console.ReadLine().Trim();
            Console.Write("Ingresar dia: ");
            string dia = Console.ReadLine().Trim();
            Console.Write("Ingresar hora: ");
            string hora = Console.ReadLine().Trim();
            Console.Write("Ingresar minutos: ");
            string minutos = Console.ReadLine().Trim();
            Console.Write("Ingresar segundos: ");
            string segundos = Console.ReadLine().Trim();

            string fecha = anio + "-" + mes + "-" + dia + "-" + hora + "-" + minutos + "-" + segundos;
            return fecha;
        }

        static string GetId()
        {
            Console.Write("Ingresar Id de Medidor: ");
            string id = Console.ReadLine().Trim();
            return id;
        }

        static string GetValor()
        {
            Console.Write("Ingresar valor de medicion: ");
            string valor = Console.ReadLine().Trim();
            return valor;
        }

        static string GetEstado()
        {
            Console.Write("Ingresar estado: ");
            string estado = Console.ReadLine().Trim();
            return estado;
                
        }



    }
}
