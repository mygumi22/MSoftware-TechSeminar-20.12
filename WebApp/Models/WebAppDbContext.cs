using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Models
{
    public class WebAppDbContext : DbContext
    {
        public WebAppDbContext(DbContextOptions<WebAppDbContext> options) 
            : base(options)
        {

        }

        public DbSet<FruitModel> Fruit { get; set; }
        public DbSet<GoodsModel> Goods { get; set; }
        public DbSet<OrderModel> Order { get; set; }
        public DbSet<StoreModel> Store { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FruitModel>(entity =>
            {
                entity.HasKey(e => e.fruitidx)
                    .HasName("PRIMARY");

                entity.ToTable("fruit");

                entity.Property(e => e.fruitidx)
                    .HasColumnName("fruitidx")
                    .HasColumnType("int(11)");

                entity.Property(e => e.name)
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_bin");

            });

            modelBuilder.Entity<GoodsModel>(entity =>
            {
                entity.HasKey(e => e.goodsidx)
                    .HasName("PRIMARY");

                entity.ToTable("goods");

                entity.Property(e => e.goodsidx)
                    .HasColumnName("goodsidx")
                    .HasColumnType("int(11)");

                entity.Property(e => e.fruitidx)
                    .HasColumnName("fruitidx")
                    .HasColumnType("int(11)");

                entity.Property(e => e.price)
                   .HasColumnName("price")
                   .HasColumnType("int(11)");

            });

            modelBuilder.Entity<OrderModel>(entity =>
            {
                entity.HasKey(e => e.orderidx)
                    .HasName("PRIMARY");

                entity.ToTable("order");

                entity.Property(e => e.orderidx)
                    .HasColumnName("orderidx")
                    .HasColumnType("int(11)");

                entity.Property(e => e.goodsidx)
                    .HasColumnName("goodsidx")
                    .HasColumnType("int(11)");

                entity.Property(e => e.orderdate).HasColumnType("datetime");

            });

            modelBuilder.Entity<StoreModel>(entity =>
            {
                entity.HasKey(e => e.storeidx)
                    .HasName("PRIMARY");

                entity.ToTable("store");

                entity.Property(e => e.storeidx)
                    .HasColumnName("storeidx")
                    .HasColumnType("int(11)");

                entity.Property(e => e.storename)
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_bin");

                entity.Property(e => e.delegatename)
                    .HasColumnType("varchar(50)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_bin");

            });
        }

    }
}
