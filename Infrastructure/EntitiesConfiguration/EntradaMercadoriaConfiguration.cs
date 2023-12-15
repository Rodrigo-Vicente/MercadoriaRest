using Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.EntitiesConfiguration
{
    public class EntradaMercadoriaConfiguration : IEntityTypeConfiguration<EntradaMercadoria>
    {
        public void Configure(EntityTypeBuilder<EntradaMercadoria> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.QuantidadeEntrada).IsRequired();
            builder.Property(e => e.DataHora).IsRequired();
            builder.Property(e => e.Local).HasMaxLength(255).IsRequired();

            builder.HasOne(e => e.Mercadoria).WithMany(e => e.Entradas)
               .HasForeignKey(e => e.MercadoriaId);
        }
    }
}
