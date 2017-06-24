using LibrarySystem.Data;
using LibrarySystem.Data.Contracts;
using LibrarySystem.Data.Repositories;
using Ninject.Extensions.Conventions;
using Ninject.Extensions.Conventions.Syntax;
using Ninject.Modules;
using Ninject.Web.Common;

namespace LibrarySystem.Web.App_Start.NinjectBindings
{
    public class DataBindingsModule : NinjectModule
    {
        public override void Load()
        {
            this.Bind(this.BindClasses);
            this.Bind<ILibrarySystemEfDbContextSaveChanges>().To<LibrarySystemEfDbContextSaveChanges>().InRequestScope();
        }

        private void BindClasses(IFromSyntax bindings)
        {
            bindings.FromAssembliesMatching("LibrarySystem.Data.dll")
                    .SelectAllClasses()
                    .BindDefaultInterface()
                    .ConfigureFor<LibrarySystemEfDbContext>(c => c.InRequestScope());
                    
        }
    }
}