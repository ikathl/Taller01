using JazaniTaller.Api.Exceptions;
using JazaniTaller.Application.Admins.Dtos.Menus;
using JazaniTaller.Application.Admins.Services;
using Microsoft.AspNetCore.Http.HttpResults;
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
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(MenuDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorModel))]
        public async Task<Results<NotFound, Ok<MenuDto>>> Get(int id)
        {
            var response = await _menuService.FindByIdAsync(id);
            return TypedResults.Ok(response);
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(MenuDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorResponse))]

        public async Task<Results<BadRequest, CreatedAtRoute<MenuDto>>> Post([FromBody] MenuSaveDto menuSaveDto)
        {
            var response = await _menuService.CreateAsync(menuSaveDto);
            return TypedResults.CreatedAtRoute(response);
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
