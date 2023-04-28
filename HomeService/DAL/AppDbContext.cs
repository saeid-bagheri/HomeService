using System;
using System.Collections.Generic;
using HomeService.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace HomeService.DAL;

public partial class AppDbContext : DbContext
{

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
        
    }

    //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //{
    //    optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=db_HomeService1;Trusted_Connection=True;TrustServerCertificate=True;");
    //}

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<ExpertService> ExpertServices { get; set; }

    public virtual DbSet<Offer> Offers { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Service> Services { get; set; }

    public virtual DbSet<User> Users { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ExpertService>(entity =>
        {
            entity.HasKey(e => new { e.ExpertId, e.ServiceId });

            entity.ToTable("ExpertService");

            entity.HasOne(d => d.Expert).WithMany(p => p.ExpertServices)
                .HasForeignKey(d => d.ExpertId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ExpertService_Users");

            entity.HasOne(d => d.Service).WithMany(p => p.ExpertServices)
                .HasForeignKey(d => d.ServiceId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ExpertService_Services");
        });

        modelBuilder.Entity<Offer>(entity =>
        {
            entity.HasIndex(e => e.OrderId, "IX_Offers_OrderId");

            entity.HasOne(d => d.Order).WithMany(p => p.Offers).HasForeignKey(d => d.OrderId);
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasIndex(e => e.CustomerId, "IX_Orders_CustomerId");

            entity.HasIndex(e => e.ExpertId, "IX_Orders_ExpertId");

            entity.HasIndex(e => e.ServiceId, "IX_Orders_ServiceId");

            entity.HasOne(d => d.Customer).WithMany(p => p.OrderCustomers).HasForeignKey(d => d.CustomerId);

            entity.HasOne(d => d.Expert).WithMany(p => p.OrderExperts).HasForeignKey(d => d.ExpertId);

            entity.HasOne(d => d.Service).WithMany(p => p.Orders).HasForeignKey(d => d.ServiceId);
        });

        modelBuilder.Entity<Service>(entity =>
        {
            entity.HasIndex(e => e.CategoryId, "IX_Services_CategoryId");

            entity.HasOne(d => d.Category).WithMany(p => p.Services).HasForeignKey(d => d.CategoryId);

            //entity.HasMany(d => d.Users).WithMany(p => p.Services)
            //    .UsingEntity<Dictionary<string, object>>(
            //        "ServiceUser",
            //        r => r.HasOne<User>().WithMany().HasForeignKey("UsersId"),
            //        l => l.HasOne<Service>().WithMany().HasForeignKey("ServicesId"),
            //        j =>
            //        {
            //            j.HasKey("ServicesId", "UsersId");
            //            j.ToTable("ServiceUser");
            //            j.HasIndex(new[] { "UsersId" }, "IX_ServiceUser_UsersId");
            //        });
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasIndex(e => e.RoleId, "IX_Users_RoleId");

            entity.HasOne(d => d.Role).WithMany(p => p.Users).HasForeignKey(d => d.RoleId);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
