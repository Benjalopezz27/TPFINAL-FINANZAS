using ProyectoFinal.Models;

public interface IExpenseRepository : IGenericRepository<Expense>
{
    // métodos específicos
    Task<IEnumerable<Expense>> GetByCategoryAsync(string category);
    Task<decimal> GetTotalByMonthAsync(int year, int month);
}