using LibrarySystem.Data;
using LibrarySystem.Data.Migrations;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

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