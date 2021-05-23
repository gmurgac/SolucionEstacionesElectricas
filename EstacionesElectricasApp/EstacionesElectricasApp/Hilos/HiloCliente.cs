using EstacionesModel.DAL;
using EstacionesModel.DTO;
using SocketsUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstacionesElectricasApp.Hilos
{
    public class HiloCliente
    {

        private ServerSocket serverSocket;
        static IMedidoresDAL dal = MedidoresDALFactory.CreateDAL();
        static IMedicionesDAL dalMediciones = MedicionesDALFactory.CreateDAL();
        public HiloCliente(ServerSocket serverSocket)
        {

            this.serverSocket = serverSocket;
        }

        public void Ejecutar()
        {
            Medicion lectura = new Medicion() { Id = 0};
            try
            {
                
                
                string lectura1 = serverSocket.Leer().Trim();
                string[] textoArray = lectura1.Split('|');
                string[] fechas = textoArray[0].Split('-');
                lectura.Id = Convert.ToInt32(textoArray[1]);
                lectura.Tipo = textoArray[2];
                try
                {
                    DateTime actual;
                    int anio = Convert.ToInt32(fechas[0]);
                    int mes = Convert.ToInt32(fechas[1]);
                    int dia = Convert.ToInt32(fechas[2]);
                    int horas = Convert.ToInt32(fechas[3]);
                    int minutos = Convert.ToInt32(fechas[4]);
                    int segundos = Convert.ToInt32(fechas[5]);
                    actual = new DateTime(anio, mes, dia, horas, minutos, segundos);

                    lectura.Fecha = actual;



                    if (dal.EncontrarMedidor(lectura.Id, lectura.Tipo))
                    {

                        int diferenciaMinutos = (lectura.Fecha - DateTime.Now).Minutes;
                        if (diferenciaMinutos > 30)
                        {
                            serverSocket.Escribir("" + lectura.Fecha + "|" + lectura.Id + "|ERROR");
                            serverSocket.CerrarConexion();
                        }
                        else
                        {
                            
                            string respuesta = "" + DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss") + "|WAIT";
                            serverSocket.Escribir(respuesta);
                            string lectura2 = serverSocket.Leer().Trim();
                            //EVALUAR SI VIENE CON ESTADO O NO
                            string[] textoArray2 = lectura2.Split('|');
                            int largoLectura = textoArray2.Length;
                            //FIN EVALUAR ESTADO


                            

                            if (largoLectura == 6)
                            {

                                //Agregar valor y estado  


                                lectura.Valor = Convert.ToInt32(textoArray2[3]);
                                lectura.Estado = Convert.ToInt32(textoArray2[4]);
                            }
                            else if (largoLectura == 5)
                            {

                                lectura.Valor = Convert.ToInt32(textoArray2[3]);
                                
                            }
                            if (lectura.Tipo == "trafico")
                            {
                                if (lectura.Valor > 1000 | lectura.Valor < 0 | lectura.Estado < -1 | lectura.Estado > 2)
                                {
                                    throw new Exception();
                                }
                                lock (dalMediciones)
                                {
                                    dalMediciones.RegistrarLectura(lectura);
                                    serverSocket.Escribir(lectura.Id + "|OK");
                                    serverSocket.CerrarConexion();
                                }

                            }
                            else if (lectura.Tipo == "consumo")
                            {
                                if (lectura.Valor > 1000 | lectura.Valor < 0 | lectura.Estado < -1 | lectura.Estado > 2)
                                {
                                    throw new Exception();
                                }
                               
                                lock (dalMediciones)
                                {
                                    dalMediciones.RegistrarLectura(lectura);
                                    serverSocket.Escribir(lectura.Id + "|OK");
                                    serverSocket.CerrarConexion();
                                }

                            }
                            else
                            {
                                serverSocket.Escribir("" + DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss") + "|" + textoArray2[0] + "|ERROR");
                                serverSocket.CerrarConexion();
                            }
                        }


                    }

                    else
                    {
                        serverSocket.Escribir("" + DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss") + "|" + lectura.Id + "|ERROR");
                        serverSocket.CerrarConexion();
                    }






                }
                catch (Exception ex)
                {
                    serverSocket.Escribir("" + DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss") + "|" + lectura.Id + "|ERROR");
                    serverSocket.CerrarConexion();
                }

            }
            catch (Exception ex)
            {
                
                serverSocket.Escribir("" + DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss") + "|" + lectura.Id + "|ERROR");
                serverSocket.CerrarConexion();
            }
        }
    }
}
