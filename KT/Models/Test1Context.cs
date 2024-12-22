using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace KT.Models;

//public partial class Test1Context : IdentityDbContext<IdentityUser>
//{
//    public Test1Context()
//    {
//    }

//    public Test1Context(DbContextOptions<Test1Context> options)
//        : base(options)
//    {
//    }

//    public virtual DbSet<DangKy> DangKies { get; set; }

//    public virtual DbSet<HocPhan> HocPhans { get; set; }

//    public virtual DbSet<NganhHoc> NganhHocs { get; set; }

//    public virtual DbSet<SinhVien> SinhViens { get; set; }
//    public virtual DbSet<ChiTietDangKy> ChiTietDangKies { get; set; }
//    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
//        => optionsBuilder.UseSqlServer("Server=DESKTOP-M0KCUVC\\MSSQLSERVER01;Database=Test1;Trusted_Connection=True;TrustServerCertificate=True;");

//    protected override void OnModelCreating(ModelBuilder modelBuilder)
//    {
//        base.OnModelCreating(modelBuilder);

//        modelBuilder.Entity<DangKy>(entity =>
//        {
//            entity.HasKey(e => e.MaDk).HasName("PK__DangKy__2725866C5E56A861");

//            entity.ToTable("DangKy");

//            entity.Property(e => e.MaDk).HasColumnName("MaDK");
//            entity.Property(e => e.MaSv)
//                .HasMaxLength(10)
//                .IsUnicode(false)
//                .IsFixedLength()
//                .HasColumnName("MaSV");
//            entity.Property(e => e.NgayDk).HasColumnName("NgayDK");

//            entity.HasOne(d => d.MaSvNavigation).WithMany(p => p.DangKies)
//                .HasForeignKey(d => d.MaSv)
//                .HasConstraintName("FK__DangKy__MaSV__3E52440B");

//            entity.HasMany(d => d.MaHps).WithMany(p => p.MaDks)
//                .UsingEntity<Dictionary<string, object>>(
//                    "ChiTietDangKy",
//                    r => r.HasOne<HocPhan>().WithMany()
//                        .HasForeignKey("MaHp")
//                        .OnDelete(DeleteBehavior.ClientSetNull)
//                        .HasConstraintName("FK__ChiTietDan__MaHP__4222D4EF"),
//                    l => l.HasOne<DangKy>().WithMany()
//                        .HasForeignKey("MaDk")
//                        .OnDelete(DeleteBehavior.ClientSetNull)
//                        .HasConstraintName("FK__ChiTietDan__MaDK__412EB0B6"),
//                    j =>
//                    {
//                        j.HasKey("MaDk", "MaHp").HasName("PK__ChiTietD__F557DC0284907DC5");
//                        j.ToTable("ChiTietDangKy");
//                        j.IndexerProperty<int>("MaDk").HasColumnName("MaDK");
//                        j.IndexerProperty<string>("MaHp")
//                            .HasMaxLength(6)
//                            .IsUnicode(false)
//                            .IsFixedLength()
//                            .HasColumnName("MaHP");
//                    });
//        });

//        modelBuilder.Entity<HocPhan>(entity =>
//        {
//            entity.HasKey(e => e.MaHp).HasName("PK__HocPhan__2725A6EC674C9B0B");

//            entity.ToTable("HocPhan");

//            entity.Property(e => e.MaHp)
//                .HasMaxLength(6)
//                .IsUnicode(false)
//                .IsFixedLength()
//                .HasColumnName("MaHP");
//            entity.Property(e => e.TenHp)
//                .HasMaxLength(30)
//                .HasColumnName("TenHP");
//        });

//        modelBuilder.Entity<NganhHoc>(entity =>
//        {
//            entity.HasKey(e => e.MaNganh).HasName("PK__NganhHoc__A2CEF50DEA666229");

//            entity.ToTable("NganhHoc");

//            entity.Property(e => e.MaNganh)
//                .HasMaxLength(4)
//                .IsUnicode(false)
//                .IsFixedLength();
//            entity.Property(e => e.TenNganh).HasMaxLength(30);
//        });

//        modelBuilder.Entity<SinhVien>(entity =>
//        {
//            entity.HasKey(e => e.MaSv).HasName("PK__SinhVien__2725081ACCA00EBA");

//            entity.ToTable("SinhVien");

//            entity.Property(e => e.MaSv)
//                .HasMaxLength(10)
//                .IsUnicode(false)
//                .IsFixedLength()
//                .HasColumnName("MaSV");
//            entity.Property(e => e.GioiTinh).HasMaxLength(5);
//            entity.Property(e => e.Hinh)
//                .HasMaxLength(50)
//                .IsUnicode(false);
//            entity.Property(e => e.HoTen).HasMaxLength(50);
//            entity.Property(e => e.MaNganh)
//                .HasMaxLength(4)
//                .IsUnicode(false)
//                .IsFixedLength();

//            entity.HasOne(d => d.MaNganhNavigation).WithMany(p => p.SinhViens)
//                .HasForeignKey(d => d.MaNganh)
//                .HasConstraintName("FK__SinhVien__MaNgan__398D8EEE");
//        });

//        OnModelCreatingPartial(modelBuilder);
//    }

//    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
//}

public partial class Test1Context : IdentityDbContext<IdentityUser>
{
    public Test1Context()
    {
    }

    public Test1Context(DbContextOptions<Test1Context> options)
        : base(options)
    {
    }

    public virtual DbSet<DangKy> DangKies { get; set; }
    public virtual DbSet<HocPhan> HocPhans { get; set; }
    public virtual DbSet<NganhHoc> NganhHocs { get; set; }
    public virtual DbSet<SinhVien> SinhViens { get; set; }
    public virtual DbSet<ChiTietDangKy> ChiTietDangKies { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-M0KCUVC\\MSSQLSERVER01;Database=Test1;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder); // Ensure that IdentityDbContext configuration is included

        modelBuilder.Entity<DangKy>(entity =>
        {
            entity.HasKey(e => e.MaDk).HasName("PK__DangKy__2725866C5E56A861");

            entity.ToTable("DangKy");

            entity.Property(e => e.MaDk).HasColumnName("MaDK");
            entity.Property(e => e.MaSv)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("MaSV");
            entity.Property(e => e.NgayDk).HasColumnName("NgayDK");

            entity.HasOne(d => d.MaSvNavigation).WithMany(p => p.DangKies)
                .HasForeignKey(d => d.MaSv)
                .HasConstraintName("FK__DangKy__MaSV__3E52440B");

            entity.HasMany(d => d.ChiTietDangKies).WithOne(p => p.DangKy)
                .HasForeignKey(d => d.MaDk)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ChiTietDan__MaDK__412EB0B6");
        });

        modelBuilder.Entity<ChiTietDangKy>(entity =>
        {
            entity.HasKey(e => new { e.MaDk, e.MaHp }).HasName("PK__ChiTietD__F557DC0284907DC5");
            entity.ToTable("ChiTietDangKy");

            entity.HasOne(e => e.DangKy)
                .WithMany(d => d.ChiTietDangKies)
                .HasForeignKey(e => e.MaDk)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ChiTietDan__MaDK__412EB0B6");

            entity.HasOne(e => e.HocPhan)
                .WithMany(p => p.ChiTietDangKies)
                .HasForeignKey(e => e.MaHp)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ChiTietDan__MaHP__4222D4EF");
        });

        modelBuilder.Entity<HocPhan>(entity =>
        {
            entity.HasKey(e => e.MaHp).HasName("PK__HocPhan__2725A6EC674C9B0B");

            entity.ToTable("HocPhan");

            entity.Property(e => e.MaHp)
                .HasMaxLength(6)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("MaHP");
            entity.Property(e => e.TenHp)
                .HasMaxLength(30)
                .HasColumnName("TenHP");

            entity.HasMany(e => e.ChiTietDangKies).WithOne(p => p.HocPhan)
                .HasForeignKey(e => e.MaHp)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ChiTietDan__MaHP__4222D4EF");
        });

        modelBuilder.Entity<NganhHoc>(entity =>
        {
            entity.HasKey(e => e.MaNganh).HasName("PK__NganhHoc__A2CEF50DEA666229");

            entity.ToTable("NganhHoc");

            entity.Property(e => e.MaNganh)
                .HasMaxLength(4)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.TenNganh).HasMaxLength(30);
        });

        modelBuilder.Entity<SinhVien>(entity =>
        {
            entity.HasKey(e => e.MaSv).HasName("PK__SinhVien__2725081ACCA00EBA");

            entity.ToTable("SinhVien");

            entity.Property(e => e.MaSv)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("MaSV");
            entity.Property(e => e.GioiTinh).HasMaxLength(5);
            entity.Property(e => e.Hinh)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.HoTen).HasMaxLength(50);
            entity.Property(e => e.MaNganh)
                .HasMaxLength(4)
                .IsUnicode(false)
                .IsFixedLength();

            entity.HasOne(d => d.MaNganhNavigation).WithMany(p => p.SinhViens)
                .HasForeignKey(d => d.MaNganh)
                .HasConstraintName("FK__SinhVien__MaNgan__398D8EEE");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
