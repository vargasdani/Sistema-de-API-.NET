using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaAPI.Models;

namespace SistemaAPI.Data.Map
{
    public class ClimaMap : IEntityTypeConfiguration<ClimaModel>
    {
        public void Configure(EntityTypeBuilder<ClimaModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Nome).IsRequired().HasMaxLength(255);
            builder.Property(x => x.Descricao).IsRequired().HasMaxLength(1000);
        }
    }
}
