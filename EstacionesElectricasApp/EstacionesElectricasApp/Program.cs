using EstacionesElectricasApp.Hilos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Configuration;

namespace EstacionesElectricasApp
{
    public partial class Program
    {
        public static void Main(string[] args)
        {

            Console.WriteLine("Iniciando hilo del Server");
            int puerto = Convert.ToInt32(ConfigurationManager.AppSettings["puerto"]);
            HiloServer hiloServer = new HiloServer(puerto);
            Thread t = new Thread(new ThreadStart(hiloServer.Ejecutar));
            t.IsBackground = true;
            t.Start();
            while (true) ;
        }
    }
}
