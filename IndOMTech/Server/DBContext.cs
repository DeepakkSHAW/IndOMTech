using IndOMTech.Client.Pages;
using IndOMTech.Shared.Models;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;

namespace IndOMTech.Server;

public class DBContext : DbContext
{
    //INSERT into TUsers (name, lastame) VALUES ('Divs', 'Shaw')
    //INSERT into TUsers (name, lastame) VALUES ('Divs', 'Shaw')
    //INSERT into TUsers (name, lastame) VALUES ('Divs', 'Shaw')
    //INSERT into TUsers (name, lastame) VALUES ('Divs', 'Shaw')
    public DbSet<Users> Users { get; set; }
    public DBContext(DbContextOptions<DBContext> options) : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Users>(entity =>
        {
            entity.ToTable("TUsers");
            // Set key for entity
            entity.HasKey(p => p.UserID);
            entity.Property(p => p.InDate).HasDefaultValueSql("CURRENT_TIMESTAMP");
        });
    }
}