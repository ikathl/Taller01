using JazaniTaller.Domain.Cores.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JazaniTaller.Application.MC.Dtos.InvestmentTypes
{
    public class InvestmentTypeDto : CoreModel<int>
    {
        public string Name { get; set; }
        public string? Description { get; set; }
    }
}
