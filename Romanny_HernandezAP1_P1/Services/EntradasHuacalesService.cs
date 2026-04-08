using Microsoft.EntityFrameworkCore;
using Romanny_HernandezAP1_P1.DAL;
using Romanny_HernandezAP1_P1.Models;
using System.Linq.Expressions;

namespace Romanny_HernandezAP1_P1.Services;

public class EntradasHuacalesService(IDbContextFactory<Contexto> DbFactory)
{
    private async Task<bool> Insertar(EntradasHuacales entrada)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        contexto.EntradasHuacales.Add(entrada);
        return await contexto.SaveChangesAsync() > 0;
    }

    private async Task<bool> Modificar(EntradasHuacales entrada)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        contexto.EntradasHuacales.Update(entrada);
        return await contexto.SaveChangesAsync() > 0;
    }

    private async Task<bool> Existe(int idEntrada)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.EntradasHuacales.AnyAsync(a => a.IdEntrada == idEntrada);
    }

    private async Task<bool> ExisteNombre(string nombreCliente, int idEntrada)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.EntradasHuacales.AnyAsync(a => a.NombreCliente == nombreCliente && a.IdEntrada != idEntrada);
    }

    public async Task<EntradasHuacales?> Buscar(int idEntrada)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.EntradasHuacales
            .Include(e => e.Detalle)
            .AsNoTracking()
            .FirstOrDefaultAsync(a => a.IdEntrada == idEntrada);
    }

    public async Task<bool> Eliminar(int idEntrada)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.EntradasHuacales
            .Where(a => a.IdEntrada == idEntrada)
            .ExecuteDeleteAsync() > 0;
    }

    public async Task<bool> Guardar(EntradasHuacales entrada)
    {
        if (await ExisteNombre(entrada.NombreCliente, entrada.IdEntrada))
            throw new Exception("No puedes guardar dos clientes con el mismo nombre.");

        if (!await Existe(entrada.IdEntrada))
            return await Insertar(entrada);

        return await Modificar(entrada);
    }

    public async Task<List<EntradasHuacales>> Listar(Expression<Func<EntradasHuacales, bool>> criterio)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.EntradasHuacales
            .Include(e => e.Detalle)
            .Where(criterio)
            .AsNoTracking()
            .ToListAsync();
    }
}