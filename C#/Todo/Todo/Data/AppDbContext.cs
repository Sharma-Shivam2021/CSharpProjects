using Microsoft.EntityFrameworkCore;
using Todo.Models;

namespace Todo.Data;

public class AppDbContext:DbContext
{
    public DbSet<Tasks> Tasks { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=tasks.db");
    }

}
