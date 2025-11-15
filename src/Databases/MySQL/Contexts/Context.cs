using Lemure.Databases.MySQL.Models;
using Microsoft.EntityFrameworkCore;

namespace Lemure.Databases.MySQL.Contexts;

	public class Context : DbContext
	{
		public DbSet<Order> Order { get; set; }
		public DbSet<OrderItem> OrderItem { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			if (!optionsBuilder.IsConfigured)
			{
				var connectionString = "server=localhost;port=3306;uid=jurify-test;pwd=123456;database=jurify";

				optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
			}
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<OrderItem>()
				.HasOne<Order>()
				.WithMany()
				.HasForeignKey(foreignKey => foreignKey.OrderId);
		}
	}
