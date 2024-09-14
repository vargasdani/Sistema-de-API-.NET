using Microsoft.EntityFrameworkCore;
using SistemaAPI.Data.Map;
using SistemaAPI.Models;

namespace SistemaAPI.Data
{
    public class SistemaPlantacoesDBContext : DbContext
    {
        public SistemaPlantacoesDBContext(DbContextOptions<SistemaPlantacoesDBContext> options)
            :base(options)
        {        
        }

        public DbSet<ClimaModel> Climas { get; set; }
        public DbSet<PlantacaoModel> Plantacoes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ClimaMap());
            modelBuilder.ApplyConfiguration(new PlantacaoMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}
