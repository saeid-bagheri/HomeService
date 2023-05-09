﻿using System;
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

    public virtual DbSet<Bid> Bids { get; set; }

    public virtual DbSet<BidStatus> BidStatuses { get; set; }

    public virtual DbSet<City> Cities { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<CustomerAddress> CustomerAddresses { get; set; }

    public virtual DbSet<Expert> Experts { get; set; }

    public virtual DbSet<ExpertService> ExpertServices { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrderService> OrderServices { get; set; }

    public virtual DbSet<OrderStatus> OrderStatuses { get; set; }

    public virtual DbSet<Service> Services { get; set; }

    public virtual DbSet<ServiceCategory> ServiceCategories { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Bid>(entity =>
        {
            entity.Property(e => e.ExpertSuggestionComment).HasMaxLength(2000);

            entity.HasOne(d => d.Expert).WithMany(p => p.Bids)
                .HasForeignKey(d => d.ExpertId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Bids_Experts");

            entity.HasOne(d => d.Order).WithMany(p => p.Bids)
                .HasForeignKey(d => d.OrderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Bids_Orders");

            entity.HasOne(d => d.Status).WithMany(p => p.Bids)
                .HasForeignKey(d => d.StatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Bids_BidStatuses");
        });

        modelBuilder.Entity<BidStatus>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Title).HasMaxLength(250);
            //entity.HasData()

        });

        modelBuilder.Entity<City>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Title).HasMaxLength(250);
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.Property(e => e.BackupMobileNumber).HasMaxLength(11);
            entity.Property(e => e.FirstName).HasMaxLength(250);
            entity.Property(e => e.LastName).HasMaxLength(250);
            entity.Property(e => e.MobileNumber).HasMaxLength(11);
            entity.HasData(new Customer()
            {
                Id = 1,
                FirstName = "ali",
                LastName = "MMMM",
                BackupMobileNumber = "09121213322",
                Birthdate = new DateTime(2009, 05, 09, 9, 15, 0),
                CityId = 1,
                CreatedAt = new DateTime(2023, 05, 09, 9, 15, 0),
                CreatedBy = 12,
                GenderId = 0,
                MobileNumber = "09361458723",
                ScoreAvg = 12,
                UserId = null,
                CustomerAddresses = null,
                IsDeleted = false,
                LastModifiedAt = DateTime.Now,
                LastModifiedBy = 12
                
            });
        });

        modelBuilder.Entity<CustomerAddress>(entity =>
        {
            entity.Property(e => e.CityRegionTitle).HasMaxLength(250);
            entity.Property(e => e.FullAddress).HasMaxLength(500);

            entity.HasOne(d => d.Customer).WithMany(p => p.CustomerAddresses)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CustomerAddresses_Customers");
        });

        modelBuilder.Entity<Expert>(entity =>
        {
            entity.Property(e => e.BackupMobileNumber).HasMaxLength(11);
            entity.Property(e => e.CompanyName).HasMaxLength(250);
            entity.Property(e => e.FirstName).HasMaxLength(250);
            entity.Property(e => e.HomeAddress).HasMaxLength(500);
            entity.Property(e => e.LastName).HasMaxLength(250);
            entity.Property(e => e.MobileNumber).HasMaxLength(11);

            entity.HasOne(d => d.City).WithMany(p => p.Experts)
                .HasForeignKey(d => d.CityId)
                .HasConstraintName("FK_Experts_Cities");
        });

        modelBuilder.Entity<ExpertService>(entity =>
        {
            entity.HasOne(d => d.Expert).WithMany(p => p.ExpertServices)
                .HasForeignKey(d => d.ExpertId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ExpertServices_Experts");

            entity.HasOne(d => d.Service).WithMany(p => p.ExpertServices)
                .HasForeignKey(d => d.ServiceId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ExpertServices_Services");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasOne(d => d.Customer).WithMany(p => p.Orders)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Orders_Customers");

            entity.HasOne(d => d.Status).WithMany(p => p.Orders)
                .HasForeignKey(d => d.StatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Orders_OrderStatues");
        });

        modelBuilder.Entity<OrderService>(entity =>
        {
            entity.HasOne(d => d.Order).WithMany(p => p.OrderServices)
                .HasForeignKey(d => d.OrderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrderServices_Orders");

            entity.HasOne(d => d.Service).WithMany(p => p.OrderServices)
                .HasForeignKey(d => d.ServiceId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrderServices_Services");
        });

        modelBuilder.Entity<OrderStatus>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Title).HasMaxLength(250);
        });

        modelBuilder.Entity<Service>(entity =>
        {
            entity.Property(e => e.Title).HasMaxLength(250);

            entity.HasOne(d => d.Category).WithMany(p => p.Services)
                .HasForeignKey(d => d.CategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Services_ServiceCategories");
        });

        modelBuilder.Entity<ServiceCategory>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Title).HasMaxLength(250);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

