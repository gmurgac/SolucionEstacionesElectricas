



using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SocketsUtils;

namespace MedidoresClienteApp
{
    public class Program
    {
        public static void Main(string[] args)
        {

            string ip = ConfigurationManager.AppSettings["ip"];
            int puerto = Convert.ToInt32(ConfigurationManager.AppSettings["puerto"]);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Iniciando conexion");
            SocketsUtils.ClienteSocket clienteSocket = new SocketsUtils.ClienteSocket(puerto, ip);
            if (clienteSocket.Conectar())
            {
                Console.WriteLine("Conectado");
                //Protocolo de comunicacion
                string mensajeServer = "";

                Console.WriteLine(clienteSocket.Leer().Trim()); //Servidor envia ingrese fecha|nro |tipo
                string respuestaCli = Console.ReadLine().Trim(); //cliente responde
                clienteSocket.Escribir(respuestaCli);
                Console.WriteLine(clienteSocket.Leer().Trim()); //servidor envia |WAIT
                                                                //CLIENTE DEBE COMPROBAR QUE VIENE COMANDO WAIT
                respuestaCli = Console.ReadLine().Trim();
                clienteSocket.Escribir(respuestaCli); //ESCRIBE nro|fecha|tipo|valor|{estado}opcional|UPDATE
                clienteSocket.CerrarConexion();
                Console.ReadKey();


            }
            else {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Error al conectar");
                Console.ReadKey();
            }



        }
        }
    }

