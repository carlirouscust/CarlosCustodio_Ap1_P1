using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarlosCustodio_Ap1_P1.Models;


public class Deudores
{
    [Key]
    public int deudorId { get; set; }

    [Required(ErrorMessage = "El campo es obligatorio")]
    public string? Nombres { get; set; }

    public ICollection<Prestamos> Prestamos { get; set; }
}
