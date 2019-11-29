using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VisioneAPI.Models
{
    public class Indicador
    {
        public int Id { get; set; }
        public int IdEstabelecimento { get; set; }
        public int IdProcesso { get; set; }
        public int Tipo { get; set; }
        public string Nome { get; set; }
        public int? IdAmbiente { get; set; }
        public string UnidadeMedida { get; set; }
        public int FrequenciaMedicao { get; set; }
        public int ReferenciaLeitura { get; set; }
        public int? Benchmark { get; set; }
        public string Descricao { get; set; }
        public string Formula { get; set; }
        public string ReferencialComparativo { get; set; }
        public int MetodoPreenchimento { get; set; }
        public int EscalaMin { get; set; }
        public int EscalaMax { get; set; } 
        public double? Meta { get; set; }
        public double? ValorMinimo { get; set; }
        public double? ValorMaximo { get; set; }

    }
}
