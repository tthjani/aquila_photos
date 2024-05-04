﻿using Microsoft.EntityFrameworkCore;

namespace APhoto.Data;

public class APhotosContext : DbContext
{
    public APhotosContext(DbContextOptions<APhotosContext> options) : base(options)
    {
    }

    public DbSet<Order> Orders { get; set; }
    public DbSet<Gallery> Galleries { get; set; }
    public DbSet<Holiday> Holidays { get; set; }
    public DbSet<AcceptedOrder> AcceptedOrders { get; set; }
    public DbSet<Announcement> Announcements { get; set; }
    public DbSet<FinishedOrder> FinishedOrders { get; set; }
    public DbSet<DeclinedOrder> DeclinedOrders { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AcceptedOrder>().ToTable("AcceptedOrders");
        modelBuilder.Entity<DeclinedOrder>().ToTable("DeclinedOrders");
        modelBuilder.Entity<FinishedOrder>().ToTable("FinishedOrders");

        base.OnModelCreating(modelBuilder);
    }
}