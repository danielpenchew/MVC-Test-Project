using LibrarySystem.Data;
using LibrarySystem.Data.Migrations;
using System.Data.Entity;

namespace LibrarySystem.Web.App_Start
{
    public static class DbConfig
    {
        public static void Initialize()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<LibrarySystemEfDbContext, Configuration>());
            LibrarySystemEfDbContext.Create().Database.CreateIfNotExists();
        }
    }
}