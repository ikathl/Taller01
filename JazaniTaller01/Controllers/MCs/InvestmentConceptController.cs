using JazaniTaller.Api.Exceptions;
using JazaniTaller.Application.MC.Dtos.InvestmentsConcepts;
using JazaniTaller.Application.MC.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;


namespace JazaniTaller.Api.Controllers.MCs
{
    [Route("api/[Controller]")]
    public class InvestmentConceptController : Controller
    {
        private readonly IInvestmentConceptService _InvestmentConceptService;

        public InvestmentConceptController(IInvestmentConceptService InvestmentConceptService)
        {
            _InvestmentConceptService = InvestmentConceptService;
        }
        // GET: 
        [HttpGet]
        public async Task<IEnumerable<InvestmentConceptDto>> Get()
        {
            return await _InvestmentConceptService.FindAllAsync();
        }


        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(InvestmentConceptDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorModel))]
        public async Task<Results<NotFound, Ok<InvestmentConceptDto>>> Get(int id)
        {
            var response = await _InvestmentConceptService.FindByIdAsync(id);
            return TypedResults.Ok(response);
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(InvestmentConceptDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorResponse))]

        public async Task<Results<BadRequest, CreatedAtRoute<InvestmentConceptDto>>> Post([FromBody] InvestmentConceptSaveDto InvestmentConceptSaveDto)
        {
            var response = await _InvestmentConceptService.CreateAsync(InvestmentConceptSaveDto);
            return TypedResults.CreatedAtRoute(response);
        }
        [HttpPut("{id}")]
        public async Task<InvestmentConceptDto> Put(int id, [FromBody] InvestmentConceptSaveDto InvestmentConceptSaveDto)
        {
            return await _InvestmentConceptService.EditAsync(id, InvestmentConceptSaveDto);
        }
        [HttpDelete("{id}")]
        public async Task<InvestmentConceptDto> Delete(int id)
        {
            return await _InvestmentConceptService.DisableAsync(id);
        }
    }
}

