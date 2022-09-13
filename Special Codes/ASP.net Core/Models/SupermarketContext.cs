using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace SupermarketProA.Models
{
    public partial class SupermarketContext : DbContext
    {
        //public SupermarketContext()
        //{
        //}

        public SupermarketContext(DbContextOptions<SupermarketContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cart> Cart { get; set; }
        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<Items> Items { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=HOD-LT-IT006;Initial Catalog=Supermarket;User ID=sa;Password=@dmnL0ca1");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cart>(entity =>
            {
                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Cart)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Cart_Customer");

                entity.HasOne(d => d.Item)
                    .WithMany(p => p.Cart)
                    .HasForeignKey(d => d.ItemId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Cart_Items");
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.Property(e => e.CustomerName).IsUnicode(false);
            });

            modelBuilder.Entity<Items>(entity =>
            {
                entity.Property(e => e.ItemName).IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
