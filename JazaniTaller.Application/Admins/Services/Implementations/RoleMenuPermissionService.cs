using AutoMapper;
using JazaniTaller.Application.Admins.Dtos.Roles;
using JazaniTaller.Domain.Admins.Models;
using JazaniTaller.Domain.Admins.Repositores;

namespace JazaniTaller.Application.Admins.Services.Implementations
{
    public class RoleMenuPermissionService : IRoleMenuPermissionService
    {
        private readonly IRoleMenuPermissionRepository _RoleMenuPermissionRepository;
        private readonly IMapper _mapper;
        public RoleMenuPermissionService(IRoleMenuPermissionRepository RoleMenuPermissionRepository, IMapper mapper)
        {
            _RoleMenuPermissionRepository = RoleMenuPermissionRepository;
            _mapper = mapper;
        }
        public async Task<IReadOnlyList<RoleMenuPermissionDto>> FindAllAsync()
        {
            IReadOnlyList<RoleMenuPermission> Roles = await _RoleMenuPermissionRepository.FindAllAsync();
            return _mapper.Map<IReadOnlyList<RoleMenuPermissionDto>>(Roles);

        }
        public async Task<RoleMenuPermissionDto?> FindByIdAsync(int id)
        {
            RoleMenuPermission? Role = await _RoleMenuPermissionRepository.FindByIdAsync(id);
            return _mapper.Map<RoleMenuPermissionDto>(Role);
        }

        public async Task<RoleMenuPermissionDto> CreateAsync(RoleMenuPermissionSaveDto saveDto)
        {
            RoleMenuPermission Role = _mapper.Map<RoleMenuPermission>(saveDto);
            Role.RegistrationDate = DateTime.Now;
            Role.State = true;
            RoleMenuPermission RoleSaved = await _RoleMenuPermissionRepository.SaveAsync(Role);
            return _mapper.Map<RoleMenuPermissionDto>(RoleSaved);
        }

        public async Task<RoleMenuPermissionDto> EditAsync(int id, RoleMenuPermissionSaveDto RolesaveDto)
        {
            RoleMenuPermission Role = await _RoleMenuPermissionRepository.FindByIdAsync(id);
            _mapper.Map<RoleMenuPermissionSaveDto, RoleMenuPermission>(RolesaveDto, Role);
            RoleMenuPermission RoleSaved = await _RoleMenuPermissionRepository.SaveAsync(Role);
            return _mapper.Map<RoleMenuPermissionDto>(RoleSaved);
        }

        public async Task<RoleMenuPermissionDto> DisableAsync(int id)
        {
            RoleMenuPermission Role = await _RoleMenuPermissionRepository.FindByIdAsync(id);
            Role.State = false;
            RoleMenuPermission RoleSaved = await _RoleMenuPermissionRepository.SaveAsync(Role);
            return _mapper.Map<RoleMenuPermissionDto>(RoleSaved);
        }
    }
}