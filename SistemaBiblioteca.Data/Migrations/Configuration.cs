namespace SistemaBiblioteca.Data.Migrations
{
    using SistemaBiblioteca.Domain.Entidades;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<SistemaBiblioteca.Data.EFDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            AutomaticMigrationDataLossAllowed = false;
        }

        protected override void Seed(SistemaBiblioteca.Data.EFDbContext context)
        {
            context.LivroGenero.Add(new LivroGenero()
            {
                Nome = "Suspense"
            });
            context.LivroGenero.Add(new LivroGenero()
            {
                Nome = "Fic��o"
            });
            context.LivroGenero.Add(new LivroGenero()
            {
                Nome = "A��o"
            });

            context.SaveChanges();
        }
    }
}
