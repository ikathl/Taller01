using JazaniTaller.Application.Admins.Dtos.Roles;
using JazaniTaller.Application.Admins.Services;
using Microsoft.AspNetCore.Mvc;

namespace JazaniTaller.Api.Controllers.Admins
{
    [Route("api/[Controller]")]
    public class RoleMenuPermissionController : Controller
    {
        private readonly IRoleMenuPermissionService _roleMenuPermissionService;

        public RoleMenuPermissionController(IRoleMenuPermissionService officeService)
        {
            _roleMenuPermissionService = officeService;
        }
        // GET: 
        [HttpGet]
        public async Task<IEnumerable<RoleMenuPermissionDto>> Get()
        {
            return await _roleMenuPermissionService.FindAllAsync();
        }
        [HttpGet("{id}")]
        public async Task<RoleMenuPermissionDto> Get(int id)
        {
            return await _roleMenuPermissionService.FindByIdAsync(id);
        }
        [HttpPost]
        public async Task<RoleMenuPermissionDto> Post([FromBody] RoleMenuPermissionSaveDto roleSaveDto)
        {
            return await _roleMenuPermissionService.CreateAsync(roleSaveDto);
        }
        [HttpPut("{id}")]
        public async Task<RoleMenuPermissionDto> Put(int id, [FromBody] RoleMenuPermissionSaveDto roleSaveDto)
        {
            return await _roleMenuPermissionService.EditAsync(id, roleSaveDto);
        }
        [HttpDelete("{id}")]
        public async Task<RoleMenuPermissionDto> Delete(int id)
        {
            return await _roleMenuPermissionService.DisableAsync(id);
        }
    }
}
