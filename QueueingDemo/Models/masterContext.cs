using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace QueueingDemo.Models
{
    public partial class masterContext : DbContext
    {
        public masterContext()
        {
        }

        public masterContext(DbContextOptions<masterContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Service> Service { get; set; }
        public virtual DbSet<ServiceProviders> ServiceProviders { get; set; }
        public virtual DbSet<ServiceRooms> ServiceRooms { get; set; }
        public virtual DbSet<Ticket> Ticket { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=serveo.net;Initial Catalog=master; user id=sa; password=Fortune123;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Service>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ServiceProviders>(entity =>
            {
                entity.ToTable("Service_Providers");

                entity.Property(e => e.Address)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.PhoneNumber).HasColumnName("Phone_number");

                entity.HasOne(d => d.Service)
                    .WithMany(p => p.ServiceProviders)
                    .HasForeignKey(d => d.ServiceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKService_Pr438418");
            });

            modelBuilder.Entity<ServiceRooms>(entity =>
            {
                entity.ToTable("Service_Rooms");

                entity.Property(e => e.AssignmentDate)
                    .HasColumnName("Assignment_date")
                    .HasColumnType("date");

                entity.Property(e => e.Room)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.Service)
                    .WithMany(p => p.ServiceRooms)
                    .HasForeignKey(d => d.ServiceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKService_Ro529374");
            });

            modelBuilder.Entity<Ticket>(entity =>
            {
                entity.Property(e => e.CreationTime).HasColumnName("Creation_time");

                entity.Property(e => e.FinishTime).HasColumnName("Finish_time");

                entity.Property(e => e.Prefix)
                    .IsRequired()
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.ServiceProvidersId).HasColumnName("Service_ProvidersId");

                entity.HasOne(d => d.ServiceProviders)
                    .WithMany(p => p.Ticket)
                    .HasForeignKey(d => d.ServiceProvidersId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKTicket969093");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
