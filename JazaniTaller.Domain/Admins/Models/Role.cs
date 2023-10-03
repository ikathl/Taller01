using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JazaniTaller.Domain.Admins.Models
{
    public class Role
    {
        public int Id { get; set; }
        public string? Description { get; set; }
        public DateTimeOffset RegistrationDate { get; set; }
        public bool State { get; set; }
    }
}
