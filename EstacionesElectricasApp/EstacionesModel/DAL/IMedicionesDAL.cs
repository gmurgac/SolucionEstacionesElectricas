using EstacionesModel.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstacionesModel.DAL
{
    public interface IMedicionesDAL
    {
        void RegistrarLectura(Medicion m);
        List<Medicion> ObtenerLecturasTrafico();
        List<Medicion> ObtenerLecturasConsumo();
    }
}
