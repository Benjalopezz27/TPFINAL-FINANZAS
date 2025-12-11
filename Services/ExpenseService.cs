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

    //Crear nuevo gasto
    public async Task CreateAsync(CreateExpenseDto dto)
    {
        var entity = _mapper.Map<Expense>(dto);
        await _repo.AddAsync(entity);
    }

    //Eliminar gasto
    public async Task DeleteAsync(int id)
    {
        var entity = await _repo.GetByIdAsync(id);
        if (entity is null) return;
        await _repo.DeleteAsync(entity);
    }

    //Obtener todos los gastos
    public async Task<IEnumerable<ExpenseDto>> GetAllAsync()
    {
        var all = await _repo.GetAllAsync();
        return _mapper.Map<IEnumerable<ExpenseDto>>(all);
    }

    //Obtener gasto por Id
    public async Task<ExpenseDto?> GetByIdAsync(int id)
    {
        var e = await _repo.GetByIdAsync(id);
        return e is null ? null : _mapper.Map<ExpenseDto>(e);
    }

    //Editar gasto existente
    public async Task UpdateAsync(UpdateExpenseDto dto)
    {
        var entity = _mapper.Map<Expense>(dto);
        await _repo.UpdateAsync(entity);
    }

}