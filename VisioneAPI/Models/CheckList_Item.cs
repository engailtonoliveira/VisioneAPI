using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VisioneAPI.Models
{
    public class CheckList_Item
    {
        public int Id { get; set; }
        public int IdEstabelecimento { get; set; }
        public int IdChecklist { get; set; }
        public int IdIndicador_Checklist { get; set; }
        public int SituacaoVerificada { get; set; }
    }
}
