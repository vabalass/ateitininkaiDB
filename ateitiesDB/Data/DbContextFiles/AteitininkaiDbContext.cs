<<<<<<< HEAD
﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
=======
﻿using Microsoft.EntityFrameworkCore;
>>>>>>> main

namespace ateitiesDB.Models;

public partial class AteitininkaiDbContext : DbContext
{
    public AteitininkaiDbContext()
    {
    }

    public AteitininkaiDbContext(DbContextOptions<AteitininkaiDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Attendsevent> Attendsevents { get; set; }

    public virtual DbSet<Belongstounit> Belongstounits { get; set; }

    public virtual DbSet<Event> Events { get; set; }

    public virtual DbSet<Member> Members { get; set; }

    public virtual DbSet<Membershipfee> Membershipfees { get; set; }

    public virtual DbSet<Person> People { get; set; }

    public virtual DbSet<PersonFull> PersonFulls { get; set; }

    public virtual DbSet<Pledge> Pledges { get; set; }

    public virtual DbSet<Unit> Units { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Attendsevent>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("attendsevent_pkey");

            entity.ToTable("attendsevent", "af");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.Eventid).HasColumnName("eventid");
            entity.Property(e => e.Personid).HasColumnName("personid");
            entity.Property(e => e.Position)
                .HasMaxLength(32)
                .HasDefaultValueSql("'dalyvis'::character varying")
                .HasColumnName("position");

            entity.HasOne(d => d.Event).WithMany(p => p.Attendsevents)
                .HasForeignKey(d => d.Eventid)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_event_attendsevent_eventid");

            entity.HasOne(d => d.Person).WithMany(p => p.Attendsevents)
                .HasForeignKey(d => d.Personid)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_person_attendsevent_personid");
        });

        modelBuilder.Entity<Belongstounit>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("belongstounit_pkey");

            entity.ToTable("belongstounit", "af");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.Enddate).HasColumnName("enddate");
            entity.Property(e => e.Personid).HasColumnName("personid");
            entity.Property(e => e.Position)
                .HasMaxLength(32)
                .HasDefaultValueSql("'narys'::character varying")
                .HasColumnName("position");
            entity.Property(e => e.Startdate).HasColumnName("startdate");
            entity.Property(e => e.Unitid).HasColumnName("unitid");

            entity.HasOne(d => d.Person).WithMany(p => p.Belongstounits)
                .HasForeignKey(d => d.Personid)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_person_belongstounit_personid");

            entity.HasOne(d => d.Unit).WithMany(p => p.Belongstounits)
                .HasForeignKey(d => d.Unitid)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_unit_belongstounit_unitid");
        });

        modelBuilder.Entity<Event>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("event_pkey");

            entity.ToTable("event", "af");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.Description)
                .HasMaxLength(500)
                .HasColumnName("description");
            entity.Property(e => e.Enddate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("enddate");
            entity.Property(e => e.Location)
                .HasMaxLength(50)
                .HasColumnName("location");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
            entity.Property(e => e.Organizer)
                .HasMaxLength(50)
                .HasColumnName("organizer");
            entity.Property(e => e.Startdate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("startdate");
        });

        modelBuilder.Entity<Member>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("members", "af");

            entity.Property(e => e.Address).HasColumnName("address");
            entity.Property(e => e.Age).HasColumnName("age");
            entity.Property(e => e.Birthdate).HasColumnName("birthdate");
            entity.Property(e => e.Country)
                .HasMaxLength(32)
                .HasColumnName("country");
            entity.Property(e => e.Description)
                .HasMaxLength(500)
                .HasColumnName("description");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsFixedLength()
                .HasColumnName("email");
            entity.Property(e => e.Firstname)
                .HasMaxLength(32)
                .HasColumnName("firstname");
            entity.Property(e => e.Gender)
                .HasMaxLength(4)
                .HasColumnName("gender");
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Lasteventdate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("lasteventdate");
            entity.Property(e => e.Lastname)
                .HasMaxLength(32)
                .HasColumnName("lastname");
            entity.Property(e => e.Membershipstatus)
                .HasColumnType("character varying")
                .HasColumnName("membershipstatus");
            entity.Property(e => e.Phone)
                .HasMaxLength(15)
                .HasColumnName("phone");
            entity.Property(e => e.Registrationdate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("registrationdate");
        });

        modelBuilder.Entity<Membershipfee>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("membershipfee", "af");

            entity.HasIndex(e => e.Paymentdate, "idx_membershipfee_paymentdate");

            entity.Property(e => e.Amount)
                .HasPrecision(10, 2)
                .HasColumnName("amount");
            entity.Property(e => e.Paymentdate)
                .HasDefaultValueSql("CURRENT_DATE")
                .HasColumnName("paymentdate");
            entity.Property(e => e.Paymentid)
                .ValueGeneratedOnAdd()
                .UseIdentityAlwaysColumn()
                .HasColumnName("paymentid");
            entity.Property(e => e.Personid).HasColumnName("personid");

            entity.HasOne(d => d.Person).WithMany()
                .HasForeignKey(d => d.Personid)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_person_membershipfee_personid");
        });

        modelBuilder.Entity<Person>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("person_pkey");

            entity.ToTable("person", "af");

            entity.HasIndex(e => new { e.Firstname, e.Lastname }, "idx_person_firstname_lastname");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasIdentityOptions(10000L, null, null, null, null, null)
                .HasColumnName("id");
            entity.Property(e => e.Apartment)
                .HasMaxLength(5)
                .HasColumnName("apartment");
            entity.Property(e => e.Birthdate).HasColumnName("birthdate");
            entity.Property(e => e.City)
                .HasMaxLength(20)
                .HasColumnName("city");
            entity.Property(e => e.Country)
                .HasMaxLength(32)
                .HasColumnName("country");
            entity.Property(e => e.Description)
                .HasMaxLength(500)
                .HasColumnName("description");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsFixedLength()
                .HasColumnName("email");
            entity.Property(e => e.Firstname)
                .HasMaxLength(32)
                .HasColumnName("firstname");
            entity.Property(e => e.Gender)
                .HasMaxLength(4)
                .HasColumnName("gender");
            entity.Property(e => e.House)
                .HasMaxLength(5)
                .HasColumnName("house");
            entity.Property(e => e.Lastname)
                .HasMaxLength(32)
                .HasColumnName("lastname");
            entity.Property(e => e.Phone)
                .HasMaxLength(15)
                .HasColumnName("phone");
            entity.Property(e => e.Registrationdate)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("registrationdate");
            entity.Property(e => e.Street)
                .HasMaxLength(30)
                .HasColumnName("street");
        });

        modelBuilder.Entity<PersonFull>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("person_full", "af");

            entity.Property(e => e.Address).HasColumnName("address");
            entity.Property(e => e.Age).HasColumnName("age");
            entity.Property(e => e.Birthdate).HasColumnName("birthdate");
            entity.Property(e => e.Country)
                .HasMaxLength(32)
                .HasColumnName("country");
            entity.Property(e => e.Description)
                .HasMaxLength(500)
                .HasColumnName("description");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsFixedLength()
                .HasColumnName("email");
            entity.Property(e => e.Firstname)
                .HasMaxLength(32)
                .HasColumnName("firstname");
            entity.Property(e => e.Gender)
                .HasMaxLength(4)
                .HasColumnName("gender");
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Lasteventdate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("lasteventdate");
            entity.Property(e => e.Lastname)
                .HasMaxLength(32)
                .HasColumnName("lastname");
            entity.Property(e => e.Membershipstatus)
                .HasColumnType("character varying")
                .HasColumnName("membershipstatus");
            entity.Property(e => e.Phone)
                .HasMaxLength(15)
                .HasColumnName("phone");
            entity.Property(e => e.Registrationdate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("registrationdate");
        });

        modelBuilder.Entity<Pledge>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pledge_pkey");

            entity.ToTable("pledge", "af");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.Association)
                .HasMaxLength(4)
                .HasColumnName("association");
            entity.Property(e => e.Date)
                .HasDefaultValueSql("CURRENT_DATE")
                .HasColumnName("date");
            entity.Property(e => e.Eventid).HasColumnName("eventid");
            entity.Property(e => e.Personid).HasColumnName("personid");

            entity.HasOne(d => d.Event).WithMany(p => p.Pledges)
                .HasForeignKey(d => d.Eventid)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_event_pledge_eventid");

            entity.HasOne(d => d.Person).WithMany(p => p.Pledges)
                .HasForeignKey(d => d.Personid)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_person_pledge_personid");
        });

        modelBuilder.Entity<Unit>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("unit_pkey");

            entity.ToTable("unit", "af");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.Address)
                .HasMaxLength(50)
                .HasColumnName("address");
            entity.Property(e => e.Description)
                .HasMaxLength(500)
                .HasColumnName("description");
            entity.Property(e => e.Establishmentdate)
                .HasDefaultValueSql("CURRENT_DATE")
                .HasColumnName("establishmentdate");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
            entity.Property(e => e.Type)
                .HasMaxLength(32)
                .HasDefaultValueSql("'vienetas'::character varying")
                .HasColumnName("type");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
