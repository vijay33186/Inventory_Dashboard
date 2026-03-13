using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Inventory_Management.Models;

public partial class InventoryContext : DbContext
{
    public InventoryContext()
    {
    }

    public InventoryContext(DbContextOptions<InventoryContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Inventory> Inventories { get; set; }

    public virtual DbSet<User> Users { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Inventory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("inventory_pkey");

            entity.Property(e => e.Createddate).HasDefaultValueSql("CURRENT_TIMESTAMP");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("users_pkey");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
