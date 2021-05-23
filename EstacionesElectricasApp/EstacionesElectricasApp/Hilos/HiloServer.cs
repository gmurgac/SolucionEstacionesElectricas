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
            
            this.server = new ServerSocket(puerto);
            if (this.server.Iniciar())
            {
                
                while (true)
                {
                    
                    if(this.server.ObtenerCliente())
                    {  //Crear una instancia del hilo del Cliente
                       
                        HiloCliente hiloCliente = new HiloCliente(server);
                        Thread t = new Thread(new ThreadStart(hiloCliente.Ejecutar));
                        t.IsBackground = false;
                        t.Start();
                    }
                   
                }
            }
        }
    }
}
