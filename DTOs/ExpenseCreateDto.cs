using System.ComponentModel.DataAnnotations;
public class CreateExpenseDto
{
    [Required, StringLength(100)]
    public string Title { get; set; } = string.Empty;


    [Required]
    public decimal Amount { get; set; }


    [Required, StringLength(50)]
    public string Category { get; set; } = string.Empty;


    [Required]
    public DateTime Date { get; set; }


    [StringLength(500)]
    public string? Notes { get; set; }
}