using HeroesFluent.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HeroesFluent.Data.Configurations;

public class MisionConfiguration : IEntityTypeConfiguration<Mision>
{
    public void Configure(EntityTypeBuilder<Mision> builder)
    {
        // 1. Tabla
        builder.ToTable("Misiones");

        // 2. Clave primaria
        builder.HasKey(m => m.Id);

        // 3. Propiedades
        builder.Property(m => m.Titulo)
            .IsRequired()
            .HasMaxLength(150);

        builder.Property(m => m.Descripcion)
            .HasMaxLength(500);

        builder.Property(m => m.Dificultad)
            .HasConversion<string>()
            .HasMaxLength(20);

        builder.Property(m => m.FechaLimite)
            .HasColumnType("date");

        builder.Property(m => m.NivelPeligro)
            .HasDefaultValue(1);

        // 4. Índices: ninguno

        // 5. Relaciones: se configuran en HeroeMisionConfiguration

        // 6. Datos iniciales
        builder.HasData(
            new Mision
            {
                Id = 1,
                Titulo = "Rescate en la ciudad",
                Descripcion = "Rescatar civiles atrapados.",
                Dificultad = Dificultad.Alta,
                FechaLimite = new DateTime(2026, 12, 31),
                NivelPeligro = 1
            },
            new Mision
            {
                Id = 2,
                Titulo = "Investigación de amenazas",
                Descripcion = "Investigar actividad sospechosa.",
                Dificultad = Dificultad.Media,
                FechaLimite = new DateTime(2026, 11, 30),
                NivelPeligro = 1
            },
            new Mision
            {
                Id = 3,
                Titulo = "Protección de la ciudad",
                Descripcion = "Vigilar y proteger la ciudad.",
                Dificultad = Dificultad.Baja,
                FechaLimite = new DateTime(2026, 10, 15),
                NivelPeligro = 1
            });
    }
}