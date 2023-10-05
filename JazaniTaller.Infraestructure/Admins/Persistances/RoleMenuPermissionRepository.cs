using JazaniTaller.Domain.Admins.Models;
using JazaniTaller.Domain.Admins.Repositores;
using JazaniTaller.Infraestructure.Cores.Contexts;
using JazaniTaller.Infraestructure.Cores.Persistances;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JazaniTaller.Infraestructure.Admins.Persistances
{
    public class RoleMenuPermissionRepository:CrudRepository<RoleMenuPermission, int>, IRoleMenuPermissionRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public RoleMenuPermissionRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public override async Task<IReadOnlyList<RoleMenuPermission>> FindAllAsync()
        {
            return await _dbContext.Set<RoleMenuPermission>()
                .Include(t => t.Menu)
                .Include(t => t.Role)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<RoleMenuPermission?> FindByIdCompuesto(int roleId, int menuId, int permissionId)
        {
            return await _dbContext.Set<RoleMenuPermission>()
                .Include(t => t.Menu)
                .Include(t => t.Role)
                .FirstOrDefaultAsync(t => t.RoleId == roleId & t.MenuId == menuId);
        }
    }
}
