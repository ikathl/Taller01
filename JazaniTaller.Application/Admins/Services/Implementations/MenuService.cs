using AutoMapper;
using JazaniTaller.Application.Admins.Dtos.Menus;
using JazaniTaller.Application.Cores.Exceptions;
using JazaniTaller.Domain.Admins.Models;
using JazaniTaller.Domain.Admins.Repositores;
using Microsoft.Extensions.Logging;

namespace JazaniTaller.Application.Admins.Services.Implementations
{
    public class MenuService : IMenuService
    {
        private readonly IMenuRepository _MenuRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<MenuService> _logger;
        public MenuService(IMenuRepository MenuRepository, IMapper mapper, ILogger<MenuService> logger)
        {
            _MenuRepository = MenuRepository;
            _mapper = mapper;
            _logger = logger;
        }
        public async Task<IReadOnlyList<MenuDto>> FindAllAsync()
        {
            IReadOnlyList<Menu> Menus = await _MenuRepository.FindAllAsync();
            return _mapper.Map<IReadOnlyList<MenuDto>>(Menus);

        }
        public async Task<MenuDto?> FindByIdAsync(int id)
        {
            Menu? menu = await _MenuRepository.FindByIdAsync(id);
            if (menu is null)
            {
                _logger.LogWarning("Menu no encontrado para el id: {id}", id);
                throw MineralTypeNotFound(id);
            }
            return _mapper.Map<MenuDto>(menu);
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
            Menu menu = await _MenuRepository.FindByIdAsync(id);

            if (menu is null) throw MineralTypeNotFound(id);

            _mapper.Map<MenuSaveDto, Menu>(MenusaveDto, menu);
            Menu MenuSaved = await _MenuRepository.SaveAsync(menu);
            return _mapper.Map<MenuDto>(MenuSaved);
        }

        public async Task<MenuDto> DisableAsync(int id)
        {
            Menu menu = await _MenuRepository.FindByIdAsync(id);

            if (menu is null) throw MineralTypeNotFound(id);

            menu.State = false;
            Menu MenuSaved = await _MenuRepository.SaveAsync(menu);
            return _mapper.Map<MenuDto>(MenuSaved);
        }
        private NotFoundCoreException MineralTypeNotFound(int id)
        {
            return new NotFoundCoreException("Menu no encontrado para el id: " + id);
        }
    }
}