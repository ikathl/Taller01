using JazaniTaller.Domain.Admins.Models;
using JazaniTaller.Infraestructure.Admins.Configurations;
using Microsoft.EntityFrameworkCore;

namespace JazaniTaller.Infraestructure.Cores.Contexts
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) :
            base(options)
        {

        }
        #region "DBSet"
        public DbSet<Role> Roles { get; set; }
        public DbSet<RoleMenuPermission> RoleMenuPermissions { get; set; }

        #endregion
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new RoleConfiguration());
            modelBuilder.ApplyConfiguration(new RoleMenuPermissionConfiguration());
        }
    }
}
