using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EstacionesModel.DTO;

namespace EstacionesModel.DAL
{
    public class MedidoresConsumoDAL : IMedidoresDAL
    {
        //Patron singleton
        //COnstructor privado
        private MedidoresConsumoDAL()
        {

        }
        //Atributo tipo estatico privado de la misma instancia
        private static IMedidoresDAL instancia;
        //metodo estatico que permita obtener la unica instancia
        public static IMedidoresDAL GetInstance()
        {
            if (instancia == null)
                instancia = new MedidoresConsumoDAL();
            return instancia;
        }


        public List<Medidor> ObtenerMedidores()
        {
            throw new NotImplementedException();
        }
    }
}
