using LibrarySystem.Data.Services;
using LibrarySystem.Data.Services.Contracts;
using Ninject.Extensions.Conventions;
using Ninject.Extensions.Conventions.Syntax;
using Ninject.Modules;

namespace LibrarySystem.Web.App_Start.NinjectBindings
{
    public class DataServicesBindingsModule : NinjectModule
    {
        public override void Load()
        {
            this.Bind(this.BindClasses);
        }

        private void BindClasses(IFromSyntax bindings)
        {
            bindings.FromAssembliesMatching("*.Data.Services.*")
                    .SelectAllClasses()
                    .BindDefaultInterface();
        }
    }
}