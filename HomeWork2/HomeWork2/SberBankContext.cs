using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace HomeWork2;

public partial class SberBankContext : DbContext
{
    public SberBankContext()
    {
    }

    public SberBankContext(DbContextOptions<SberBankContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Account> Accounts { get; set; }

    public virtual DbSet<Client> Clients { get; set; }

    public virtual DbSet<Deposit> Deposits { get; set; }

    public virtual DbSet<Manager> Managers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=SberBank;Username=postgres;Password=postgres");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Account>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("accounts_pkey");

            entity.ToTable("accounts");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Amount).HasColumnName("amount");
        });

        modelBuilder.Entity<Client>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("clients_pkey");

            entity.ToTable("clients");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Accountid).HasColumnName("accountid");
            entity.Property(e => e.Depositid).HasColumnName("depositid");
            entity.Property(e => e.Email)
                .HasMaxLength(30)
                .HasColumnName("email");
            entity.Property(e => e.Firstname)
                .HasMaxLength(30)
                .HasColumnName("firstname");
            entity.Property(e => e.Lastname)
                .HasMaxLength(30)
                .HasColumnName("lastname");
            entity.Property(e => e.Passportnumber)
                .HasMaxLength(30)
                .HasColumnName("passportnumber");
            entity.Property(e => e.Patronymic)
                .HasMaxLength(30)
                .HasColumnName("patronymic");
            entity.Property(e => e.Phonenumber)
                .HasMaxLength(30)
                .HasColumnName("phonenumber");

            entity.HasOne(d => d.Account).WithMany(p => p.Clients)
                .HasForeignKey(d => d.Accountid)
                .HasConstraintName("clients_accountid_fkey");

            entity.HasOne(d => d.Deposit).WithMany(p => p.Clients)
                .HasForeignKey(d => d.Depositid)
                .HasConstraintName("clients_depositid_fkey");
        });

        modelBuilder.Entity<Deposit>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("deposits_pkey");

            entity.ToTable("deposits");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Managerid).HasColumnName("managerid");
            entity.Property(e => e.Opennigdate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("opennigdate");

            entity.HasOne(d => d.Manager).WithMany(p => p.Deposits)
                .HasForeignKey(d => d.Managerid)
                .HasConstraintName("deposits_managerid_fkey");
        });

        modelBuilder.Entity<Manager>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("managers_pkey");

            entity.ToTable("managers");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Email)
                .HasMaxLength(30)
                .HasColumnName("email");
            entity.Property(e => e.Firstname)
                .HasMaxLength(30)
                .HasColumnName("firstname");
            entity.Property(e => e.Lastname)
                .HasMaxLength(30)
                .HasColumnName("lastname");
            entity.Property(e => e.Managerposition)
                .HasMaxLength(30)
                .HasColumnName("managerposition");
            entity.Property(e => e.Patronymic)
                .HasMaxLength(30)
                .HasColumnName("patronymic");
            entity.Property(e => e.Phonenumber)
                .HasMaxLength(30)
                .HasColumnName("phonenumber");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
