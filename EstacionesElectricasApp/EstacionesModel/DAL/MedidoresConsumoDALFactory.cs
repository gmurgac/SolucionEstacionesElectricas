using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstacionesModel.DAL
{
    public class MedidoresConsumoDALFactory
    {
        public static IMedidoresDAL CreateDAL()
        {
            return MedidoresConsumoDAL.GetInstance();
        }
    }
}
