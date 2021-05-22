using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstacionesModel.DTO
{
    public class EstacionDeCarga
    {
        private int id;
        private string direccion;
        private int capacidadMaximaCargas;
        private Region region;
        private DateTime horarioAtencion;

        public int Id
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
            }
        }

        public string Direccion
        {
            get
            {
                return direccion;
            }

            set
            {
                direccion = value;
            }
        }

        public int CapacidadMaximaCargas
        {
            get
            {
                return capacidadMaximaCargas;
            }

            set
            {
                capacidadMaximaCargas = value;
            }
        }

        internal Region Region
        {
            get
            {
                return region;
            }

            set
            {
                region = value;
            }
        }

        public DateTime HorarioAtencion
        {
            get
            {
                return horarioAtencion;
            }

            set
            {
                horarioAtencion = value;
            }
        }
    }
}
