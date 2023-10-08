using AutoMapper;
using JazaniTaller.Domain.Admins.Models;

namespace JazaniTaller.Application.Admins.Dtos.Menus.Profiles.Mappers
{
    public class MenuMapper : IMappingAction<Menu, MenuDto>
    {
        public void Process(Menu source, MenuDto destination, ResolutionContext context)
        {
            if (source.MenuId is not null)
            {
                var menuPadre = source.MenuPadre;

                destination.Menu = new()
                {
                    MenuId = menuPadre.Id,
                    Name = menuPadre.Name,
                    Url = menuPadre.Url,
                };
            }
        }
    }
}
