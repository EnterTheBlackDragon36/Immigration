using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Immigration.Models;

public partial class ImmigrantContext : DbContext
{
    public ImmigrantContext()
    {
    }

    public ImmigrantContext(DbContextOptions<ImmigrantContext> options, IConfiguration configuration)
        : base(options)
    {
        Configuration = configuration;
    }
    public IConfiguration Configuration { get; }
    public virtual DbSet<GlobalCity> GlobalCities { get; set; }
    public virtual DbSet<GlobalCountry> GlobalCountries { get; set; }
    public virtual DbSet<ImmigrationKey> ImmigrationKeys { get; set; }
    public virtual DbSet<ShipVessel> ShipVessels { get; set; }
    public virtual DbSet<Travel> Travels { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (optionsBuilder.IsConfigured)
        {
            var connString = Configuration.GetConnectionString("ImmigrationConnection");

            optionsBuilder.UseSqlServer(connString);
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<GlobalCity>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.City).HasMaxLength(200);
            entity.Property(e => e.CityAbbrCode).HasMaxLength(200);
            entity.Property(e => e.CountryCode).HasMaxLength(200);
            entity.Property(e => e.LongLatCode).HasMaxLength(200);
        });

        modelBuilder.Entity<GlobalCountry>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.Country).HasMaxLength(200);
            entity.Property(e => e.CountryCode).HasMaxLength(200);
        });

        modelBuilder.Entity<ImmigrationKey>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.OccupationKey).HasColumnName("occupationKey");
            entity.Property(e => e.OriginCityKey).HasColumnName("originCityKey");
            entity.Property(e => e.OriginCountryKey).HasColumnName("originCountryKey");
            entity.Property(e => e.PersonKey).HasColumnName("personKey");
            entity.Property(e => e.SettlementCityKey).HasColumnName("settlementCityKey");
            entity.Property(e => e.SettlementStateKey).HasColumnName("settlementStateKey");
            entity.Property(e => e.VesselKey).HasColumnName("vesselKey");
        });

        modelBuilder.Entity<ShipVessel>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("ShipVessel");

            entity.Property(e => e.BuilderAndLocation).HasMaxLength(500);
            entity.Property(e => e.Dimensions).HasMaxLength(200);
            entity.Property(e => e.Line).HasMaxLength(200);
            entity.Property(e => e.MastsAndFunnels).HasMaxLength(500);
            entity.Property(e => e.Passengers).HasMaxLength(500);
            entity.Property(e => e.Vessel).HasMaxLength(200);
        });

        modelBuilder.Entity<Travel>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Travel");

            entity.Property(e => e.AmountOfMoney).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.Arrival)
                .HasColumnType("datetime")
                .HasColumnName("arrival");
            entity.Property(e => e.City).HasMaxLength(100);
            entity.Property(e => e.CityAbbrCode).HasMaxLength(100);
            entity.Property(e => e.Country).HasMaxLength(100);
            entity.Property(e => e.CountryCode).HasMaxLength(50);
            entity.Property(e => e.Departure)
                .HasColumnType("datetime")
                .HasColumnName("departure");
            entity.Property(e => e.PersonId).HasColumnName("personId");
            entity.Property(e => e.Profession)
                .HasMaxLength(100)
                .HasColumnName("profession");
            entity.Property(e => e.Vessel).HasMaxLength(100);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
