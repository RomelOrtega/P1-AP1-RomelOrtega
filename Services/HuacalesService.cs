using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using P1_AP_RomelOrtega.Models;
using P1_AP1_RomelOrtega.DAL;

namespace P1_AP1_RomelOrtega.Services
{
    public class HuacalesService(IDbContextFactory<Contexto> DbFactory)
    {
        public async Task<bool> Guardar(EntradaHuacales huacales)
        {
            if (!await Existe(e => e.IdEntrada == huacales.IdEntrada))
            {
                return await Insertar(huacales);
            }
            else
            {
                return await Modificar(huacales);
            }
        }
        public async Task<bool> Existe(Expression<Func<EntradaHuacales, bool>> predicate)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            return await contexto.EntradaHuacales.AnyAsync(predicate);
        }

        private async Task<bool> Insertar(EntradaHuacales huacales)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            contexto.EntradaHuacales.Add(huacales);
            return await contexto.SaveChangesAsync() > 0;
        }

        private async Task<bool> Modificar(EntradaHuacales huacales)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            contexto.EntradaHuacales.Update(huacales);
            return await contexto.SaveChangesAsync() > 0;
        }

        public async Task<EntradaHuacales?> Buscar(int IdEntrada)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            return await contexto.EntradaHuacales.FirstOrDefaultAsync(e => e.IdEntrada == IdEntrada);
        }
        public async Task<bool> Eliminar(int IdEntrada)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            return await contexto.EntradaHuacales
                .AsNoTracking()
                .Where(e => e.IdEntrada == IdEntrada)
                .ExecuteDeleteAsync() > 0;
        }
        public async Task<List<EntradaHuacales>> Listar(Expression<Func<EntradaHuacales, bool>> criterio)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            return await contexto.EntradaHuacales
                .AsNoTracking()
                .Where(criterio)
                .ToListAsync();
        }
    }
}

