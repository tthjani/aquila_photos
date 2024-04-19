using APhoto_backend.Models;
using Microsoft.EntityFrameworkCore;

namespace APhoto_backend.Data;

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
}