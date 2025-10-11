using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using P1_AP1_RomelOrtega.DAL;
using P1_AP1_RomelOrtega.Models;

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
            await AfectarExistencia(huacales.EntradasHuacalesDetalles.ToArray(), TipoOperacion.Suma);
            return await contexto.SaveChangesAsync() > 0;
        }

        private async Task<bool> Modificar(EntradaHuacales huacales)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();

            var entradaAnterior = await contexto.EntradaHuacales
                .Include(e => e.EntradasHuacalesDetalles)
                .AsNoTracking()
                .FirstOrDefaultAsync(e => e.IdEntrada == huacales.IdEntrada);

            if (entradaAnterior == null)
            {
                return false;
            }

            if (entradaAnterior.EntradasHuacalesDetalles.Any())
            {
                await AfectarExistencia(entradaAnterior.EntradasHuacalesDetalles.ToArray(), TipoOperacion.Resta);
            }

            if (huacales.EntradasHuacalesDetalles.Any())
            {
                await AfectarExistencia(huacales.EntradasHuacalesDetalles.ToArray(), TipoOperacion.Suma);
            }

            contexto.EntradaHuacales.Update(huacales);

            var cambios = await contexto.SaveChangesAsync();
            return cambios > 0;
        }

        public async Task<EntradaHuacales?> Buscar(int IdEntrada)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            return await contexto.EntradaHuacales
                .Include(e => e.EntradasHuacalesDetalles)
                .FirstOrDefaultAsync(e => e.IdEntrada == IdEntrada);
        }

        public async Task<bool> Eliminar(int IdEntrada)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            var entrada = await contexto.EntradaHuacales
                .Include(e => e.EntradasHuacalesDetalles)
                .FirstOrDefaultAsync(e => e.IdEntrada == IdEntrada);

            if (entrada == null)
            {
                return false;
            }

            await AfectarExistencia(entrada.EntradasHuacalesDetalles.ToArray(), TipoOperacion.Resta);
            contexto.EntradasHuacalesDetalle.RemoveRange(entrada.EntradasHuacalesDetalles);
            contexto.EntradaHuacales.Remove(entrada);

            var cantidad = await contexto.SaveChangesAsync();
            return cantidad > 0;
        }

        public async Task<List<EntradaHuacales>> Listar(Expression<Func<EntradaHuacales, bool>> criterio)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            return await contexto.EntradaHuacales
                .Include(e => e.EntradasHuacalesDetalles)
                .AsNoTracking()
                .Where(criterio)
                .ToListAsync();
        }

        private async Task AfectarExistencia(EntradasHuacalesDetalle[] detalle, TipoOperacion tipoOperacion)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();

            foreach (var item in detalle)
            {
                var tipoHuacal = await contexto.TiposHuacales
                    .SingleOrDefaultAsync(t => t.IdTipo == item.IdTipo);

                if (tipoHuacal == null)
                    continue;

                if (tipoOperacion == TipoOperacion.Suma)
                    tipoHuacal.Existencia += item.Cantidad;
                else
                    tipoHuacal.Existencia -= item.Cantidad;
            }

            await contexto.SaveChangesAsync();
        }

        public async Task<List<TiposHuacales>> ListarTiposHuacales()
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            return await contexto.TiposHuacales.ToListAsync();
        }

        public enum TipoOperacion
        {
            Suma = 1,
            Resta = 2
        }
    }
}
