using ROM.Data.Migrations;
using System.Data.Entity;

namespace ROM.Web.App_Start
{
    public static class DatabaseConfig
    {
        public static void RegisterDatabase()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ROM.Data.DbContext, Configuration>());
        }
    }
}