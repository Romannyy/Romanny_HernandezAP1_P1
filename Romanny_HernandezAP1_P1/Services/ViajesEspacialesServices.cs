using Microsoft.EntityFrameworkCore;
using Romanny_HernandezAP1_P1.DAL;
using Romanny_HernandezAP1_P1.Models;
using System.Linq.Expressions;

namespace Romanny_HernandezAP1_P1.Services;

public class ViajesEspacialesServices(IDbContextFactory<Contexto> DbFactory)
{
    // MÉTODO INSERTAR
    private async Task<bool> Insertar()
    {

    }

    // MÉTODO EXISTE POR ID
    private async Task<bool> Existe()
    {

    }

    // MÉTODO MODIFICAR
    private async Task<bool> Modificar()
    {

    }

    // MÉTODO EXISTE POR NOMBRE
    private async Task<bool> ExisteNombre()
    {

    }

    // MÉTODO BUSCAR
    public async Task<ViajesEspaciales?> Buscar()
    {

    }

    // MÉTODO ELIMINAR
    public async Task<bool> Eliminar()
    {

    }

    // MÉTODO GUARDAR
    public async Task<bool> Guardar()
    {

    }

    // MÉTEODO LISTAR
    public async Task<List<ViajesEspaciales>> Listar(Expression<Func<ViajesEspaciales, bool>> criterio)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.ViajesEspaciales
            .Where(criterio)
            .AsNoTracking()
            .ToListAsync();
    }
}
