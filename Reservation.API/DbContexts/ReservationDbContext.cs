using Microsoft.EntityFrameworkCore;
using Reservation.API.Model;

namespace Reservation.API.DbContexts
{
	public class ReservationDbContext: DbContext
	{
		public DbSet<User> Users { get; set; }
		public DbSet<School> Schools { get; set; }

        public ReservationDbContext(DbContextOptions<ReservationDbContext> options):base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
	        modelBuilder.Entity<User>()
		        .HasData(
			        new User("Mehran Ahmadi")
			        {
				     Guid = new Guid("F340BF05-8262-424A-AD70-577D9C4B8A91"),
				     Role   = 0,
				     PhoneNumber = "09127959333",
				     EmailAddress = "Mehran@bazidid.com"
			        }
			        );
	        modelBuilder.Entity<School>()
		        .HasData(
			        new School()
			        {
				        Guid = new Guid("6725D8B7-6FE4-4D71-83A7-720F8BA41779"),
				        Name = "Allame Helli",
				        Address = "Heravi, Mohammadi, p12",
				        UserGuid = new Guid("F340BF05-8262-424A-AD70-577D9C4B8A91")
			        }
		        );
	        base.OnModelCreating(modelBuilder);
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlite();
        //    base.OnConfiguring(optionsBuilder);
        //}
    }
}

