using JazaniTaller.Api.Exceptions;
using JazaniTaller.Application.MC.Dtos.InvestmentTypes;
using JazaniTaller.Application.MC.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace JazaniTaller.Api.Controllers.MCs
{
    [Route("api/[controller]")]
    public class InvestmentTypeController : Controller
    {
        private readonly IInvestmentTypeService _investmentTypeService;

        public InvestmentTypeController(IInvestmentTypeService investmentTypeService)
        {
            _investmentTypeService = investmentTypeService;
        }

        // GET: api/<InvestmentTypeController>
        [HttpGet]
        public async Task<IEnumerable<InvestmentTypeDto>> Get()
        {
            return await _investmentTypeService.FindAllAsync();
        }

        // GET api/<InvestmentTypeController>/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(InvestmentTypeDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorModel))]
        public async Task<Results<NotFound, Ok<InvestmentTypeDto>>> Get(int id)
        {
            var response = await _investmentTypeService.FindByIdAsync(id);

            return TypedResults.Ok(response);
        }

        // POST api/<InvestmentTypeController>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(InvestmentTypeDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorResponse))]
        public async Task<Results<BadRequest, CreatedAtRoute<InvestmentTypeDto>>> Post([FromBody] InvestmentTypeSaveDto saveDto)
        {
            var response = await _investmentTypeService.CreateAsync(saveDto);
            return TypedResults.CreatedAtRoute(response);
        }

        // PUT api/<InvestmentTypeController>/5
        [HttpPut("{id}")]
        public async Task<InvestmentTypeDto> Put(int id, [FromBody] InvestmentTypeSaveDto saveDto)
        {
            return await _investmentTypeService.EditAsync(id, saveDto);
        }

        // DELETE api/<InvestmentTypeController>/5
        [HttpDelete("{id}")]
        public async Task<InvestmentTypeDto> Delete(int id)
        {
            return await _investmentTypeService.DisabledAsync(id);
        }
    }
}
