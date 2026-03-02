using Microsoft.EntityFrameworkCore;
using Romanny_HernandezAP1_P1.DAL;
using Romanny_HernandezAP1_P1.Models;
using System.Linq.Expressions;

namespace Romanny_HernandezAP1_P1.Services;

public class TipoHuacalesService(IDbContextFactory<Contexto> DbFactory)
{
    private async Task<bool> Existe(int tipoId)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.TiposHuacales.AnyAsync(t => t.TipoId == tipoId);
    }

    private async Task<bool> Insertar(TipoHuacales tipoHuacal)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        contexto.TiposHuacales.Add(tipoHuacal);
        return await contexto.SaveChangesAsync() > 0;
    }

    private async Task<bool> Modificar(TipoHuacales tipoHuacal)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        contexto.TiposHuacales.Update(tipoHuacal);
        return await contexto.SaveChangesAsync() > 0;
    }

    public async Task<bool> Guardar(TipoHuacales tipoHuacal)
    {
        if (!await Existe(tipoHuacal.TipoId))
            return await Insertar(tipoHuacal);

        return await Modificar(tipoHuacal);
    }

    public async Task<TipoHuacales?> Buscar(int tipoId)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.TiposHuacales
            .AsNoTracking()
            .FirstOrDefaultAsync(t => t.TipoId == tipoId);
    }

    public async Task<bool> Eliminar(int tipoId)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.TiposHuacales
            .Where(t => t.TipoId == tipoId)
            .ExecuteDeleteAsync() > 0;
    }

    public async Task<List<TipoHuacales>> Listar(Expression<Func<TipoHuacales, bool>> criterio)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.TiposHuacales
            .Where(criterio)
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<List<TipoHuacales>> ListarTodos()
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.TiposHuacales
            .AsNoTracking()
            .ToListAsync();
    }
}