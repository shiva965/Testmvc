using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ProjectPractice.Models
{
    public partial class PracticeProjectContext : DbContext
    {
        public PracticeProjectContext()
        {
        }

        public PracticeProjectContext(DbContextOptions<PracticeProjectContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Orders> Orders { get; set; }
        public virtual DbSet<Procuct> Procuct { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
//                optionsBuilder.UseSqlServer("Server=DESKTOP-SRDJ1O4\\SQLEXPRESS;Database=PracticeProject;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Orders>(entity =>
            {
                entity.HasKey(e => e.Oid)
                    .HasName("PK__Orders__CB3E4F31F6809B94");

                entity.Property(e => e.OrderDate).HasColumnType("date");

                entity.Property(e => e.OrderName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK__Orders__ProductI__3B75D760");
            });

            modelBuilder.Entity<Procuct>(entity =>
            {
                entity.HasKey(e => e.Pid)
                    .HasName("PK__Procuct__C570593856E71927");

                entity.Property(e => e.Description)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ProductName)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
