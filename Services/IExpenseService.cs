public interface IExpenseService
{
    Task<IEnumerable<ExpenseDto>> GetAllAsync();
    Task<ExpenseDto?> GetByIdAsync(int id);
    Task CreateAsync(CreateExpenseDto dto);
    Task UpdateAsync(UpdateExpenseDto dto);
    Task DeleteAsync(int id);
    Task<decimal> GetTotalByMonthAsync(int year, int month);
}