using Ninject;
using Ninject.Modules;
using SistemaBiblioteca.Business.Negocio;
using SistemaBiblioteca.Data;
using SistemaBiblioteca.Domain.Contratos.Dados;
using SistemaBiblioteca.Domain.Contratos.Negocio;
using SistemaBiblioteca.Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaBiblioteca.Business.Injecao
{
    public class NinjectDependencia
    {
        public NinjectDependencia()
        {
            this.Kernel = new StandardKernel();

            this.Kernel.Bind(typeof(IRepositorio<>))
                .To(typeof(Repositorio<>))
                    .InSingletonScope();

            this.Kernel.Bind<ILivroGeneroBS>()
                .To<LivroGeneroBS>()
                    .InSingletonScope();

            this.Kernel.Bind<IAutorBS>()
                .To<AutorBS>()
                    .InSingletonScope();

            this.Kernel.Bind<IEditoraBS>()
                .To<EditoraBS>()
                    .InSingletonScope();
        }

        public IKernel Kernel { get; private set; }


        static NinjectDependencia _Ninject;
        public static NinjectDependencia Ninject
        {
            get
            {
                return _Ninject ?? (_Ninject = new NinjectDependencia());
            }
        }
    }
}
