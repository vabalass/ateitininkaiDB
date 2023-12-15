using ateitiesDB.Models;
using Microsoft.EntityFrameworkCore;

namespace ateitiesDB.Data.DbContextFiles
{
    public class AteitisDbContext : DbContext
    {
        public AteitisDbContext(DbContextOptions<AteitisDbContext> options) : base(options)
        {
        }

        public DbSet<Person> People { get; set; }
        public DbSet<MembershipFee> MembershipFees { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<BelongsToGroup> BelongsToGroups { get; set; }
        public DbSet<ParticipatesInEvent> ParticipatesInEvents { get; set; }
        public DbSet<Pledge> Pledges { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure your entity relationships and constraints here
            modelBuilder.Entity<BelongsToUnit>()
                .HasOne(b => b.Person)
                .WithMany(p => p.BelongsToUnits)
                .HasForeignKey(b => b.PersonId);

            modelBuilder.Entity<BelongsToUnit>()
                .HasOne(b => b.Unit)
                .WithMany(u => u.BelongsToUnits)
                .HasForeignKey(b => b.UnitId);

            modelBuilder.Entity<ParticipatesInEvent>()
                .HasOne(p => p.Person)
                .WithMany(p => p.ParticipatesInEvents)
                .HasForeignKey(p => p.PersonId);

            modelBuilder.Entity<ParticipatesInEvent>()
                .HasOne(p => p.Event)
                .WithMany(e => e.ParticipatesInEvents)
                .HasForeignKey(p => p.EventId);

            modelBuilder.Entity<Badge>()
                .HasOne(b => b.Person)
                .WithMany(p => p.Badges)
                .HasForeignKey(b => b.PersonId);

            modelBuilder.Entity<Badge>()
                .HasOne(b => b.Event)
                .WithMany(e => e.Badges)
                .HasForeignKey(b => b.EventId);
        }
    }
}

