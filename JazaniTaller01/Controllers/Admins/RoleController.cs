using JazaniTaller.Application.Admins.Dtos.Roles;
using JazaniTaller.Application.Admins.Services;
using Microsoft.AspNetCore.Mvc;

namespace JazaniTaller01.Controllers.Admins
{
    [Route("api/[Controller]")]
    public class RoleController : Controller
    {
        private readonly IRoleService _roleService;

        public RoleController(IRoleService officeService)
        {
            _roleService = officeService;
        }
        // GET: 
        [HttpGet]
        public async Task<IEnumerable<RoleDto>> Get()
        {
            return await _roleService.FindAllAsync();
        }
        [HttpGet("{id}")]
        public async Task<RoleDto> Get(int id)
        {
            return await _roleService.FindByIdAsync(id);
        }
        [HttpPost]
        public async Task<RoleDto> Post([FromBody] RoleSaveDto roleSaveDto)
        {
            return await _roleService.CreateAsync(roleSaveDto);
        }
        [HttpPut("{id}")]
        public async Task<RoleDto> Put(int id, [FromBody] RoleSaveDto roleSaveDto)
        {
            return await _roleService.EditAsync(id, roleSaveDto);
        }
        [HttpDelete("{id}")]
        public async Task<RoleDto> Delete(int id)
        {
            return await _roleService.DisableAsync(id);
        }
    }
}
