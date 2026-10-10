using HeroesFluent.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HeroesFluent.Data.Configurations;

public class HeroeConfiguration : IEntityTypeConfiguration<Heroe>
{
    public void Configure(EntityTypeBuilder<Heroe> builder)
    {
        // 1. Tabla + CHECK de NivelPoder (1 a 100)
        builder.ToTable("Heroes", t =>
            t.HasCheckConstraint("CK_Heroes_NivelPoder",
                "[NivelPoder] BETWEEN 1 AND 100"));

        // 2. Clave primaria
        builder.HasKey(h => h.Id);

        // 3. Propiedades
        builder.Property(h => h.Nombre)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(h => h.Alias)
            .IsRequired()
            .HasMaxLength(60);

        builder.Property(h => h.FechaRegistro)
            .HasDefaultValueSql("GETDATE()");

        // 4. Índices
        builder.HasIndex(h => h.Alias)
            .IsUnique();

        // 5. Relaciones: Heroe -> Equipo (opcional, SetNull al borrar)
        builder.HasOne(h => h.Equipo)
            .WithMany(e => e.Heroes)
            .HasForeignKey(h => h.EquipoId)
            .IsRequired(false)
            .OnDelete(DeleteBehavior.SetNull);

        // 6. Datos iniciales
        builder.HasData(
            new Heroe
            {
                Id = 1,
                Nombre = "Clark Kent",
                Alias = "Superman",
                NivelPoder = 95,
                FechaRegistro = new DateTime(2024, 1, 1),
                EquipoId = 1
            },
            new Heroe
            {
                Id = 2,
                Nombre = "Bruce Wayne",
                Alias = "Batman",
                NivelPoder = 80,
                FechaRegistro = new DateTime(2024, 1, 2),
                EquipoId = 1
            });
    }
}