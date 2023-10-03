using JazaniTaller.Domain.Admins.Repositores;
using JazaniTaller.Domain.Admins.Models;
using AutoMapper;
using JazaniTaller.Application.Admins.Dtos.Roles;

namespace JazaniTaller.Application.Admins.Services.Implementations
{
    public class RoleService:IRoleService
    {
        private readonly IRoleRepository _RoleRepository;
        private readonly IMapper _mapper;
        public RoleService(IRoleRepository RoleRepository, IMapper mapper)
        {
            _RoleRepository = RoleRepository;
            _mapper = mapper;
        }
        public async Task<IReadOnlyList<RoleDto>> FindAllAsync()
        {
            IReadOnlyList<Role> Roles = await _RoleRepository.FindAllAsync();
            return _mapper.Map<IReadOnlyList<RoleDto>>(Roles);

        }
        public async Task<RoleDto?> FindByIdAsync(int id)
        {
            Role? Role = await _RoleRepository.FindByIdAsync(id);
            return _mapper.Map<RoleDto>(Role);
        }

        public async Task<RoleDto> CreateAsync(RoleSaveDto saveDto)
        {
            Role Role = _mapper.Map<Role>(saveDto);
            Role.RegistrationDate = DateTimeOffset.Now;
            Role.State = true;
            Role RoleSaved = await _RoleRepository.SaveAsync(Role);
            return _mapper.Map<RoleDto>(RoleSaved);
        }

        public async Task<RoleDto> EditAsync(int id, RoleSaveDto RolesaveDto)
        {
            Role Role = await _RoleRepository.FindByIdAsync(id);
            _mapper.Map<RoleSaveDto, Role>(RolesaveDto, Role);
            Role RoleSaved = await _RoleRepository.SaveAsync(Role);
            return _mapper.Map<RoleDto>(RoleSaved);
        }

        public async Task<RoleDto> DisableAsync(int id)
        {
            Role Role = await _RoleRepository.FindByIdAsync(id);
            Role.State = false;
            Role RoleSaved = await _RoleRepository.SaveAsync(Role);
            return _mapper.Map<RoleDto>(RoleSaved);
        }
    }
}
