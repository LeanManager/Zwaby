using System;
using Microsoft.EntityFrameworkCore;

namespace ZwabyWebServices.Models
{
	// The database context is the main class that coordinates Entity Framework functionality for a given data model.

	public class StripeContext : DbContext
	{
		public StripeContext(DbContextOptions<StripeContext> options) : base(options)
		{
		}

		public DbSet<StripeItem> StripeCharges { get; set; }
	}
}
