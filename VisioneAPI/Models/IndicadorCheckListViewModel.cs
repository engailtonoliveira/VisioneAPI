using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VisioneAPI.Models
{
    public class IndicadorCheckListViewModel
    {
        public int Id { get; set; }
        public string ItensChecar { get; set; }
        public double? PontosPossiveis { get; set; }
        public int IdIndicador { get; set; }
        public string NomeIndicador { get; set; }
        public DateTime MaxDate { get; set; }
    }
}
