using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VisioneAPI.Models
{
    public class UGB
    {
        public int Id { get; set; }
        public int IdEstabelecimento { get; set; }
        public string Nome { get; set; }
        public int IdDepartamento { get; set; }
        public int IdGestor { get; set; }
        public int Status { get; set; }
        public int ? IdRepresentante { get; set; }
    }
}
