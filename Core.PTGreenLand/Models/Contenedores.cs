using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.PTGreenLand.Models
{
    public class Contenedores
    {
        //public int idContenedor { get; set; }
        public string Prefijo { get; set; }
        public string Numero { get; set; }
        public string DigitoControl { get; set; }
        public int CodigoNaviera { get; set; }
        public String NombreNaviera { get; set; }
        public DateTime FechaFabricacion { get; set; }
        public decimal Tara { get; set; }
    }
}
