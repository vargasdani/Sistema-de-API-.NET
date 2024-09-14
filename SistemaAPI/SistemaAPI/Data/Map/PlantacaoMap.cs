using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaAPI.Models;

namespace SistemaAPI.Data.Map
{
    public class PlantacaoMap : IEntityTypeConfiguration<PlantacaoModel>
    {
        public void Configure(EntityTypeBuilder<PlantacaoModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Nome).IsRequired().HasMaxLength(255);
            builder.Property(x => x.Descricao).HasMaxLength(1000);
            builder.Property(x => x.Status).IsRequired();
            builder.Property(x => x.ClimaId);

            builder.HasOne(x => x.Clima);
        }
    }
}
