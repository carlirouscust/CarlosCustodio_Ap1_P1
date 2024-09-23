using System.ComponentModel.DataAnnotations;

namespace CarlosCustodio_Ap1_P1.Models;

public class Registro
{
    [Key]
    public int registroId { get; set; }
    //[Required(ErrorMessage = "El campo es obligatorio")]
}
