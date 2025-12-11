using Microsoft.AspNetCore.Mvc;

public class ExpensesController : Controller
{

    private readonly IExpenseService _service;


    public ExpensesController(IExpenseService service)
    {
        _service = service;
    }

    //Listar todos los gastos
    public async Task<IActionResult> Index()
    {
        var list = await _service.GetAllAsync();
        return View(list);
    }

    //Ver detalle de un gasto
    public async Task<IActionResult> Details(int id)
    {
        var item = await _service.GetByIdAsync(id);
        if (item == null) return NotFound();
        return View(item);
    }


    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]

    //Crear nuevo gasto
    public async Task<IActionResult> Create(CreateExpenseDto dto)
    {
        if (!ModelState.IsValid) return View(dto);
        await _service.CreateAsync(dto);
        return RedirectToAction(nameof(Index));
    }


    public async Task<IActionResult> Edit(int id)
    {
        var item = await _service.GetByIdAsync(id);
        if (item == null) return NotFound();
        var updateDto = new UpdateExpenseDto
        {
            Id = item.Id,
            Title = item.Title,
            Amount = item.Amount,
            Category = item.Category,
            Date = item.Date,
            Notes = item.Notes
        };
        return View(updateDto);
    }


    [HttpPost]
    [ValidateAntiForgeryToken]
    //Editar gasto existente
    public async Task<IActionResult> Edit(UpdateExpenseDto dto)
    {
        if (!ModelState.IsValid) return View(dto);
        await _service.UpdateAsync(dto);
        return RedirectToAction(nameof(Index));
    }


    public async Task<IActionResult> Delete(int id)
    {
        var item = await _service.GetByIdAsync(id);
        if (item == null) return NotFound();
        return View(item);
    }


    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    //Eliminar gasto
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        await _service.DeleteAsync(id);
        return RedirectToAction(nameof(Index));
    }
}