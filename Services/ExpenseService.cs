using AutoMapper;

public class ExpenseService : IExpenseService

{
    private readonly IExpenseRepository _repo;
    private readonly IMapper _mapper;

    public ExpenseService(IExpenseRepository repo, IMapper mapper)
    {
        _repo = repo;
        _mapper = mapper;
    }


    public async Task CreateAsync(CreateExpenseDto dto)
    {
        var entity = _mapper.Map<Expense>(dto);
        await _repo.AddAsync(entity);
    }


    public async Task DeleteAsync(int id)
    {
        var entity = await _repo.GetByIdAsync(id);
        if (entity is null) return;
        await _repo.DeleteAsync(entity);
    }


    public async Task<IEnumerable<ExpenseDto>> GetAllAsync()
    {
        var all = await _repo.GetAllAsync();
        return _mapper.Map<IEnumerable<ExpenseDto>>(all);
    }


    public async Task<ExpenseDto?> GetByIdAsync(int id)
    {
        var e = await _repo.GetByIdAsync(id);
        return e is null ? null : _mapper.Map<ExpenseDto>(e);
    }


    public async Task UpdateAsync(UpdateExpenseDto dto)
    {
        var entity = _mapper.Map<Expense>(dto);
        await _repo.UpdateAsync(entity);
    }


    public async Task<decimal> GetTotalByMonthAsync(int year, int month)
    {
        return await _repo.GetTotalByMonthAsync(year, month);
    }
}