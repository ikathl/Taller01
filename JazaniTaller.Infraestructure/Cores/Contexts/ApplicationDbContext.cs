using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace JazaniTaller.Infraestructure.Cores.Contexts
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) :
            base(options)
        {

        }
        //#region "DBSet"
        //public DbSet<Role> Roles { get; set; }
        //public DbSet<RoleMenuPermission> RoleMenuPermissions { get; set; }

        //#endregion
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //modelBuilder.ApplyConfiguration(new RoleConfiguration());
            //modelBuilder.ApplyConfiguration(new RoleMenuPermissionConfiguration());
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
