using SistemaBiblioteca.Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaBiblioteca.Domain.Contratos.Dados
{
    public interface IRepositorio<TEntity>
        where TEntity: EntidadeBase
    {
        IQueryable<TEntity> Listar();
        IQueryable<TEntity> Listar(int paginaAtual, int itensPorPagina);
        IQueryable<TEntity> Pesquisar(Func<TEntity, bool> predicate);
        IQueryable<TEntity> Pesquisar(
            Func<TEntity, bool> predicate, int paginaAtual, int itensPorPagina);
        TEntity PesquisarPorId(params object[] key);
        void Adicionar(TEntity obj);
        void Alterar(TEntity obj);
        void Excluir(Func<TEntity, bool> predicate);
        void Excluir(TEntity obj);
        void Salvar();
    }
}
