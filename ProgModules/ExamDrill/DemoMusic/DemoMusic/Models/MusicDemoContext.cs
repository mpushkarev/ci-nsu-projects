using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DemoMusic.Models;

public partial class MusicDemoContext : DbContext
{
    public MusicDemoContext()
    {
    }

    public MusicDemoContext(DbContextOptions<MusicDemoContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Equipment> Equipments { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<Point> Points { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=Tesseract;Database=MusicDemo; Trusted_Connection=True; TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Equipment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__equipmen__3214EC07FC427EDD");

            entity.Property(e => e.Art).HasMaxLength(255);
            entity.Property(e => e.Manuf).HasMaxLength(255);
            entity.Property(e => e.Name).HasMaxLength(255);
            entity.Property(e => e.Pic).HasMaxLength(255);
            entity.Property(e => e.Supp).HasMaxLength(255);
            entity.Property(e => e.Type).HasMaxLength(255);
            entity.Property(e => e.Unit).HasMaxLength(255);
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__orders$__3214EC077B65FF77");

            entity.Property(e => e.ClientId).HasColumnName("ClientID");
            entity.Property(e => e.EquipmentId).HasColumnName("EquipmentID");
            entity.Property(e => e.PointId).HasColumnName("PointID");
            entity.Property(e => e.StartDay).HasColumnType("datetime");
            entity.Property(e => e.Status).HasMaxLength(255);

            entity.HasOne(d => d.Client).WithMany(p => p.Orders)
                .HasForeignKey(d => d.ClientId)
                .HasConstraintName("FK__Orders__ClientID__787EE5A0");

            entity.HasOne(d => d.Equipment).WithMany(p => p.Orders)
                .HasForeignKey(d => d.EquipmentId)
                .HasConstraintName("FK__Orders__Equipmen__75A278F5");

            entity.HasOne(d => d.Point).WithMany(p => p.Orders)
                .HasForeignKey(d => d.PointId)
                .HasConstraintName("FK__Orders__PointID__76969D2E");
        });

        modelBuilder.Entity<Point>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__points$__3214EC07DA2AD57B");

            entity.Property(e => e.Address).HasMaxLength(255);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__users$__3214EC07A82AB054");

            entity.Property(e => e.Fio).HasMaxLength(255);
            entity.Property(e => e.Login).HasMaxLength(255);
            entity.Property(e => e.Password).HasMaxLength(255);
            entity.Property(e => e.Role).HasMaxLength(255);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
