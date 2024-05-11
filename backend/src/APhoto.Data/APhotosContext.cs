using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace APhoto.Data;

public class APhotosContext(DbContextOptions<APhotosContext> options) : DbContext(options)
{
    public DbSet<Order> Order { get; set; }

    public DbSet<Holiday> Holiday { get; set; }

    // Below Datasets are commented, because they're not required to be deployed in the database, their schema isn't properly planned yet
    //public DbSet<Gallery> Gallery { get; set; }
    //public DbSet<Announcement> Announcement { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Order>()
            .HasKey(o => o.OrderId);
        modelBuilder.Entity<Order>()
            .Property(p => p.CreatedAt)
            .HasDefaultValueSql("GETUTCDATE()")
            .IsRequired();
        modelBuilder.Entity<Order>()
            .Property(p => p.OrderType)
            .IsRequired();
        modelBuilder.Entity<Order>()
            .Property(p => p.ClientName)
            .IsRequired();
        modelBuilder.Entity<Order>()
            .Property(p => p.ContactInformation)
            .IsRequired();
        modelBuilder.Entity<Order>()
            .Property(p => p.FbUrl)
            .IsRequired();
        modelBuilder.Entity<Order>()
            .Property(p => p.Message)
            .IsRequired();
        modelBuilder.Entity<Order>()
            .Property(p => p.OrderStatus)
            .IsRequired();

        modelBuilder.Entity<Holiday>()
            .HasKey(k => k.HolidayId);
        modelBuilder.Entity<Holiday>()
            .Property(p => p.StartDate)
            .IsRequired()
            .HasColumnType("date");
        modelBuilder.Entity<Holiday>()
            .Property(p => p.EndDate)
            .IsRequired()
            .HasColumnType("date");
        modelBuilder.Entity<Holiday>()
            .Property(p => p.AllowOrders)
            .IsRequired()
            .HasDefaultValue(false);

        base.OnModelCreating(modelBuilder);
    }
}