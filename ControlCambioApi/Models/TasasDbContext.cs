using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ControlCambioApi.Models;

public partial class TasasDbContext : DbContext
{
    public TasasDbContext()
    {
    }

    public TasasDbContext(DbContextOptions<TasasDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TasasP> TasasPs { get; set; }

   
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TasasP>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__TasasP__3214EC07C46A6457");

            entity.ToTable("TasasP");

            entity.Property(e => e.Pais)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.TipoMoneda)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.ValorMoneda).HasColumnType("decimal(10, 2)");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
