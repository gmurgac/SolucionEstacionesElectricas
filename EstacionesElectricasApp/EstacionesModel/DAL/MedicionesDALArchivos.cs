using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EstacionesModel.DTO;
using System.IO;
using Newtonsoft.Json;

namespace EstacionesModel.DAL
{
    public class MedicionesDALArchivos : IMedicionesDAL
    {

        //Crear atributo
        private string archivo = Directory.GetCurrentDirectory()
            + Path.DirectorySeparatorChar + "trafico.txt";
        private string archivo2 = Directory.GetCurrentDirectory()
            + Path.DirectorySeparatorChar + "consumo.txt";
        

        private MedicionesDALArchivos()
        {

        }
        private static IMedicionesDAL instancia;

        public static IMedicionesDAL GetInstance()
        {
            if (instancia == null)
                instancia = new MedicionesDALArchivos();
            return instancia;

            
        }

        //public List<Medicion> ObtenerLecturasConsumo()
        //{
        //    List<Medicion> lista = new List<Medicion>();

        //    try
        //    {
        //        using (StreamReader reader = new StreamReader(archivo2))
        //        {
        //            string lineaTexto = null;
        //            do
        //            {
        //                if (lineaTexto != null)
        //                {
        //                    string[] textoArray = lineaTexto.Split(':');
        //                    Medicion m = new Medicion()
        //                    {
        //                        Id = Convert.ToInt32(textoArray[0]),
        //                        Fecha = Convert.ToDateTime(textoArray[1]),
        //                        Tipo = Convert.ToInt32(textoArray[2]),
        //                        Valor = textoArray[3]

        //                    };
        //                }
        //            } while (lineaTexto != null);
        //        }
        //    }
        //    catch (IOException ex)
        //    {
        //        lista = null;
        //    }
        //    return lista;
        //}

        //public List<Medicion> ObtenerLecturasTrafico()
        //{
        //    List<Medicion> lista = new List<Medicion>();

        //    try {
        //        using (StreamReader reader = new StreamReader(archivo))
        //        {
        //            string lineaTexto = null;
        //            do
        //            {
        //                if(lineaTexto != null)
        //                {
        //                    string[] textoArray = lineaTexto.Split('|');
        //                    Medicion m = new Medicion()
        //                    {
        //                        Id = Convert.ToInt32(textoArray[0]),
        //                        Fecha = Convert.ToDateTime(textoArray[1]),
        //                        Tipo = Convert.ToInt32(textoArray[2]),
        //                        Valor = textoArray[3]

        //                    };
        //                }
        //            } while (lineaTexto != null);
        //        }
        //    }
        //    catch(IOException ex) {
        //        lista = null;
        //    }
        //    return lista;
        //}

        public void RegistrarConsumo(Medicion m)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(archivo, true))
                {
                    writer.WriteLine(m);
                    writer.Flush();
                }
            }catch(IOException ex)
            {

            }
        }
        public void RegistrarTrafico(Medicion m)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(archivo2, true))
                {
                    writer.WriteLine(m);
                    writer.Flush();
                }
            }
            catch (IOException ex)
            {

            }
        }

        public void RegistrarLectura(Medicion m)
        {
            //COLOCAR AQUI IF, SI m es de tipo trafico realiazr registro trafico sino .... etc
            if(m.Tipo == "trafico")
            {
                try
                {
                    using (StreamWriter writer = new StreamWriter(archivo, true))
                    {
                        writer.WriteLine(JsonConvert.SerializeObject(m));
                        writer.Flush();
                    }
                }
                catch (IOException ex)
                {

                }
            }else if(m.Tipo == "consumo")
            {
                try
                {
                    using (StreamWriter writer = new StreamWriter(archivo2, true))
                    {

                        writer.WriteLine(JsonConvert.SerializeObject(m));
                        writer.Flush();
                    }
                }
                catch (IOException ex)
                {

                }
            }
            else
            {
                Console.WriteLine("Error en el parametro");
            }
            
        }
      

        public List<Medicion> ObtenerLecturasTrafico()
        {
            throw new NotImplementedException();
        }

        public List<Medicion> ObtenerLecturasConsumo()
        {
            throw new NotImplementedException();
        }
    }
}
