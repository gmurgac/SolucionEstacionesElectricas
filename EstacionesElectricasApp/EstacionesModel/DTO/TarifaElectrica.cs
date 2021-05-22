using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstacionesModel.DTO
{
    public class TarifaElectrica
    {
        private int codigo;
        private decimal factor;

        public int Codigo
        {
            get
            {
                return codigo;
            }

            set
            {
                codigo = value;
            }
        }

        public decimal Factor
        {
            get
            {
                return factor;
            }

            set
            {
                factor = value;
            }
        }
    }
}
