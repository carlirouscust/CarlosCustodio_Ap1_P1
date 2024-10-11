using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarlosCustodio_Ap1_P1.Models;

public class Cobros
{
	[Key]
	public int cobroId { get; set; }
	public DateTime fecha { get; set; }
	public decimal monto { get; set; }
	
	public  Deudores?  deudores { get; set; }

	[ForeignKey("deudores")]
	public int deudorId { get; set; }

	public ICollection<CobrosDetalles>? cobroDetalles { get; set; }


}
