using System;
using Microsoft.EntityFrameworkCore;

namespace ZwabyWebServices.Models
{
	// The database context is the main class that coordinates Entity Framework functionality for a given data model.

	public class TodoContext : DbContext
    {
        public TodoContext(DbContextOptions<TodoContext> options) : base(options)
        {
        }

        public DbSet<TodoItem> TodoItems { get; set; }
    }
}
