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

    public virtual DbSet<Account> Accounts { get; set; }

    public virtual DbSet<Commission> Commissions { get; set; }

    public virtual DbSet<TasasP> TasasPs { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Account>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Account__3213E83FE5F9FB88");

            entity.ToTable("Account");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Accountnumber)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("accountnumber");
            entity.Property(e => e.Bank)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("bank");
            entity.Property(e => e.Country)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("country");
            entity.Property(e => e.IdOwner)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("idOwner");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.Observation)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("observation");
        });

        modelBuilder.Entity<Commission>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Commissi__3214EC077BE74F89");

            entity.ToTable("Commission");

            entity.Property(e => e.Op)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.Pais)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.PaisR)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

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

            entity.HasOne(d => d.PaisRNavigation).WithMany(p => p.TasasPs)
                .HasForeignKey(d => d.PaisR)
                .HasConstraintName("fk_commission");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
