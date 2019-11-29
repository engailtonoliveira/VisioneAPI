using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VisioneAPI.Models
{
    public class UGBIndicadoresView
    {
        public int Id { get; set; }
        public int UGBId { get; set; }
        public double? Meta { get; set; }
        public double? ValorMaximo { get; set; }
        public double? ValorMinimo { get; set; }
        public int IdIndicador { get; set; }
        public string Nome { get; set; }
        public int FrequenciaMedicao { get; set; }
        public int MetodoPreenchimento { get; set; }

    }
}
