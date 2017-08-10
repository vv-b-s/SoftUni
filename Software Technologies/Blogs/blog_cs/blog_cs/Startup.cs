using blog_cs.Migrations;
using blog_cs.Models;
using Microsoft.Owin;
using Owin;
using System.Data.Entity;

[assembly: OwinStartupAttribute(typeof(blog_cs.Startup))]
namespace blog_cs
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
           // Database.SetInitializer(new MigrateDatabaseToLatestVersion<BlogDbContext, Configuration>());
            ConfigureAuth(app);
        }
    }
}
