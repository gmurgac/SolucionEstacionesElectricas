using EstacionesModel.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstacionesModel.DAL
{
    public interface IMedidoresDAL
    {
        List<Medidor> ObtenerMedidores();
        Boolean EncontrarMedidor(int id, string tipos);
    }
}
