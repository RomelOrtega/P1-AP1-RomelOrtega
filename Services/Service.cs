using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using P1_AP_RomelOrtega.Models;
using P1_AP1_RomelOrtega.DAL;

namespace P1_AP1_RomelOrtega.Services
{
    public class Service(IDbContextFactory<Contexto> DbFactory)
    {
        public async Task<List<EntradaGuacales>> Listar(Expression<Func<EntradaGuacales, bool>> criterio)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            return await contexto.Registros
                .AsNoTracking()
                .Where(criterio)
                .ToListAsync();
        }
    }
}
