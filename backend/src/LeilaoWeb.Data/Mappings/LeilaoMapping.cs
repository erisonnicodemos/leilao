using LeilaoWeb.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LeilaoWeb.Data.Mappings
{
    public class LeilaoMapping : IEntityTypeConfiguration<Leilao>
    {
        public void Configure(EntityTypeBuilder<Leilao > builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Nome)
                .IsRequired()
                .HasColumnType("varchar(200)");           

            builder.Property(p => p.Condicao)
                .IsRequired()
                .HasColumnType("int");

            builder.Property(p => p.NomeResponsavel)
              .IsRequired()
              .HasColumnType("varchar(100)");

            builder.Property(p => p.DataAbetura)
                .IsRequired()
            .HasColumnType("date");

            builder.Property(p => p.DataFinalizacao)
                .IsRequired()
            .HasColumnType("date");


            builder.ToTable("Leiloes");
        }
    }
}