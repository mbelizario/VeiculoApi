using Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Net.NetworkInformation;

namespace Repository.Configuration
{
    public class ModeloConfiguration : IEntityTypeConfiguration<Modelo>
    {
        public void Configure(EntityTypeBuilder<Modelo> builder)
        {

            builder.HasKey(x => x.Id);


            builder.Property(x => x.Nome)
                .IsRequired()
                .HasColumnType("varchar(160)");

            builder.HasOne(e => e.Marca)
                .WithMany(e => e.Modelos)
                .HasForeignKey(e => e.MarcaId);
        }
    }
}
