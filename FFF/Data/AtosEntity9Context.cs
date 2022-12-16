using System;
using System.Collections.Generic;
using FFF.Models;
using Microsoft.EntityFrameworkCore;

namespace FFF.Data;

public partial class AtosEntity9Context : DbContext
{
    public AtosEntity9Context()
    {
    }

    public AtosEntity9Context(DbContextOptions<AtosEntity9Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Horario> Horarios { get; set; }

    public virtual DbSet<Paciente> Pacientes { get; set; }

    public virtual DbSet<Remedio> Remedios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=localhost;initial Catalog=AtosEntity9;User ID=AtosEntity9;password=Atos_Entity_9;language=Portuguese;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Horario>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Horarios__3213E83F1E7DE419");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Horario1).HasColumnName("horario");
            entity.Property(e => e.IdPaciente).HasColumnName("idPaciente");
            entity.Property(e => e.IdRemedio).HasColumnName("idRemedio");
            entity.Property(e => e.Tempo).HasColumnName("tempo");

            entity.HasOne(d => d.IdPacienteNavigation).WithMany(p => p.Horarios)
                .HasForeignKey(d => d.IdPaciente)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Horarios__idPaci__29572725");

            entity.HasOne(d => d.IdRemedioNavigation).WithMany(p => p.Horarios)
                .HasForeignKey(d => d.IdRemedio)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Horarios__idReme__286302EC");
        });

        modelBuilder.Entity<Paciente>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Paciente__3213E83FD979A351");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Nome)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("nome");
        });

        modelBuilder.Entity<Remedio>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Remedios__3213E83FEE3C48D5");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Nome)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("nome");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
