using JazaniTaller.Domain.Admins.Models;
using JazaniTaller.Domain.Admins.Repositores;
using JazaniTaller.Infraestructure.Cores.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JazaniTaller.Infraestructure.Admins.Persistances
{
    public class RoleMenuPermissionRepository:IRoleMenuPermissionRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public RoleMenuPermissionRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IReadOnlyList<RoleMenuPermission>> FindAllAsync()
        {
            return await _dbContext.RoleMenuPermissions.ToListAsync();
        }

        public async Task<RoleMenuPermission?> FindByIdAsync(int id)
        {
            return await _dbContext.RoleMenuPermissions.FirstOrDefaultAsync(x => x.RoleId == id);
        }
        public async Task<RoleMenuPermission?> SaveAsync(RoleMenuPermission roleMenuPermission)
        {
            EntityState state = _dbContext.Entry(roleMenuPermission).State;
            _ = state switch
            {
                EntityState.Detached => _dbContext.RoleMenuPermissions.Add(roleMenuPermission),
                EntityState.Modified => _dbContext.RoleMenuPermissions.Update(roleMenuPermission),
            };

            await _dbContext.SaveChangesAsync();

            return roleMenuPermission;

        }
    }
}
