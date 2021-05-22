using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstacionesModel.DTO
{
    public enum TipoPuntoCarga
    {
        Dual,Electrico
    }
    public class PuntoDeCarga
    {
        private string id;
        private TipoPuntoCarga tipo;
        private int capacidadMaximaVehiculos;
        private DateTime vidaUtil;

        public string Id
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

        public TipoPuntoCarga Tipo
        {
            get
            {
                return tipo;
            }

            set
            {
                tipo = value;
            }
        }

        public int CapacidadMaximaVehiculos
        {
            get
            {
                return capacidadMaximaVehiculos;
            }

            set
            {
                capacidadMaximaVehiculos = value;
            }
        }

        public DateTime VidaUtil
        {
            get
            {
                return vidaUtil;
            }

            set
            {
                vidaUtil = value;
            }
        }

        public void EnviarMedicion()
        {

        }
    }
}
