using SistemaBiblioteca.Business.Injecao;
using SistemaBiblioteca.Data;
using SistemaBiblioteca.Domain.Contratos.Dados;
using SistemaBiblioteca.Domain.Contratos.Negocio;
using SistemaBiblioteca.Domain.Entidades;
using SistemaBiblioteca.Domain.VO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaBiblioteca.Business.Negocio
{
    public class BaseBS<TEntity> : IBaseBS<TEntity>
        where TEntity : EntidadeBase
    {
        readonly IRepositorio<TEntity> repositorio = 
            (IRepositorio<TEntity>)NinjectDependencia
                    .Ninject
                        .Kernel
                            .GetService(typeof(IRepositorio<TEntity>));

        public virtual void Adicionar(TEntity obj)
        {
            this.repositorio.Adicionar(obj);
            this.repositorio.Salvar();
        }

        public void Alterar(TEntity obj)
        {
            this.repositorio.Alterar(obj);
            this.repositorio.Salvar();
        }

        public void Excluir(Func<TEntity, bool> predicate)
        {
            this.repositorio.Excluir(predicate);
            this.repositorio.Salvar();
        }

        public void Excluir(TEntity obj)
        {
            this.repositorio.Excluir(obj);
            this.repositorio.Salvar();
        }

        public PaginacaoEntidadeVO<TEntity> Listar()
        {
            var consulta = this.repositorio.Listar();
            return new PaginacaoEntidadeVO<TEntity>
            {
                Lista = consulta.ToList(),
                QuantidadeRegistros = consulta.Count()
            };
        }

        public PaginacaoEntidadeVO<TEntity> Listar(int paginaAtual, int itensPorPagina)
        {
            var consultaTudo = this.repositorio.Listar();
            var consulta = this.repositorio.Listar(paginaAtual, itensPorPagina);
            return new PaginacaoEntidadeVO<TEntity>
            {
                Lista = consulta.ToList(),
                QuantidadeRegistros = consultaTudo.Count(),
                ItensPorPagina = itensPorPagina,
                PaginaAtual = paginaAtual
            };
        }

        public PaginacaoEntidadeVO<TEntity> Pesquisar(Func<TEntity, bool> predicate)
        {
            var consulta = this.repositorio.Pesquisar(predicate);
            return new PaginacaoEntidadeVO<TEntity>
            {
                Lista = consulta.ToList(),
                QuantidadeRegistros = consulta.Count()
            };
        }

        public PaginacaoEntidadeVO<TEntity> Pesquisar(Func<TEntity, bool> predicate, int paginaAtual, int itensPorPagina)
        {
            var consultaTudo = this.repositorio.Pesquisar(predicate);
            var consulta = this.repositorio
                .Pesquisar(predicate, paginaAtual, itensPorPagina);
            return new PaginacaoEntidadeVO<TEntity>
            {
                Lista = consulta.ToList(),
                QuantidadeRegistros = consultaTudo.Count(),
                ItensPorPagina = itensPorPagina,
                PaginaAtual = paginaAtual
            };
        }

        public TEntity PesquisarPorId(int id)
        {
            return this.repositorio.PesquisarPorId(id);
        }
    }
}
