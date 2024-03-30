using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Api_Smart_Counters.Models
{
    public partial class Smart_CountersContext : DbContext
    {
        public Smart_CountersContext()
        {
        }

        public Smart_CountersContext(DbContextOptions<Smart_CountersContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Counter> Counters { get; set; } = null!;
        public virtual DbSet<Device> Devices { get; set; } = null!;
        public virtual DbSet<LeakSensor> LeakSensors { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=Kompik-Bebrik\\MYNAME;Initial Catalog=Smart_Counters;Persist Security Info=True;User ID=sa;Password=123");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Counter>(entity =>
            {
                entity.HasKey(e => e.IdCounters);

                entity.Property(e => e.IdCounters).HasColumnName("ID_Counters");

                entity.Property(e => e.DatePush)
                    .HasColumnType("date")
                    .HasColumnName("Date_Push");

                entity.Property(e => e.DevicesId).HasColumnName("Devices_ID");

                entity.Property(e => e.TimePush).HasColumnName("Time_Push");

                entity.Property(e => e.TypeCounter).HasColumnName("Type_Counter");

            });

            modelBuilder.Entity<Device>(entity =>
            {
                entity.HasKey(e => e.IdDevices);

                entity.Property(e => e.IdDevices).HasColumnName("ID_Devices");

                entity.Property(e => e.DateLastConnect)
                    .HasColumnType("date")
                    .HasColumnName("Date_Last_Connect");

                entity.Property(e => e.DeviceName)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("Device_Name");

                entity.Property(e => e.TimeLastConnect).HasColumnName("Time_Last_Connect");

                entity.Property(e => e.TransmitRate).HasColumnName("Transmit_Rate");

                entity.Property(e => e.UsersId).HasColumnName("Users_ID");

              
            });

            modelBuilder.Entity<LeakSensor>(entity =>
            {
                entity.HasKey(e => e.IdLeakSensors);

                entity.ToTable("Leak_Sensors");

                entity.Property(e => e.IdLeakSensors).HasColumnName("ID_Leak_Sensors");

                entity.Property(e => e.DateActivation)
                    .HasColumnType("date")
                    .HasColumnName("Date_Activation");

                entity.Property(e => e.DevicesId).HasColumnName("Devices_ID");

                entity.Property(e => e.TimeActivation).HasColumnName("Time_Activation");

           
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.IdUsers);

                entity.HasIndex(e => e.EMail, "UQ_Mail")
                    .IsUnique();

                entity.HasIndex(e => e.PhoneNumber, "UQ_Number")
                    .IsUnique();

                entity.Property(e => e.IdUsers).HasColumnName("ID_Users");

                entity.Property(e => e.EMail)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("E_Mail");

                entity.Property(e => e.FirstName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("First_Name");

                entity.Property(e => e.PasswordUser)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("Password_user");

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(17)
                    .IsUnicode(false)
                    .HasColumnName("Phone_Number");

                entity.Property(e => e.SecondName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Second_Name");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
