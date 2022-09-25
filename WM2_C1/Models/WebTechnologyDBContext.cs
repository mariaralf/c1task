using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WM2_C1
{
    public partial class WebTechnologyDBContext : DbContext
    {
        public WebTechnologyDBContext()
        {
        }

        public WebTechnologyDBContext(DbContextOptions<WebTechnologyDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Booking> Bookings { get; set; } = null!;
        public virtual DbSet<Hotel> Hotels { get; set; } = null!;
        public virtual DbSet<Role> Roles { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server= mysqlserver260420.database.windows.net; Database=WebTechnologyDB; User ID=azureuser;Password=qazseQAZSE!;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Booking>(entity =>
            {
                entity.Property(e => e.BookingId).HasColumnName("Booking_Id");

                entity.Property(e => e.BookingDate)
                    .HasColumnType("date")
                    .HasColumnName("Booking_Date");

                entity.Property(e => e.BookingHotelId).HasColumnName("Booking_HotelId");

                entity.Property(e => e.BookingUserId).HasColumnName("Booking_UserId");

                entity.HasOne(d => d.BookingHotel)
                    .WithMany(p => p.Bookings)
                    .HasForeignKey(d => d.BookingHotelId)
                    .HasConstraintName("FK__Bookings__Bookin__38996AB5");

                entity.HasOne(d => d.BookingUser)
                    .WithMany(p => p.Bookings)
                    .HasForeignKey(d => d.BookingUserId)
                    .HasConstraintName("FK__Bookings__Bookin__37A5467C");
            });

            modelBuilder.Entity<Hotel>(entity =>
            {
                entity.Property(e => e.HotelId).HasColumnName("Hotel_Id");

                entity.Property(e => e.HotelDesc)
                    .HasColumnType("text")
                    .HasColumnName("Hotel_Desc");

                entity.Property(e => e.HotelImage)
                    .HasMaxLength(200)
                    .HasColumnName("Hotel_Image");

                entity.Property(e => e.HotelName)
                    .HasMaxLength(100)
                    .HasColumnName("Hotel_Name");

                entity.Property(e => e.HotelNightPrice).HasColumnName("Hotel_Night_Price");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.Property(e => e.RoleId).HasColumnName("Role_Id");

                entity.Property(e => e.RoleName)
                    .HasMaxLength(50)
                    .HasColumnName("Role_Name");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.UserId).HasColumnName("User_Id");

                entity.Property(e => e.UserEmail)
                    .HasMaxLength(100)
                    .HasColumnName("User_Email");

                entity.Property(e => e.UserName)
                    .HasMaxLength(50)
                    .HasColumnName("User_Name");

                entity.Property(e => e.UserPhone)
                    .HasMaxLength(20)
                    .HasColumnName("User_Phone");

                entity.Property(e => e.UserRole).HasColumnName("User_Role");

                entity.Property(e => e.UserSurname)
                    .HasMaxLength(50)
                    .HasColumnName("User_Surname");

                entity.HasOne(d => d.UserRoleNavigation)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.UserRole)
                    .HasConstraintName("FK__Users__User_Role__2A4B4B5E");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
