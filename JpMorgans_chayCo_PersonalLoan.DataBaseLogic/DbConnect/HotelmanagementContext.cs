using System;
using System.Collections.Generic;
using JpMorgans_chayCo_PersonalLoan.DataBaseLogic;
using Microsoft.EntityFrameworkCore;

namespace JpMorgans_chayCo_PersonalLoan.DataBaseLogic;

public partial class HotelmanagementContext : DbContext
{
    public HotelmanagementContext()
    {
    }

    public HotelmanagementContext(DbContextOptions<HotelmanagementContext> options)
        : base(options)
    {
    }

    public virtual DbSet<CustomerRegidtation> CustomerRegidtations { get; set; }

    public virtual DbSet<Dept> Depts { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-5FALPST\\SQLEXPRESS;Database=hotelmanagement;Trusted_Connection=True;Encrypt=true;\nTrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CustomerRegidtation>(entity =>
        {
            entity.HasKey(e => e.Cid).HasName("PK__customer__D837D05FA4E90375");

            entity.ToTable("customerRegidtation");

            entity.Property(e => e.Cid).HasColumnName("cid");
            entity.Property(e => e.CustomerName)
                .IsUnicode(false)
                .HasColumnName("customerName");
            entity.Property(e => e.Email)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.FullName)
                .IsUnicode(false)
                .HasColumnName("fullName");
            entity.Property(e => e.Password)
                .IsUnicode(false)
                .HasColumnName("password");
        });

        modelBuilder.Entity<Dept>(entity =>
        {
            entity.HasKey(e => e.Deptid).HasName("PK__dept__BE2C1AEE085313A8");

            entity.ToTable("dept");

            entity.Property(e => e.Deptid).HasColumnName("deptid");
            entity.Property(e => e.DeptName)
                .IsUnicode(false)
                .HasColumnName("deptName");
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.Sid).HasName("PK__student__DDDFDD36A09F7E9A");

            entity.ToTable("student");

            entity.Property(e => e.Sid).HasColumnName("sid");
            entity.Property(e => e.Deptid).HasColumnName("deptid");
            entity.Property(e => e.Joindate)
                .HasColumnType("datetime")
                .HasColumnName("joindate");
            entity.Property(e => e.StudentAge)
                .IsUnicode(false)
                .HasColumnName("studentAge");
            entity.Property(e => e.Studentname)
                .IsUnicode(false)
                .HasColumnName("studentname");

            entity.HasOne(d => d.Dept).WithMany(p => p.Students)
                .HasForeignKey(d => d.Deptid)
                .HasConstraintName("FK__student__deptid__5EBF139D");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
