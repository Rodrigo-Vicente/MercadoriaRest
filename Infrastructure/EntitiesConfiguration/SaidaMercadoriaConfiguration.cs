using Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.EntitiesConfiguration
{
    public class SaidaMercadoriaConfiguration : IEntityTypeConfiguration<SaidaMercadoria>
    {
        public void Configure(EntityTypeBuilder<SaidaMercadoria> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.QuantidadeRetirada).IsRequired();
            builder.Property(e => e.DataHora).IsRequired();
            builder.Property(e => e.Local).HasMaxLength(255).IsRequired();

            builder.HasOne(e => e.Mercadoria).WithMany(e => e.Saidas)
               .HasForeignKey(e => e.MercadoriaId);
        }
    }
}
