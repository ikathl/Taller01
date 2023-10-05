using JazaniTaller.Application.Admins.Dtos.Menus;
using JazaniTaller.Application.Admins.Services;
using Microsoft.AspNetCore.Mvc;

namespace JazaniTaller.Controllers.Admins
{
    [Route("api/[Controller]")]
    public class MenuController : Controller
    {
        private readonly IMenuService _menuService;

        public MenuController(IMenuService menuService)
        {
            _menuService = menuService;
        }
        // GET: 
        [HttpGet]
        public async Task<IEnumerable<MenuDto>> Get()
        {
            return await _menuService.FindAllAsync();
        }
        [HttpGet("{id}")]
        public async Task<MenuDto> Get(int id)
        {
            return await _menuService.FindByIdAsync(id);
        }
        [HttpPost]
        public async Task<MenuDto> Post([FromBody] MenuSaveDto menuSaveDto)
        {
            return await _menuService.CreateAsync(menuSaveDto);
        }
        [HttpPut("{id}")]
        public async Task<MenuDto> Put(int id, [FromBody] MenuSaveDto menuSaveDto)
        {
            return await _menuService.EditAsync(id, menuSaveDto);
        }
        [HttpDelete("{id}")]
        public async Task<MenuDto> Delete(int id)
        {
            return await _menuService.DisableAsync(id);
        }
    }
}
