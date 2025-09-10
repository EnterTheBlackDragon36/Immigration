using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace GetImmigration.Models;

public partial class ImmigrationContext : DbContext
{
    public ImmigrationContext()
    {
    }

    public ImmigrationContext(DbContextOptions<ImmigrationContext> options, IConfiguration configuration)
        : base(options)
    {
        Configuration = configuration;
    }

    public IConfiguration Configuration { get; }
    public virtual DbSet<Alabama> Alabamas { get; set; }

    public virtual DbSet<Alaska> Alaskas { get; set; }

    public virtual DbSet<Arizona> Arizonas { get; set; }

    public virtual DbSet<Arkansa> Arkansas { get; set; }

    public virtual DbSet<Californium> California { get; set; }

    public virtual DbSet<Colorado> Colorados { get; set; }

    public virtual DbSet<Connecticut> Connecticuts { get; set; }

    public virtual DbSet<Delaware> Delawares { get; set; }

    public virtual DbSet<Floridum> Florida { get; set; }

    public virtual DbSet<Georgium> Georgia { get; set; }

    public virtual DbSet<GlobalCity> GlobalCities { get; set; }

    public virtual DbSet<GlobalCountry> GlobalCountries { get; set; }

    public virtual DbSet<Hawaii> Hawaiis { get; set; }

    public virtual DbSet<Idaho> Idahos { get; set; }

    public virtual DbSet<Illinoi> Illinois { get; set; }

    public virtual DbSet<ImmigrationKey> ImmigrationKeys { get; set; }

    public virtual DbSet<Indiana> Indianas { get; set; }

    public virtual DbSet<Iowa> Iowas { get; set; }

    public virtual DbSet<Kansa> Kansas { get; set; }

    public virtual DbSet<Kentucky> Kentuckies { get; set; }

    public virtual DbSet<Louisiana> Louisianas { get; set; }

    public virtual DbSet<Maine> Maines { get; set; }

    public virtual DbSet<Maryland> Marylands { get; set; }

    public virtual DbSet<Massachusett> Massachusetts { get; set; }

    public virtual DbSet<Michigan> Michigans { get; set; }

    public virtual DbSet<Minnesotum> Minnesota { get; set; }

    public virtual DbSet<Mississippi> Mississippis { get; set; }

    public virtual DbSet<Missouri> Missouris { get; set; }

    public virtual DbSet<Montana> Montanas { get; set; }

    public virtual DbSet<Nebraska> Nebraskas { get; set; }

    public virtual DbSet<Nevadum> Nevada { get; set; }

    public virtual DbSet<NewHampshire> NewHampshires { get; set; }

    public virtual DbSet<NewJersey> NewJerseys { get; set; }

    public virtual DbSet<NewMexico> NewMexicos { get; set; }

    public virtual DbSet<NewYork> NewYorks { get; set; }

    public virtual DbSet<NorthCarolina> NorthCarolinas { get; set; }

    public virtual DbSet<NorthDakotum> NorthDakota { get; set; }

    public virtual DbSet<Ohio> Ohios { get; set; }

    public virtual DbSet<Oklahoma> Oklahomas { get; set; }

    public virtual DbSet<Oregon> Oregons { get; set; }

    public virtual DbSet<Pennsylvanium> Pennsylvania { get; set; }

    public virtual DbSet<RhodeIsland> RhodeIslands { get; set; }

    public virtual DbSet<ShipVessel> ShipVessels { get; set; }

    public virtual DbSet<SouthCarolina> SouthCarolinas { get; set; }

    public virtual DbSet<SouthDakotum> SouthDakota { get; set; }

    public virtual DbSet<Tennessee> Tennessees { get; set; }

    public virtual DbSet<Texa> Texas { get; set; }

    public virtual DbSet<Travel> Travels { get; set; }

    public virtual DbSet<Utah> Utahs { get; set; }

    public virtual DbSet<Vermont> Vermonts { get; set; }

    public virtual DbSet<Virginium> Virginia { get; set; }

    public virtual DbSet<Washington> Washingtons { get; set; }

    public virtual DbSet<WestVirginium> WestVirginia { get; set; }

    public virtual DbSet<Wisconsin> Wisconsins { get; set; }

    public virtual DbSet<Wyoming> Wyomings { get; set; }

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
        modelBuilder.Entity<Alabama>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Alabama");

            entity.Property(e => e.Cities).HasMaxLength(255);
        });

        modelBuilder.Entity<Alaska>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Alaska");

            entity.Property(e => e.Cities).HasMaxLength(255);
        });

        modelBuilder.Entity<Arizona>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Arizona");

            entity.Property(e => e.Cities).HasMaxLength(255);
        });

        modelBuilder.Entity<Arkansa>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.Cities).HasMaxLength(255);
        });

        modelBuilder.Entity<Californium>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.Cities).HasMaxLength(255);
        });

        modelBuilder.Entity<Colorado>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Colorado");

            entity.Property(e => e.Cities).HasMaxLength(255);
        });

        modelBuilder.Entity<Connecticut>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Connecticut");

            entity.Property(e => e.Cities).HasMaxLength(255);
        });

        modelBuilder.Entity<Delaware>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Delaware");

            entity.Property(e => e.Cities).HasMaxLength(255);
        });

        modelBuilder.Entity<Floridum>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.Cities).HasMaxLength(255);
        });

        modelBuilder.Entity<Georgium>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.Cities).HasMaxLength(255);
        });

        modelBuilder.Entity<GlobalCity>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.City).HasMaxLength(200);
            entity.Property(e => e.CityAbbrCode).HasMaxLength(200);
            entity.Property(e => e.CountryCode).HasMaxLength(200);
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.LongLatCode).HasMaxLength(200);
        });

        modelBuilder.Entity<GlobalCountry>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.Country).HasMaxLength(200);
            entity.Property(e => e.CountryCode).HasMaxLength(200);
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
        });

        modelBuilder.Entity<Hawaii>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Hawaii");

            entity.Property(e => e.Cities).HasMaxLength(255);
        });

        modelBuilder.Entity<Idaho>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Idaho");

            entity.Property(e => e.Cities).HasMaxLength(255);
        });

        modelBuilder.Entity<Illinoi>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.Cities).HasMaxLength(255);
        });

        modelBuilder.Entity<ImmigrationKey>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.OccupationKey).HasColumnName("occupationKey");
            entity.Property(e => e.OriginCityKey).HasColumnName("originCityKey");
            entity.Property(e => e.OriginCountryKey).HasColumnName("originCountryKey");
            entity.Property(e => e.PersonKey).HasColumnName("personKey");
            entity.Property(e => e.SettlementCityKey).HasColumnName("settlementCityKey");
            entity.Property(e => e.SettlementStateKey).HasColumnName("settlementStateKey");
            entity.Property(e => e.VesselKey).HasColumnName("vesselKey");
        });

        modelBuilder.Entity<Indiana>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Indiana");

            entity.Property(e => e.Cities).HasMaxLength(255);
        });

        modelBuilder.Entity<Iowa>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Iowa");

            entity.Property(e => e.Cities).HasMaxLength(255);
        });

        modelBuilder.Entity<Kansa>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.Cities).HasMaxLength(255);
        });

        modelBuilder.Entity<Kentucky>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Kentucky");

            entity.Property(e => e.Cities).HasMaxLength(255);
        });

        modelBuilder.Entity<Louisiana>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Louisiana");

            entity.Property(e => e.Cities).HasMaxLength(255);
        });

        modelBuilder.Entity<Maine>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Maine");

            entity.Property(e => e.Cities).HasMaxLength(255);
        });

        modelBuilder.Entity<Maryland>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Maryland");

            entity.Property(e => e.Cities).HasMaxLength(255);
        });

        modelBuilder.Entity<Massachusett>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.Cities).HasMaxLength(255);
        });

        modelBuilder.Entity<Michigan>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Michigan");

            entity.Property(e => e.Cities).HasMaxLength(255);
        });

        modelBuilder.Entity<Minnesotum>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.Cities).HasMaxLength(255);
        });

        modelBuilder.Entity<Mississippi>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Mississippi");

            entity.Property(e => e.Cities).HasMaxLength(255);
        });

        modelBuilder.Entity<Missouri>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Missouri");

            entity.Property(e => e.Cities).HasMaxLength(255);
        });

        modelBuilder.Entity<Montana>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Montana");

            entity.Property(e => e.Cities).HasMaxLength(255);
        });

        modelBuilder.Entity<Nebraska>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Nebraska");

            entity.Property(e => e.Cities).HasMaxLength(255);
        });

        modelBuilder.Entity<Nevadum>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.Cities).HasMaxLength(255);
        });

        modelBuilder.Entity<NewHampshire>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("NewHampshire");

            entity.Property(e => e.Cities).HasMaxLength(255);
        });

        modelBuilder.Entity<NewJersey>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("NewJersey");

            entity.Property(e => e.Cities).HasMaxLength(255);
        });

        modelBuilder.Entity<NewMexico>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("NewMexico");

            entity.Property(e => e.Cities).HasMaxLength(255);
        });

        modelBuilder.Entity<NewYork>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("NewYork");

            entity.Property(e => e.Cities).HasMaxLength(255);
        });

        modelBuilder.Entity<NorthCarolina>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("NorthCarolina");

            entity.Property(e => e.Cities).HasMaxLength(255);
        });

        modelBuilder.Entity<NorthDakotum>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.Cities).HasMaxLength(255);
        });

        modelBuilder.Entity<Ohio>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Ohio");

            entity.Property(e => e.Cities).HasMaxLength(255);
        });

        modelBuilder.Entity<Oklahoma>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Oklahoma");

            entity.Property(e => e.Cities).HasMaxLength(255);
        });

        modelBuilder.Entity<Oregon>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Oregon");

            entity.Property(e => e.Cities).HasMaxLength(255);
        });

        modelBuilder.Entity<Pennsylvanium>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.Cities).HasMaxLength(255);
        });

        modelBuilder.Entity<RhodeIsland>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("RhodeIsland");

            entity.Property(e => e.Cities).HasMaxLength(255);
        });

        modelBuilder.Entity<ShipVessel>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("ShipVessel");

            entity.Property(e => e.BuilderAndLocation).HasMaxLength(500);
            entity.Property(e => e.Dimensions).HasMaxLength(200);
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.Line).HasMaxLength(200);
            entity.Property(e => e.MastsAndFunnels).HasMaxLength(500);
            entity.Property(e => e.Passengers).HasMaxLength(500);
            entity.Property(e => e.Vessel).HasMaxLength(200);
        });

        modelBuilder.Entity<SouthCarolina>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("SouthCarolina");

            entity.Property(e => e.Cities).HasMaxLength(255);
        });

        modelBuilder.Entity<SouthDakotum>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.Cities).HasMaxLength(255);
        });

        modelBuilder.Entity<Tennessee>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Tennessee");

            entity.Property(e => e.Cities).HasMaxLength(255);
        });

        modelBuilder.Entity<Texa>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.Cities).HasMaxLength(255);
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
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.PersonId).HasColumnName("personId");
            entity.Property(e => e.Profession)
                .HasMaxLength(100)
                .HasColumnName("profession");
            entity.Property(e => e.Vessel).HasMaxLength(100);
        });

        modelBuilder.Entity<Utah>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Utah");

            entity.Property(e => e.Cities).HasMaxLength(255);
        });

        modelBuilder.Entity<Vermont>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Vermont");

            entity.Property(e => e.Cities).HasMaxLength(255);
        });

        modelBuilder.Entity<Virginium>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.Cities).HasMaxLength(255);
        });

        modelBuilder.Entity<Washington>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Washington");

            entity.Property(e => e.Cities).HasMaxLength(255);
        });

        modelBuilder.Entity<WestVirginium>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.Cities).HasMaxLength(255);
        });

        modelBuilder.Entity<Wisconsin>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Wisconsin");

            entity.Property(e => e.Cities).HasMaxLength(255);
        });

        modelBuilder.Entity<Wyoming>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Wyoming");

            entity.Property(e => e.Cities).HasMaxLength(255);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
