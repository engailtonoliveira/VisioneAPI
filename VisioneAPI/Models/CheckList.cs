using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VisioneAPI.Models
{
    public class CheckList
    {

        public int Id { get; set; }
        public int IdEstabelecimento { get; set; }
        public int IdIndicador { get; set; }
        public int? IdGestor { get; set; }
        public int? IdUGB { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime Data { get; set; }
    }
}
