using Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.EntitiesConfiguration
{
    public class MercadoriaConfiguration : IEntityTypeConfiguration<Mercadoria>
    {
        public void Configure(EntityTypeBuilder<Mercadoria> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Nome).HasMaxLength(100).IsRequired();
            builder.Property(e => e.Fabricante).HasMaxLength(100).IsRequired();
            builder.Property(e => e.Tipo).HasMaxLength(30).IsRequired();
            builder.Property(e => e.Descricao).IsRequired();
        }
    }
}
