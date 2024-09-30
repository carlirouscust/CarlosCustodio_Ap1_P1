using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CarlosCustodio_Ap1_P1.Models;

public class Prestamos
{
    [Key]
    public int prestamosId { get; set; }

    [Required(ErrorMessage = "El campo es obligatorio")]
    public string? deudor { get; set; }
    [Required(ErrorMessage = "El campo es obligatorio")]
    public string? concepto { get; set; }
    [Required(ErrorMessage = "El campo es obligatorio")]
    public int? monto { get; set; }
}
