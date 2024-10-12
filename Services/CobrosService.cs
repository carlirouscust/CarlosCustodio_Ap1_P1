using CarlosCustodio_Ap1_P1.DAL;
using CarlosCustodio_Ap1_P1.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CarlosCustodio_Ap1_P1.Services;

public class CobrosService
{
    private readonly Contexto _contexto;
    public CobrosService(Contexto contexto)
    {
        _contexto = contexto;
    }

    public async Task<bool> Existe(int CobroId)
    {
        return await _contexto.Cobros.AnyAsync(c => c.cobroId == CobroId);
    }

    private async Task<bool> Insertar(Cobros cobro)
    {
        _contexto.Cobros.Add(cobro);
        return await _contexto.SaveChangesAsync() > 0;
    }

    private async Task<bool> Modificar(Cobros cobro)
    {
        var cobroExistente = await _contexto.Cobros
       .AsNoTracking()
       .FirstOrDefaultAsync(c => c.cobroId == cobro.cobroId);

        if (cobroExistente == null)
        {
            return false;
        }
        _contexto.Entry(cobro).State = EntityState.Modified;

        var modificado = await _contexto.SaveChangesAsync() > 0;

        return modificado;
    }

    public async Task<Cobros?> Buscar(int id)
    {
        return await _contexto.Cobros
        .AsNoTracking()
        .FirstOrDefaultAsync(c => c.cobroId == id);
    }

    public async Task<bool> Guardar(Cobros cobro)
    {
        if (!await Existe(cobro.cobroId))
            return await Insertar(cobro);
        else
            return await Modificar(cobro);
    }
    public async Task<bool> Eliminar(int id)
    {
        var EliminarCobro = await _contexto.Cobros
        .Where(c => c.cobroId == id)
        .ExecuteDeleteAsync();
        return EliminarCobro > 0;
    }

    public async Task<List<Cobros>> Listar(Expression<Func<Cobros, bool>> criterio)
    {
        return await _contexto.Cobros
        .AsNoTracking()
        .Where(criterio)
        .ToListAsync();
    }
    public async Task<List<Prestamos>> ObtenerPrestamos()
    {
        return await _contexto.Prestamos.ToListAsync();
    }
}
