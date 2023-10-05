using AutoMapper;
using JazaniTaller.Application.Admins.Dtos.Menus;
using JazaniTaller.Domain.Admins.Models;
using JazaniTaller.Domain.Admins.Repositores;

namespace JazaniTaller.Application.Admins.Services.Implementations
{
    internal class MenuService : IMenuService
    {
        private readonly IMenuRepository _MenuRepository;
        private readonly IMapper _mapper;
        public MenuService(IMenuRepository MenuRepository, IMapper mapper)
        {
            _MenuRepository = MenuRepository;
            _mapper = mapper;
        }
        public async Task<IReadOnlyList<MenuDto>> FindAllAsync()
        {
            IReadOnlyList<Menu> Menus = await _MenuRepository.FindAllAsync();
            return _mapper.Map<IReadOnlyList<MenuDto>>(Menus);

        }
        public async Task<MenuDto?> FindByIdAsync(int id)
        {
            Menu? Menu = await _MenuRepository.FindByIdAsync(id);
            return _mapper.Map<MenuDto>(Menu);
        }

        public async Task<MenuDto> CreateAsync(MenuSaveDto saveDto)
        {
            Menu Menu = _mapper.Map<Menu>(saveDto);
            Menu.RegistrationDate = DateTime.Now;
            Menu.State = true;
            Menu MenuSaved = await _MenuRepository.SaveAsync(Menu);
            return _mapper.Map<MenuDto>(MenuSaved);
        }

        public async Task<MenuDto> EditAsync(int id, MenuSaveDto MenusaveDto)
        {
            Menu Menu = await _MenuRepository.FindByIdAsync(id);
            _mapper.Map<MenuSaveDto, Menu>(MenusaveDto, Menu);
            Menu MenuSaved = await _MenuRepository.SaveAsync(Menu);
            return _mapper.Map<MenuDto>(MenuSaved);
        }

        public async Task<MenuDto> DisableAsync(int id)
        {
            Menu Menu = await _MenuRepository.FindByIdAsync(id);
            Menu.State = false;
            Menu MenuSaved = await _MenuRepository.SaveAsync(Menu);
            return _mapper.Map<MenuDto>(MenuSaved);
        }

    }
}