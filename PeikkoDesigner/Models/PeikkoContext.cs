
using Microsoft.EntityFrameworkCore;

namespace PeikkoDesigner.Models
{
	public class PeikkoContext : DbContext
	{
		public PeikkoContext(DbContextOptions<PeikkoContext> options) : base(options) { }

		public DbSet<User> Users { get; set; }
		public DbSet<Role> Roles { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<User>()
				.HasMany(u => u.Roles)
				.WithMany(r => r.Users)
				.UsingEntity(j => j.ToTable("user_roles"));
		}
	}

}
