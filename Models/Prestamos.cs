using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CarlosCustodio_Ap1_P1.Models;

public class Prestamos
{
    [Key]
    public int prestamoId { get; set; }

    [Required(ErrorMessage = "El campo es obligatorio")]
	public Deudores? deudores { get; set; }
	[ForeignKey("deudores")]
	public int? deudorId { get; set; }

    [Required(ErrorMessage = "El campo es obligatorio")]
    public string? concepto { get; set; }
    [Required(ErrorMessage = "El campo es obligatorio")]
    public decimal? monto { get; set; }

    public decimal? balance { get; set; }
}
