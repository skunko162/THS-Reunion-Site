#pragma warning disable CS8618

using Microsoft.EntityFrameworkCore;
namespace TroyHsReunionPage.Models;


public class MyContext : DbContext
{
    public MyContext(DbContextOptions options) : base(options){}
    public DbSet<User> Users {get;set;}
    public DbSet<Story> Stories {get;set;}
    public DbSet<OrderDetail> OrderDetails {get;set;}
    public DbSet<Order> Orders {get;set;}
    public DbSet<Image> Images {get;set;}
}