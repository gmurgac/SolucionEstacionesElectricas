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
        private string unidadDeMedida;
        private int estado;

        public override string ToString()
        {
            //return ""+this.nombre+";"+this.detalle+";"+this.tipo;
            string JsonToString = "{\"Fecha\":\"" + this.fecha + "\",\"Tipo\":\"" + this.tipo + "\",\"Valor\":\"" + this.valor + "\"}";
            return JsonToString;
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

        public string UnidadDeMedida
        {
            get
            {
                return unidadDeMedida;
            }

            set
            {
                unidadDeMedida = value;
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
