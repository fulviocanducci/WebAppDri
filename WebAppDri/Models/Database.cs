using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebAppDri.Models
{
    public class Database: DbContext
    {
        public Database()
            :base("DefaultConnection")
        {
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
        }

        public DbSet<Product> Product { get; set; }
        public DbSet<Kind> Kind { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .ToTable("Product")
                .HasKey(x => x.Id)
                .Property(x => x.Id)
                .IsRequired()
                .HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);

            modelBuilder.Entity<Product>()                
                .Property(x => x.Description)
                .HasMaxLength(100)
                .IsRequired();

            modelBuilder.Entity<Product>()
                .Property(x => x.KindId)                
                .IsRequired();

            modelBuilder.Entity<Product>()
                .HasRequired(x => x.Kind)
                .WithMany(x => x.Products)
                .HasForeignKey(x => x.KindId)
                .WillCascadeOnDelete(false);


            modelBuilder.Entity<Kind>()
                .ToTable("Kind")
                .HasKey(x => x.Id)
                .Property(x => x.Id)
                .IsRequired()
                .HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);

            modelBuilder.Entity<Kind>()
                .Property(x => x.Title)
                .HasMaxLength(100)
                .IsRequired();

            modelBuilder.Entity<Kind>()
                .HasMany(x => x.Products)
                .WithRequired(x => x.Kind)
                .HasForeignKey(x => x.KindId)
                .WillCascadeOnDelete(false);
        }
    }
}