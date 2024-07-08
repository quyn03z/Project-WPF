using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DataAccess.Models;

public partial class QuanLyBilliardsClubContext : DbContext
{
    public QuanLyBilliardsClubContext()
    {
    }

    public QuanLyBilliardsClubContext(DbContextOptions<QuanLyBilliardsClubContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Account> Accounts { get; set; }

    public virtual DbSet<Bill> Bills { get; set; }

    public virtual DbSet<BillInfo> BillInfos { get; set; }

    public virtual DbSet<TableBia> TableBia { get; set; }

    public virtual DbSet<TableCategory> TableCategories { get; set; }

    public virtual DbSet<Water> Water { get; set; }

    private string? GetConnectionString()
    {
        IConfiguration configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", true, true).Build();
        // sửa lại tag cho phù hợp
        return configuration["ConnectionStrings:DBDefault"];
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer(GetConnectionString());

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Account>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Account__3213E83F5513B9DB");

            entity.ToTable("Account");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
            entity.Property(e => e.Password)
                .HasMaxLength(100)
                .HasColumnName("password");
            entity.Property(e => e.Role).HasColumnName("role");
            entity.Property(e => e.Username)
                .HasMaxLength(100)
                .HasColumnName("username");
        });

        modelBuilder.Entity<Bill>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Bill__3213E83FD987061C");

            entity.ToTable("Bill");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.IdTableBia).HasColumnName("idTableBia");
            entity.Property(e => e.Status).HasColumnName("status");
            entity.Property(e => e.totalPrice).HasColumnName("totalPrice");
            entity.Property(e => e.TimeCheckIn)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("timeCheckIn");
            entity.Property(e => e.TimeCheckOut).HasColumnName("timeCheckOut");

            entity.HasOne(d => d.IdTableBiaNavigation).WithMany(p => p.Bills)
                .HasForeignKey(d => d.IdTableBia)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Bill__idTableBia__571DF1D5");
        });

        modelBuilder.Entity<BillInfo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__BillInfo__3213E83FB1165468");

            entity.ToTable("BillInfo");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.IdBill).HasColumnName("idBill");
            entity.Property(e => e.IdWater).HasColumnName("idWater");
            entity.Property(e => e.Quantity).HasColumnName("quantity");

            entity.HasOne(d => d.IdBillNavigation).WithMany(p => p.BillInfos)
                .HasForeignKey(d => d.IdBill)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__BillInfo__idBill__5812160E");

            entity.HasOne(d => d.IdWaterNavigation).WithMany(p => p.BillInfos)
                .HasForeignKey(d => d.IdWater)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__BillInfo__idWate__59063A47");
        });

        modelBuilder.Entity<TableBia>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__TableBia__3213E83F32D75945");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.IdCategory).HasColumnName("idCategory");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
            entity.Property(e => e.Status)
                .HasMaxLength(100)
                .HasDefaultValue("Trống")
                .HasColumnName("status");

            entity.HasOne(d => d.IdCategoryNavigation).WithMany(p => p.TableBia)
                .HasForeignKey(d => d.IdCategory)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__TableBia__idCate__59FA5E80");
        });

        modelBuilder.Entity<TableCategory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__TableCat__3213E83FC6B6B111");

            entity.ToTable("TableCategory");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
            entity.Property(e => e.Price).HasColumnName("price");
        });

        modelBuilder.Entity<Water>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Water__3213E83F73DABD83");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
            entity.Property(e => e.Price).HasColumnName("price");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
