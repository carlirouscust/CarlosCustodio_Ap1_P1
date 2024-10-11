using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CarlosCustodio_Ap1_P1.Models;

public class CobrosDetalles
{
	[Key]
	public int detalleId { get; set; }
	public decimal valorCobrado { get; set; }

	public Cobros? cobro { get; set; }

	[ForeignKey("cobro")]
	public int cobroId { get; set; }

	public Prestamos? prestamos { get; set; }

	[ForeignKey("prestamos")]
	public int prestamoId { get; set; }
}
