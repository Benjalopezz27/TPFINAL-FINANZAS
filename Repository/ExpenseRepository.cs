using Microsoft.EntityFrameworkCore;
using ProyectoFinal.Models;

public class ExpenseRepository : GenericRepository<Expense>, IExpenseRepository
{
    public ExpenseRepository(ApplicationDbContext context) : base(context)
    {
    }


    public async Task<IEnumerable<Expense>> GetByCategoryAsync(string category)
    {
        return await _dbSet.Where(e => e.Category == category).ToListAsync();
    }


    public async Task<decimal> GetTotalByMonthAsync(int year, int month)
    {
        return await _dbSet
        .Where(e => e.Date.Year == year && e.Date.Month == month)
        .SumAsync(e => e.Amount);
    }
}