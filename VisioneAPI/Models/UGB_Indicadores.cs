using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VisioneAPI.Models
{
    public class UGB_Indicadores
    {
        public int Id { get; set; }
        /* Este atributo não é necessario*/
        public int IdEstabelecimento { get; set; }
        public int IdUGB { get; set; }
        public int IdIndicador { get; set; }
        /* Este atributo de facto não pertence a essa class
         * Foi adicionado porque a estrutuda de dados 
         * continha esse dado, que por sinal, 
         * foi inserido valores neles */
        public double? Meta { get; set; }
        public double? ValorMinimo { get; set; }
        public double? ValorMaximo { get; set; }
      
    }
}
