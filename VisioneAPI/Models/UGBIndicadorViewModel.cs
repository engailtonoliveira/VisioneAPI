using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VisioneAPI.Models
{
    public class UGBIndicadorViewModel
    {
        public int Id { get; set; }
        public int IdUGB { get; set; }
        public string Nome { get; set; }
        public string NomeUgb { get; set; }
        public double? Meta { get; set; }
        public double? ValorMaximo { get; set; }
        public double? ValorMinimo { get; set; }
        public int MetodoPreenchimento { get; set; }

    }
}
