using ateitiesDB.Models;
using Microsoft.EntityFrameworkCore;

namespace ateitiesDB.Data.DbContextFiles
{
    public class AteitisDbContext : DbContext
    {
        public AteitisDbContext(DbContextOptions<AteitisDbContext> options) : base(options)
        {
        }

        public DbSet<PersonHM> People { get; set; }
        public DbSet<MembershipFeeHM> MembershipFees { get; set; }
        public DbSet<GroupHM> Groups { get; set; }
        public DbSet<EventHM> Events { get; set; }
        public DbSet<BelongsToGroupHM> BelongsToGroups { get; set; }
        public DbSet<ParticipatesInEventHM> ParticipatesInEvents { get; set; }
        public DbSet<PledgeHM> Pledges { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BelongsToGroupHM>()
                .HasOne(b => b.Person)
                .WithMany(p => p.BelongsToGroups)
                .HasForeignKey(b => b.PersonId);

            modelBuilder.Entity<BelongsToGroupHM>()
                .HasOne(b => b.Group)
                .WithMany(u => u.BelongsToGroup)
                .HasForeignKey(b => b.GroupId);

            modelBuilder.Entity<ParticipatesInEventHM>()
                .HasOne(p => p.Person)
                .WithMany(p => p.ParticipatesInEvents)
                .HasForeignKey(p => p.PersonId);

            modelBuilder.Entity<ParticipatesInEventHM>()
                .HasOne(p => p.Event)
                .WithMany(e => e.ParticipatesInEvent)
                .HasForeignKey(p => p.EventId);

            modelBuilder.Entity<PledgeHM>()
                .HasOne(p => p.Person)
                .WithMany(person => person.Pledges)
                .HasForeignKey(p => p.PersonId);

            modelBuilder.Entity<PledgeHM>()
                .HasOne(b => b.Event)
                .WithMany(e => e.Pledges)
                .HasForeignKey(b => b.EventId);
        }
    }
}

