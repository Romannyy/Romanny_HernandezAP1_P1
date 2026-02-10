using Microsoft.EntityFrameworkCore;
using Romanny_HernandezAP1_P1.DAL;
using Romanny_HernandezAP1_P1.Models;
using System.Linq.Expressions;

namespace Romanny_HernandezAP1_P1.Services;

public class EntradasHuacalesService(IDbContextFactory<Contexto> DbFactory)
{
    // MÉTODO INSERTAR
     
    private async Task<bool> Insertar(EntradasHuacales entrada)
    {
       await using var contexto = await DbFactory.CreateDbContextAsync();
        contexto.EntradasHuacales.Add(entrada);
        return await contexto.SaveChangesAsync() > 0;
    }

    // MÉTODO EXISTE POR ID
    private async Task<bool> Existe(int idEntrada)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.EntradasHuacales.AnyAsync(a => (a.IdEntrada == idEntrada));
    }

    // MÉTODO MODIFICAR
    private async Task<bool> Modificar(EntradasHuacales entrada)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        contexto.EntradasHuacales.Update(entrada);
        return await contexto.SaveChangesAsync() > 0;
    }

    // MÉTODO EXISTE POR NOMBRE
    private async Task<bool> ExisteNombre(string nombreCliente, int idEntrada)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.EntradasHuacales.AnyAsync(a => (a.NombreCliente == nombreCliente && a.IdEntrada != idEntrada));
    }

    // MÉTODO BUSCAR
    public async Task<EntradasHuacales?> Buscar(int idEntrada)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.EntradasHuacales.AsNoTracking().FirstOrDefaultAsync(a => (a.IdEntrada == idEntrada));
    }

    // MÉTODO ELIMINAR
    public async Task<bool> Eliminar(int idEntrada)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.EntradasHuacales.Where(a => (a.IdEntrada == idEntrada)).ExecuteDeleteAsync() > 0;

    }

    // MÉTODO GUARDAR
    public async Task<bool> Guardar(EntradasHuacales entrada)
    {
        if (await ExisteNombre(entrada.NombreCliente, entrada.IdEntrada))
            throw new Exception("No puedes almacenar dos entradas con el mismo nombre.");

        if (await Existe(entrada.IdEntrada))
            return await Modificar(entrada);
        else
            return await Insertar(entrada);
    }

    // MÉTEODO LISTAR
    public async Task<List<EntradasHuacales>> Listar(Expression<Func<EntradasHuacales, bool>> criterio)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.EntradasHuacales
            .Where(criterio)
            .AsNoTracking()
            .ToListAsync();
    }


}
