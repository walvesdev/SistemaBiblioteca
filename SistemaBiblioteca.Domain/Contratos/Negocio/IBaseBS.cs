using SistemaBiblioteca.Domain.Entidades;
using SistemaBiblioteca.Domain.VO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaBiblioteca.Domain.Contratos.Negocio
{
    public interface IBaseBS<TEntity>
        where TEntity : EntidadeBase
    {
        PaginacaoEntidadeVO<TEntity> Listar();
        PaginacaoEntidadeVO<TEntity> Listar(int paginaAtual, int itensPorPagina);
        PaginacaoEntidadeVO<TEntity> Pesquisar(Func<TEntity, bool> predicate);
        PaginacaoEntidadeVO<TEntity> Pesquisar(
            Func<TEntity, bool> predicate, int paginaAtual, int itensPorPagina);
        TEntity PesquisarPorId(int id);
        void Adicionar(TEntity obj);
        void Alterar(TEntity obj);
        void Excluir(Func<TEntity, bool> predicate);
        void Excluir(TEntity obj);
    }
}
