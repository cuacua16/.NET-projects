using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace SaxosAsp.Models;

public partial class AsphdContext : DbContext
{
    public AsphdContext()
    {
    }

    public AsphdContext(DbContextOptions<AsphdContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Marca> Marcas { get; set; }

    public virtual DbSet<Saxo> Saxos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-49KHM13\\SQLEXPRESS;Database=ASPHD; Trusted_Connection=True; Encrypt=False;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Marca>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Marcas__3214EC0702080B1B");

            entity.Property(e => e.Nombre)
                .HasMaxLength(40)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Saxo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Saxos__3214EC0785CFB20D");

            entity.Property(e => e.Tipo)
                .HasMaxLength(40)
                .IsUnicode(false);

            entity.HasOne(d => d.Marca).WithMany(p => p.Saxos)
                .HasForeignKey(d => d.MarcaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Marca");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
