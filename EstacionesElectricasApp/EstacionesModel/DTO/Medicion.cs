using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstacionesModel.DTO
{
    public enum TipoMedicion
    {
        Carga, Trafico, Mantencion
    }
    public class Medicion
    {
        private int id;
        private DateTime fecha;
        private string tipo;
        private int valor;  //Agrega
        
        private int estado;

        public override string ToString()
        {
            return "" + this.id + "|" + this.fecha + "|" + this.tipo + "|" + this.valor + "|" + this.estado;
        }

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

        public DateTime Fecha
        {
            get
            {
                return fecha;
            }

            set
            {
                fecha = value;
            }
        }

        public string Tipo
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

        public int Valor
        {
            get
            {
                return valor;
            }

            set
            {
                valor = value;
            }
        }

      

        public int Estado
        {
            get
            {
                return estado;
            }

            set
            {
                estado = value;
            }
        }
    }
}
