using SocketsUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EstacionesElectricasApp.Hilos
{
    public class HiloServer
    {
        private int puerto;
        private ServerSocket server;
        public HiloServer(int puerto)
        {
            this.puerto = puerto;
        }

        public void Ejecutar()
        {
            Console.WriteLine("Iniciando servidor en puerto: {0}", puerto);
            this.server = new ServerSocket(puerto);
            if (this.server.Iniciar())
            {
                Console.WriteLine("Servidor iniciado");
                while (true)
                {
                    Console.WriteLine("Esperando Clientes....");
                    ClienteSocket cliente = this.server.ObtenerCliente();
                    if(cliente != null)
                    {  //Crear una instancia del hilo del Cliente

                        Console.WriteLine("Se conectò un cliente");
                        HiloCliente hiloCliente = new HiloCliente(cliente, server);
                        Thread t = new Thread(new ThreadStart(hiloCliente.Ejecutar));
                        t.IsBackground = false;
                        t.Start();
                    }
                   
                }
            }
        }
    }
}
