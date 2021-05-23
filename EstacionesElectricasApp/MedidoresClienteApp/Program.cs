



using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SocketsUtils;

namespace MedidoresClienteApp
{
    public partial class Program
    {
        
        public static void Main(string[] args)
        {
        string idMedidor;
        string tipoMedidor;
        string fechaMedicion;
        string valorMedicion;
        string estadoMedicion;
            string respuestaServidor;

        string ip = ConfigurationManager.AppSettings["ip"];
            int puerto = Convert.ToInt32(ConfigurationManager.AppSettings["puerto"]);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Iniciando conexion");
            ClienteSocket clienteSocket = new ClienteSocket(puerto, ip);
            if (clienteSocket.Conectar())
            {

                //Seleccion tipo de medidor , se obtiene tipo medidor,
                tipoMedidor = GetTipo();
                //ingresar fecha
                fechaMedicion = GetFecha();
                //ingresar Id
                idMedidor = GetId();
                //Enviar a servidor
                clienteSocket.Escribir(fechaMedicion + "|" + idMedidor + "|" + tipoMedidor);

                //VALIDACION SERVER
                respuestaServidor = clienteSocket.Leer().Trim();

                string[] respuestaWait = respuestaServidor.Split('|');
                //CLIENTE DEBE COMPROBAR QUE VIENE COMANDO WAIT
                Console.WriteLine(respuestaServidor);
                if (respuestaWait[respuestaWait.Length-1] == "WAIT")
                {
                    
                    valorMedicion = GetValor();
                    estadoMedicion = GetEstado();
                    if(estadoMedicion == "")
                    {
                        
                        clienteSocket.Escribir(idMedidor + "|" + fechaMedicion + "|" + tipoMedidor + "|" + valorMedicion + "|" + "UPDATE"); //ESCRIBE nro|fecha|tipo|valor|{estado}opcional|UPDATE
                        Console.WriteLine(clienteSocket.Leer().Trim()); //Server envia Id|OK o FECHA|ID|ERROR
                        
                    }
                    else
                    {
                        clienteSocket.Escribir(idMedidor + "|" + fechaMedicion + "|" + tipoMedidor + "|" + valorMedicion + "|" + estadoMedicion + "|" + "UPDATE"); //ESCRIBE nro|fecha|tipo|valor|{estado}opcional|UPDATE
                        Console.WriteLine(clienteSocket.Leer().Trim()); //Server envia Id|OK o FECHA|ID|ERROR
                    }
                    


                }
               
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("No se pudo conectar");

            }

            
           
            //Console.ReadKey();
        }
        }
    }

