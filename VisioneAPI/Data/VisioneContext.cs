using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VisioneAPI.Models;

namespace VisioneAPI.Data
{
    public class VisioneContext : DbContext
    {
        public VisioneContext(DbContextOptions<VisioneContext> options)
            : base(options)
        {
        }
        public DbSet<VisioneAPI.Models.UGB> UGB { get; set; }
        public DbSet<VisioneAPI.Models.Indicador> Indicador { get; set; }
        public DbSet<VisioneAPI.Models.UGBIndicadoresView> UGBIndicadoresView { get; set; }
        public DbSet<VisioneAPI.Models.UGB_Indicadores> UGB_Indicadores { get; set; }
        public DbSet<VisioneAPI.Models.CheckList> CheckList { get; set; }
        public DbSet<VisioneAPI.Models.CheckList_Item> CheckList_Item { get; set; }
        public DbSet<VisioneAPI.Models.Indicador_CheckList> Indicador_CheckList { get; set; }
        public DbSet<VisioneAPI.Models.IndicadorCheckListViewModel> IndicadorCheckListViewModel { get; set; }
        public DbSet<VisioneAPI.Models.Indicador_Dados> Indicador_Dados { get; set; }

    }
}
