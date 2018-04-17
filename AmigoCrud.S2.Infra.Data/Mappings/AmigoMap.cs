using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using AmigoCrud.S2.Domain.Models;

namespace AmigoCrud.S2.Infra.Data.Mappings
{    
    public class AmigoMap : IEntityTypeConfiguration<Amigo>
    {
        public void Configure(EntityTypeBuilder<Amigo> builder)
        {
            builder.Property(c => c.Id)
                .HasColumnName("Id");

            builder.Property(c => c.Nome)
                .HasColumnType("varchar(100)")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(c => c.Endereco)
                .HasColumnType("varchar(100)")
                .HasMaxLength(150)
                .IsRequired();   
        }
    }
}