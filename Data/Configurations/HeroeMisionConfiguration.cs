using HeroesFluent.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HeroesFluent.Data.Configurations;

public class HeroeMisionConfiguration : IEntityTypeConfiguration<HeroeMision>
{
    public void Configure(EntityTypeBuilder<HeroeMision> builder)
    {
        // 1. Tabla
        builder.ToTable("HeroeMisiones");

        // 2. Clave primaria compuesta
        builder.HasKey(hm => new { hm.HeroeId, hm.MisionId });

        // 3. Propiedades
        builder.Property(hm => hm.Rol)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(hm => hm.FechaAsignacion)
            .HasDefaultValueSql("GETDATE()");

        // 4. Índices: ninguno (la PK ya impide repetir la pareja)

        // 5. Relaciones
        builder.HasOne(hm => hm.Heroe)
            .WithMany(h => h.HeroeMisiones)
            .HasForeignKey(hm => hm.HeroeId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(hm => hm.Mision)
            .WithMany(m => m.HeroeMisiones)
            .HasForeignKey(hm => hm.MisionId)
            .OnDelete(DeleteBehavior.Cascade);

        // 6. Datos iniciales
        builder.HasData(
            new HeroeMision
            {
                HeroeId = 1,
                MisionId = 1,
                Rol = "Líder",
                FechaAsignacion = new DateTime(2024, 2, 1)
            },
            new HeroeMision
            {
                HeroeId = 2,
                MisionId = 2,
                Rol = "Investigador",
                FechaAsignacion = new DateTime(2024, 2, 2)
            });
    }
}