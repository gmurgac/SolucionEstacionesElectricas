using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstacionesModel.DAL
{
    public class MedicionesDALFactory
    {
        public static IMedicionesDAL CreateDAL()
        {
            return MedicionesDALArchivos.GetInstance();
        }
    }
}
