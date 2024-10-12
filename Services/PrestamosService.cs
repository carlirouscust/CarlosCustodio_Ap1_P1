using CarlosCustodio_Ap1_P1.DAL;
using CarlosCustodio_Ap1_P1.Models;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Contracts;


namespace CarlosCustodio_Ap1_P1.Services;

public class PrestamosService
{
    private readonly Contexto _context;
    public PrestamosService(Contexto contexto)
    {
        _context = contexto;
    }

    public async Task<bool> Existe(int prestamosId)
    {
        return await _context.Prestamos
        .AnyAsync(T => T.prestamoId == prestamosId);
    }

    public async Task<bool> Insertar(Prestamos prestamos)
    {
        _context.Prestamos.Add(prestamos);
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<bool> Modificar(Prestamos prestamos)
    {
        _context.Prestamos.Update(prestamos);
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<bool> Guardar(Prestamos prestamos)
    {
        if (await Existe(prestamos.prestamoId))
            return await Insertar(prestamos);
        else
            return await Modificar(prestamos);
    }

    public async Task<bool> Eliminar(int id)
    {
        var prestamos = await _context.Prestamos.
            Where(T => T.prestamoId == id).ExecuteDeleteAsync();
        return prestamos > 0;
    }

    public async Task<Prestamos?> Buscar(int id)
    {
        return await _context.Prestamos.
            AsNoTracking()        
            .FirstOrDefaultAsync(T => T.prestamoId == id);
    }

    public List<Prestamos> Listar(Expression<Func<Prestamos, bool>> criterio)
    {
        return _context.Prestamos.
            AsNoTracking()  
            .Include(P => P.deudores)
            .Where(criterio)
            .ToList();
    }

    public async Task<List<Deudores>> ObtenerDeudores()
    {
        return await _context.Deudores.ToListAsync();
    }
}



