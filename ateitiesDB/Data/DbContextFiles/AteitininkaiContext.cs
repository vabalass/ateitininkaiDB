using System;
using System.Collections.Generic;
using ateitiesDB.ModelsLT;
using Microsoft.EntityFrameworkCore;

namespace ateitiesDB.Data.DbContextFiles;

public partial class AteitininkaiContext : DbContext
{
    public AteitininkaiContext()
    {
    }

    public AteitininkaiContext(DbContextOptions<AteitininkaiContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Asmuo> Asmuos { get; set; }

    public virtual DbSet<AsmuoPilna> AsmuoPilnas { get; set; }

    public virtual DbSet<DalyvaujaRenginyje> DalyvaujaRenginyjes { get; set; }

    public virtual DbSet<Izodi> Izodis { get; set; }

    public virtual DbSet<MatviewAfValdyba> MatviewAfValdybas { get; set; }

    public virtual DbSet<Nariai> Nariais { get; set; }

    public virtual DbSet<NarioMokesti> NarioMokestis { get; set; }

    public virtual DbSet<PriklausoVienetui> PriklausoVienetuis { get; set; }

    public virtual DbSet<Renginy> Renginys { get; set; }

    public virtual DbSet<Vieneta> Vienetas { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=localhost;Database=ateitininkai;Username=postgres;Password=zalnora");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Asmuo>(entity =>
        {
            entity.HasKey(e => e.Nr).HasName("asmuo_pkey");

            entity.ToTable("asmuo", "af");

            entity.HasIndex(e => new { e.Vardas, e.Pavarde }, "idx_asmuo_vardas_pavarde");

            entity.Property(e => e.Nr)
                .UseIdentityAlwaysColumn()
                .HasIdentityOptions(10000L, null, null, null, null, null)
                .HasColumnName("nr");
            entity.Property(e => e.Aprasymas)
                .HasMaxLength(500)
                .HasColumnName("aprasymas");
            entity.Property(e => e.Butas)
                .HasMaxLength(5)
                .HasColumnName("butas");
            entity.Property(e => e.ElPastas)
                .HasMaxLength(50)
                .IsFixedLength()
                .HasColumnName("el_pastas");
            entity.Property(e => e.Gatve)
                .HasMaxLength(30)
                .HasColumnName("gatve");
            entity.Property(e => e.GimData).HasColumnName("gim_data");
            entity.Property(e => e.Krastas)
                .HasMaxLength(32)
                .HasColumnName("krastas");
            entity.Property(e => e.Lytis)
                .HasMaxLength(4)
                .HasColumnName("lytis");
            entity.Property(e => e.Miestas)
                .HasMaxLength(20)
                .HasColumnName("miestas");
            entity.Property(e => e.Namas)
                .HasMaxLength(5)
                .HasColumnName("namas");
            entity.Property(e => e.Pavarde)
                .HasMaxLength(32)
                .HasColumnName("pavarde");
            entity.Property(e => e.RegistravimoData)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("registravimo_data");
            entity.Property(e => e.TelNr)
                .HasMaxLength(15)
                .HasColumnName("tel_nr");
            entity.Property(e => e.Vardas)
                .HasMaxLength(32)
                .HasColumnName("vardas");
        });

        modelBuilder.Entity<AsmuoPilna>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("asmuo_pilnas", "af");

            entity.Property(e => e.Adresas).HasColumnName("adresas");
            entity.Property(e => e.Amzius).HasColumnName("amzius");
            entity.Property(e => e.Aprasymas)
                .HasMaxLength(500)
                .HasColumnName("aprasymas");
            entity.Property(e => e.ElPastas)
                .HasMaxLength(50)
                .IsFixedLength()
                .HasColumnName("el_pastas");
            entity.Property(e => e.GimData).HasColumnName("gim_data");
            entity.Property(e => e.Krastas)
                .HasMaxLength(32)
                .HasColumnName("krastas");
            entity.Property(e => e.Lytis)
                .HasMaxLength(4)
                .HasColumnName("lytis");
            entity.Property(e => e.NarystesStatusas)
                .HasColumnType("character varying")
                .HasColumnName("narystes_statusas");
            entity.Property(e => e.Nr).HasColumnName("nr");
            entity.Property(e => e.PaskutinioRenginioData)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("paskutinio_renginio_data");
            entity.Property(e => e.Pavarde)
                .HasMaxLength(32)
                .HasColumnName("pavarde");
            entity.Property(e => e.RegistravimoData)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("registravimo_data");
            entity.Property(e => e.TelNr)
                .HasMaxLength(15)
                .HasColumnName("tel_nr");
            entity.Property(e => e.Vardas)
                .HasMaxLength(32)
                .HasColumnName("vardas");
        });

        modelBuilder.Entity<DalyvaujaRenginyje>(entity =>
        {
            entity.HasKey(e => e.Nr).HasName("dalyvauja_renginyje_pkey");

            entity.ToTable("dalyvauja_renginyje", "af");

            entity.Property(e => e.Nr)
                .UseIdentityAlwaysColumn()
                .HasColumnName("nr");
            entity.Property(e => e.AsmensNr).HasColumnName("asmens_nr");
            entity.Property(e => e.Pareigybe)
                .HasMaxLength(32)
                .HasDefaultValueSql("'dalyvis'::character varying")
                .HasColumnName("pareigybe");
            entity.Property(e => e.RenginioNr).HasColumnName("renginio_nr");

            entity.HasOne(d => d.AsmensNrNavigation).WithMany(p => p.DalyvaujaRenginyjes)
                .HasForeignKey(d => d.AsmensNr)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("iasmeni");

            entity.HasOne(d => d.RenginioNrNavigation).WithMany(p => p.DalyvaujaRenginyjes)
                .HasForeignKey(d => d.RenginioNr)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("ivieneta");
        });

        modelBuilder.Entity<Izodi>(entity =>
        {
            entity.HasKey(e => e.Nr).HasName("izodis_pkey");

            entity.ToTable("izodis", "af");

            entity.Property(e => e.Nr)
                .UseIdentityAlwaysColumn()
                .HasColumnName("nr");
            entity.Property(e => e.AsmensNr).HasColumnName("asmens_nr");
            entity.Property(e => e.IzodzioData)
                .HasDefaultValueSql("CURRENT_DATE")
                .HasColumnName("izodzio_data");
            entity.Property(e => e.RenginioNr).HasColumnName("renginio_nr");
            entity.Property(e => e.Sajunga)
                .HasMaxLength(4)
                .HasColumnName("sajunga");

            entity.HasOne(d => d.AsmensNrNavigation).WithMany(p => p.Izodis)
                .HasForeignKey(d => d.AsmensNr)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("iasmeni");

            entity.HasOne(d => d.RenginioNrNavigation).WithMany(p => p.Izodis)
                .HasForeignKey(d => d.RenginioNr)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("irengini");
        });

        modelBuilder.Entity<MatviewAfValdyba>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("matview_af_valdyba");

            entity.Property(e => e.ElPastas)
                .HasMaxLength(50)
                .IsFixedLength()
                .HasColumnName("el_pastas");
            entity.Property(e => e.Nr).HasColumnName("nr");
            entity.Property(e => e.Pareigybe)
                .HasMaxLength(32)
                .HasColumnName("pareigybe");
            entity.Property(e => e.Pavarde)
                .HasMaxLength(32)
                .HasColumnName("pavarde");
            entity.Property(e => e.TelNr)
                .HasMaxLength(15)
                .HasColumnName("tel_nr");
            entity.Property(e => e.Vardas)
                .HasMaxLength(32)
                .HasColumnName("vardas");
            entity.Property(e => e.VienetoPavadinimas)
                .HasMaxLength(50)
                .HasColumnName("vieneto_pavadinimas");
        });

        modelBuilder.Entity<Nariai>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("nariai", "af");

            entity.Property(e => e.Adresas).HasColumnName("adresas");
            entity.Property(e => e.Amzius).HasColumnName("amzius");
            entity.Property(e => e.Aprasymas)
                .HasMaxLength(500)
                .HasColumnName("aprasymas");
            entity.Property(e => e.ElPastas)
                .HasMaxLength(50)
                .IsFixedLength()
                .HasColumnName("el_pastas");
            entity.Property(e => e.GimData).HasColumnName("gim_data");
            entity.Property(e => e.Krastas)
                .HasMaxLength(32)
                .HasColumnName("krastas");
            entity.Property(e => e.Lytis)
                .HasMaxLength(4)
                .HasColumnName("lytis");
            entity.Property(e => e.NarystesStatusas)
                .HasColumnType("character varying")
                .HasColumnName("narystes_statusas");
            entity.Property(e => e.Nr).HasColumnName("nr");
            entity.Property(e => e.PaskutinioRenginioData)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("paskutinio_renginio_data");
            entity.Property(e => e.Pavarde)
                .HasMaxLength(32)
                .HasColumnName("pavarde");
            entity.Property(e => e.RegistravimoData)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("registravimo_data");
            entity.Property(e => e.TelNr)
                .HasMaxLength(15)
                .HasColumnName("tel_nr");
            entity.Property(e => e.Vardas)
                .HasMaxLength(32)
                .HasColumnName("vardas");
        });

        modelBuilder.Entity<NarioMokesti>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("nario_mokestis", "af");

            entity.HasIndex(e => e.ApmokejimoData, "idx_nario_mokestis_data");

            entity.Property(e => e.ApmokejimoData)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("apmokejimo_data");
            entity.Property(e => e.ApmokejimoNr)
                .ValueGeneratedOnAdd()
                .UseIdentityAlwaysColumn()
                .HasColumnName("apmokejimo_nr");
            entity.Property(e => e.AsmensNr).HasColumnName("asmens_nr");
            entity.Property(e => e.Suma)
                .HasPrecision(10, 2)
                .HasColumnName("suma");

            entity.HasOne(d => d.AsmensNrNavigation).WithMany()
                .HasForeignKey(d => d.AsmensNr)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("iasmeni");
        });

        modelBuilder.Entity<PriklausoVienetui>(entity =>
        {
            entity.HasKey(e => e.Nr).HasName("priklauso_vienetui_pkey");

            entity.ToTable("priklauso_vienetui", "af");

            entity.Property(e => e.Nr)
                .UseIdentityAlwaysColumn()
                .HasColumnName("nr");
            entity.Property(e => e.AsmensNr).HasColumnName("asmens_nr");
            entity.Property(e => e.DataIki).HasColumnName("data_iki");
            entity.Property(e => e.DataNuo).HasColumnName("data_nuo");
            entity.Property(e => e.Pareigybe)
                .HasMaxLength(32)
                .HasDefaultValueSql("'narys'::character varying")
                .HasColumnName("pareigybe");
            entity.Property(e => e.VienetoNr).HasColumnName("vieneto_nr");

            entity.HasOne(d => d.AsmensNrNavigation).WithMany(p => p.PriklausoVienetuis)
                .HasForeignKey(d => d.AsmensNr)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("iasmeni");

            entity.HasOne(d => d.VienetoNrNavigation).WithMany(p => p.PriklausoVienetuis)
                .HasForeignKey(d => d.VienetoNr)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("ivieneta");
        });

        modelBuilder.Entity<Renginy>(entity =>
        {
            entity.HasKey(e => e.Nr).HasName("renginys_pkey");

            entity.ToTable("renginys", "af");

            entity.Property(e => e.Nr)
                .UseIdentityAlwaysColumn()
                .HasColumnName("nr");
            entity.Property(e => e.Aprasymas)
                .HasMaxLength(500)
                .HasColumnName("aprasymas");
            entity.Property(e => e.DataIki)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("data_iki");
            entity.Property(e => e.DataNuo)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("data_nuo");
            entity.Property(e => e.Organizatorius)
                .HasMaxLength(50)
                .HasColumnName("organizatorius");
            entity.Property(e => e.Pavadinimas)
                .HasMaxLength(50)
                .HasColumnName("pavadinimas");
            entity.Property(e => e.Vieta)
                .HasMaxLength(50)
                .HasColumnName("vieta");
        });

        modelBuilder.Entity<Vieneta>(entity =>
        {
            entity.HasKey(e => e.Nr).HasName("vienetas_pkey");

            entity.ToTable("vienetas", "af");

            entity.Property(e => e.Nr)
                .UseIdentityAlwaysColumn()
                .HasColumnName("nr");
            entity.Property(e => e.Adresas)
                .HasMaxLength(50)
                .HasColumnName("adresas");
            entity.Property(e => e.Aprasymas)
                .HasMaxLength(500)
                .HasColumnName("aprasymas");
            entity.Property(e => e.IkurimoData)
                .HasDefaultValueSql("CURRENT_DATE")
                .HasColumnName("ikurimo_data");
            entity.Property(e => e.Pavadinimas)
                .HasMaxLength(50)
                .HasColumnName("pavadinimas");
            entity.Property(e => e.Tipas)
                .HasMaxLength(32)
                .HasDefaultValueSql("'vienetas'::character varying")
                .HasColumnName("tipas");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
