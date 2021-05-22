using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstacionesModel.DAL
{
    public class MedidoresDALFactory
    {
        public static IMedidoresDAL CreateDAL()
        {
            return MedidoresDAL.GetInstance();
        }
    }
}
