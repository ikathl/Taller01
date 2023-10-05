using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JazaniTaller.Application.Admins.Dtos.Menus
{
    public class MenuSimpleDto
    {
        public int? MenuId { get; set; }
        public string Name { get; set; }
        public string? Url { get; set; }
    }
}
