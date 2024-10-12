using CarlosCustodio_Ap1_P1.DAL;
using CarlosCustodio_Ap1_P1.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CarlosCustodio_Ap1_P1.Services;

public class CobrosDetallesService
{
    private readonly Contexto _contexto;
    public CobrosDetallesService(Contexto contexto)
    {
        _contexto = contexto;
    }

    public async Task<bool> Existe(int DetalleId)
    {
        return await _contexto.CobrosDetalles.AnyAsync(c => c.detalleId == DetalleId);
    }

    private async Task<bool> Insertar(CobrosDetalles cobrosDetalles)
    {
        _contexto.CobrosDetalles.Add(cobrosDetalles);
        return await _contexto.SaveChangesAsync() > 0;
    }

    private async Task<bool> Modificar(CobrosDetalles cobrosDetalles)
    {
        var detalleExistente = await _contexto.CobrosDetalles
       .AsNoTracking()
       .FirstOrDefaultAsync(c => c.detalleId == cobrosDetalles.detalleId);

        if (detalleExistente == null)
        {
            return false;
        }
        _contexto.Entry(cobrosDetalles).State = EntityState.Modified;

        var modificado = await _contexto.SaveChangesAsync() > 0;

        return modificado;
    }

    public async Task<CobrosDetalles?> Buscar(int id)
    {
        return await _contexto.CobrosDetalles
        .AsNoTracking()
        .FirstOrDefaultAsync(c => c.detalleId == id);
    }

    public async Task<bool> Guardar(CobrosDetalles cobrosDetalles)
    {
        if (!await Existe(cobrosDetalles.detalleId))
            return await Insertar(cobrosDetalles);
        else
            return await Modificar(cobrosDetalles);
    }
    public async Task<bool> Eliminar(int id)
    {
        var eliminarDetalle = await _contexto.CobrosDetalles
        .Where(c => c.detalleId == id)
        .ExecuteDeleteAsync();
        return eliminarDetalle > 0;
    }

    public async Task<List<CobrosDetalles>> Listar(Expression<Func<CobrosDetalles, bool>> criterio)
    {
        return await _contexto.CobrosDetalles
        .AsNoTracking()
        .Include(c => c.prestamos)
        .Include(c => c.cobro)
        .Where(criterio)
        .ToListAsync();
    }
}
