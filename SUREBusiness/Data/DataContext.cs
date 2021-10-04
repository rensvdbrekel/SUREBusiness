using Microsoft.EntityFrameworkCore;
using SUREBusiness.Entities;

namespace SUREBusiness.Data
{
	public class DataContext : DbContext
	{
		public DataContext(DbContextOptions options) : base(options)
		{
			
		}

		public DbSet<User> Users { get; set; }
		public DbSet<Note> Notes { get; set; }


	}
}
