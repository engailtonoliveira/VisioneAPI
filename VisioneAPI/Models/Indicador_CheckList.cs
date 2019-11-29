using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VisioneAPI.Models
{
    public class Indicador_CheckList
    {
        public int Id { get; set; }
        public int IdEstabelecimento { get; set; }
        public int IdIndicador { get; set; }
        public string ItensChecar { get; set; }
        public string Especificacoes { get; set; }
        public double? PontosPossiveis { get; set; }
    }
}
