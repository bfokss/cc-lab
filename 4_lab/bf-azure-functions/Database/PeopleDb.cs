using bf.Functions.Rest.Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace bf.Functions.Rest.Database
{
    public class PeopleDb: DbContext
    {
        public PeopleDb(DbContextOptions options) : base(options)
        {

        }

        public DbSet<PersonEntity> People { get; protected set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var personEntity = modelBuilder.Entity<PersonEntity>();
            personEntity.ToTable("People");
            personEntity.HasKey(pk => pk.PersonId);
            personEntity.Property(p => p.FirstName).HasMaxLength(250);
            personEntity.Property(p => p.LastName).HasMaxLength(250);
            personEntity.Property(p => p.PhoneNumber).HasMaxLength(12);
        }
    }
}