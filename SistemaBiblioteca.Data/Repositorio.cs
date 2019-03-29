using SistemaBiblioteca.Domain.Contratos.Dados;
using SistemaBiblioteca.Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaBiblioteca.Data
{
    public class Repositorio<TEntity> : IRepositorio<TEntity>, IDisposable
        where TEntity : EntidadeBase
    {
        private readonly EFDbContext ctx = new EFDbContext();

        public void Adicionar(TEntity obj)
        {
            ctx.Set<TEntity>().Add(obj);
        }

        public void Alterar(TEntity obj)
        {
            var entidade = ctx.Set<TEntity>().Find(obj.Id);
            ctx.Entry(entidade).CurrentValues.SetValues(obj);
        }

        public void Dispose()
        {
            ctx.Dispose();
        }

        public void Excluir(Func<TEntity, bool> predicate)
        {
            ctx.Set<TEntity>()
                .Where(predicate).ToList()
                    .ForEach(del => Excluir(del));
        }

        public void Excluir(TEntity obj)
        {
            ctx.Set<TEntity>().Remove(obj);
        }

        public IQueryable<TEntity> Listar()
        {
            return ctx.Set<TEntity>();
        }

        public IQueryable<TEntity> Listar(int paginaAtual, int itensPorPagina)
        {
            return Listar()
                .OrderBy(x => x.Id)
                    .Skip(paginaAtual * itensPorPagina)
                        .Take(itensPorPagina);
        }

        public IQueryable<TEntity> Pesquisar(Func<TEntity, bool> predicate)
        {
            return Listar()
                .Where(predicate)
                    .AsQueryable();
        }

        public IQueryable<TEntity> Pesquisar(
            Func<TEntity, bool> predicate, int paginaAtual, int itensPorPagina)
        {
            return Pesquisar(predicate)
                .OrderBy(x => x.Id)
                    .Skip(paginaAtual * itensPorPagina)
                        .Take(itensPorPagina);
        }

        public TEntity PesquisarPorId(params object[] key)
        {
            return ctx.Set<TEntity>()
                .Find(key);
        }

        public void Salvar()
        {
            ctx.SaveChanges();
        }
    }
}
