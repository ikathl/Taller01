using JazaniTaller.Api.Exceptions;
using JazaniTaller.Application.MC.Dtos.Investments;
using JazaniTaller.Application.MC.Services;
using JazaniTaller.Core.Paginations;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;


namespace JazaniTaller.Api.Controllers.MCs
{
    [Route("api/[Controller]")]
    public class InvestmentController : Controller
    {
        private readonly IInvestmentService _InvestmentService;

        public InvestmentController(IInvestmentService InvestmentService)
        {
            _InvestmentService = InvestmentService;
        }
        // GET: 
        [HttpGet]
        public async Task<IEnumerable<InvestmentDto>> Get()
        {
            return await _InvestmentService.FindAllAsync();
        }


        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(InvestmentDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorModel))]
        public async Task<Results<NotFound<ErrorModel>, Ok<InvestmentDto>>> Get(int id)
        {
            var response = await _InvestmentService.FindByIdAsync(id);
            return TypedResults.Ok(response);
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(InvestmentDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorResponse))]

        public async Task<Results<BadRequest, CreatedAtRoute<InvestmentDto>>> Post([FromBody] InvestmentSaveDto InvestmentSaveDto)
        {
            var response = await _InvestmentService.CreateAsync(InvestmentSaveDto);
            return TypedResults.CreatedAtRoute(response);
        }
        [HttpPut("{id}")]
        public async Task<InvestmentDto> Put(int id, [FromBody] InvestmentSaveDto InvestmentSaveDto)
        {
            return await _InvestmentService.EditAsync(id, InvestmentSaveDto);
        }
        [HttpDelete("{id}")]
        public async Task<InvestmentDto> Delete(int id)
        {
            return await _InvestmentService.DisabledAsync(id);
        }
        [HttpGet("PaginatedSearch")]
        public async Task<ResponsePagination<InvestmentDto>> PaginatedSearch([FromQuery] RequestPagination<InvestmentFilterDto> request)
        {
            return await _InvestmentService.PaginatedSearch(request);
        }

    }
}

