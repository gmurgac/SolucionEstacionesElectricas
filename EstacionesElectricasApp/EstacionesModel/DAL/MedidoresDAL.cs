using EstacionesModel.DTO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstacionesModel.DAL
{
    public class MedidoresDAL : IMedidoresDAL
    {

        //crear atributo archivo
        private static List<Medidor> listadoMedidores = new List<Medidor>() {
            new MedidorTrafico(123, new DateTime(2020,5,23,1,50,23),"trafico") { },
            new MedidorConsumo(124, new DateTime(2020,5,23,1,55,23),"consumo") { }
        }; 


        //Patron Singleton
        //1. Constructor privado
        private MedidoresDAL()
        {

        }
        //2. Un atributo de tipo estatico privado de la misma instancia
        private static IMedidoresDAL instancia;
        //3. Un metodo estatico que permita obtener la unica instancia
        public static IMedidoresDAL GetInstance()
        {
            if (instancia == null)
                instancia = new MedidoresDAL();
            return instancia;
        }

        public List<Medidor> ObtenerMedidores()
        {
            return listadoMedidores;
        }

        public Boolean EncontrarMedidor(int numeroMedidor, string tipo)
        {

            if(listadoMedidores.Exists(m => m.Id == numeroMedidor))
            {
                if(listadoMedidores.Find(m => m.Id == numeroMedidor).Tipo == tipo)
                {
                    return true;
                }else
                {
                    return false;
                }
            }else
            {
                return false;
            }
        }
    }
}
