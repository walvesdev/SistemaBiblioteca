using SistemaBiblioteca.Business.Injecao;
using SistemaBiblioteca.Domain.Contratos.Negocio;

namespace SistemaBiblioteca.Business
{
    public class FacadeBS
    {
        public static ILivroGeneroBS LivroGenero
        {
            get
            {
                return (ILivroGeneroBS)NinjectDependencia
                    .Ninject
                        .Kernel
                            .GetService(typeof(ILivroGeneroBS));
            }
        }

        public static IAutorBS Autor
        {
            get
            {
                return (IAutorBS)NinjectDependencia
                    .Ninject
                        .Kernel
                            .GetService(typeof(IAutorBS));
            }
        }

        public static IEditoraBS Editora
        {
            get
            {
                return (IEditoraBS)NinjectDependencia
                    .Ninject
                        .Kernel
                            .GetService(typeof(IEditoraBS));
            }
        }

    }
}
