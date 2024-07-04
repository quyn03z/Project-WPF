using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DataAcess.Models;

public partial class QuanLyHotelContext : DbContext
{
    public QuanLyHotelContext()
    {
    }

    public QuanLyHotelContext(DbContextOptions<QuanLyHotelContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<RoomInformation> RoomInformations { get; set; }

    public virtual DbSet<RoomType> RoomTypes { get; set; }
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
        modelBuilder.Entity<Customer>(entity =>
        {
            entity.ToTable("Customer");

            entity.Property(e => e.CustomerFullName)
                .HasMaxLength(50)
                .IsFixedLength();
            entity.Property(e => e.EmailAddress)
                .HasMaxLength(50)
                .IsFixedLength();
            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .IsFixedLength();
            entity.Property(e => e.TelePhone)
                .HasMaxLength(10)
                .IsFixedLength();
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.ToTable("Order");

            entity.Property(e => e.CustomerId).HasColumnName("CustomerID");
            entity.Property(e => e.OrderDate).HasColumnType("datetime");
            entity.Property(e => e.RoomId).HasColumnName("RoomID");

            entity.HasOne(o => o.RoomInformation)
             .WithMany()
             .HasForeignKey(o => o.RoomId)
             .OnDelete(DeleteBehavior.ClientSetNull) // or another delete behavior
             .HasConstraintName("FK_Order_RoomInformation");
        });

        modelBuilder.Entity<RoomInformation>(entity =>
        {
            entity.HasKey(e => e.RoomId);

            entity.ToTable("RoomInformation");

            entity.Property(e => e.RoomId).HasColumnName("RoomID");
            entity.Property(e => e.RoomDescription)
                .HasMaxLength(220)
                .IsFixedLength();
            entity.Property(e => e.RoomNumber)
                .HasMaxLength(50)
                .IsFixedLength();
            entity.Property(e => e.RoomPricePerDate).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.RoomTypeId).HasColumnName("RoomTypeID");
        });

        modelBuilder.Entity<RoomType>(entity =>
        {
            entity.ToTable("RoomType");

            entity.Property(e => e.RoomTypeId).HasColumnName("RoomTypeID");
            entity.Property(e => e.RoomTypeName)
                .HasMaxLength(50)
                .IsFixedLength();
            entity.Property(e => e.TypeDescription)
                .HasMaxLength(250)
                .IsFixedLength();
            entity.Property(e => e.TypenNote)
                .HasMaxLength(250)
                .IsFixedLength();
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
