using Microsoft.EntityFrameworkCore;



public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }


    public DbSet<Expense> Expenses { get; set; } = null!;


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Expense>(eb =>
        {
            eb.Property(e => e.Amount).HasColumnType("decimal(18,2)");
        });
    }
}
