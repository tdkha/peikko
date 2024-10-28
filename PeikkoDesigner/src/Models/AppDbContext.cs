using Microsoft.EntityFrameworkCore;

namespace PeikkoDesigner.Models
{
	public class AppDbContext : DbContext
	{
		public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

		public DbSet<User> Users { get; set; }
		public DbSet<Role> Roles { get; set; }

		 protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
            modelBuilder.Entity<User>().ToTable("users");

            modelBuilder.Entity<Role>().ToTable("roles");

			modelBuilder.Entity<User>()
				.HasMany(u => u.Roles)
				.WithMany(r => r.Users)
				.UsingEntity<Dictionary<string, object>>(
					"user_roles",
					j => j
						.HasOne<Role>()
						.WithMany()
						.HasForeignKey("role_id")
						.HasConstraintName("FK_UserRoles_RoleId")
						.OnDelete(DeleteBehavior.Cascade),
					j => j
						.HasOne<User>()
						.WithMany()
						.HasForeignKey("user_id")
						.HasConstraintName("FK_UserRoles_UserId")
						.OnDelete(DeleteBehavior.Cascade))
				.ToTable("user_roles")
				.HasKey("user_id", "role_id");
		}
	}
}
