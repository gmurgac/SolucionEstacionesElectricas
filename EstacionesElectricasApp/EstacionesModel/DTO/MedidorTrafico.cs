using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstacionesModel.DTO
{
    public class MedidorTrafico : Medidor
    {
        public MedidorTrafico(int id, DateTime fechaInstalacion, string tipo) : base(id, fechaInstalacion, tipo)
        {
        }
    }
}
