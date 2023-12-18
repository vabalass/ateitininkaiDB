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
            modelBuilder.Entity<BelongsToGroup>()
                .HasOne(b => b.Person)
                .WithMany(p => p.BelongsToGroups)
                .HasForeignKey(b => b.PersonId);

            modelBuilder.Entity<BelongsToGroup>()
                .HasOne(b => b.Group)
                .WithMany(u => u.BelongsToGroup)
                .HasForeignKey(b => b.GroupId);

            modelBuilder.Entity<ParticipatesInEvent>()
                .HasOne(p => p.Person)
                .WithMany(p => p.ParticipatesInEvents)
                .HasForeignKey(p => p.PersonId);

            modelBuilder.Entity<ParticipatesInEvent>()
                .HasOne(p => p.Event)
                .WithMany(e => e.ParticipatesInEvent)
                .HasForeignKey(p => p.EventId);

            modelBuilder.Entity<Pledge>()
                .HasOne(p => p.Person)
                .WithMany(person => person.Pledges)
                .HasForeignKey(p => p.PersonId);

            modelBuilder.Entity<Pledge>()
                .HasOne(b => b.Event)
                .WithMany(e => e.Pledges)
                .HasForeignKey(b => b.EventId);
        }
    }
}

