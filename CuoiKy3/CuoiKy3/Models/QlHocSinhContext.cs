using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace CuoiKy3.Models;

public partial class QlHocSinhContext : DbContext
{
    public QlHocSinhContext()
    {
    }

    public QlHocSinhContext(DbContextOptions<QlHocSinhContext> options)
        : base(options)
    {
    }

    public virtual DbSet<HocSinh> HocSinhs { get; set; }

    public virtual DbSet<Lop> Lops { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=vinhhaui2005\\SQLEXPRESS;Initial Catalog=QL_HocSinh;Integrated Security=True;Trust Server Certificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<HocSinh>(entity =>
        {
            entity.HasKey(e => e.MaHs).HasName("PK__HocSinh__2725A6EFDDBBAAEC");

            entity.ToTable("HocSinh");

            entity.Property(e => e.MaHs)
                .HasMaxLength(10)
                .HasColumnName("MaHS");
            entity.Property(e => e.ConTbls)
                .HasMaxLength(10)
                .HasColumnName("ConTBLS");
            entity.Property(e => e.GioiTinh).HasMaxLength(10);
            entity.Property(e => e.HoTen).HasMaxLength(100);
            entity.Property(e => e.MaLop).HasMaxLength(10);

            entity.HasOne(d => d.MaLopNavigation).WithMany(p => p.HocSinhs)
                .HasForeignKey(d => d.MaLop)
                .HasConstraintName("FK__HocSinh__MaLop__398D8EEE");
        });

        modelBuilder.Entity<Lop>(entity =>
        {
            entity.HasKey(e => e.MaLop).HasName("PK__Lop__3B98D2735C6119C8");

            entity.ToTable("Lop");

            entity.Property(e => e.MaLop).HasMaxLength(10);
            entity.Property(e => e.TenLop).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
