using JazaniTaller.Api.Exceptions;
using JazaniTaller.Application.MC.Dtos.InvestmentsConcepts;
using JazaniTaller.Application.MC.Services;
using JazaniTaller.Application.SOC.Dtos.Holders;
using JazaniTaller.Application.SOC.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace JazaniTaller.Api.Controllers.SOCs
{
    [Route("api/[Controller]")]
    public class HolderController : Controller
    {
        private readonly IHolderService _holderService;

        public HolderController(IHolderService HolderService)
        {
            _holderService = HolderService;
        }
        // GET: 
        [HttpGet]
        public async Task<IEnumerable<HolderDto>> Get()
        {
            return await _holderService.FindAllAsync();
        }


        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(HolderDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorModel))]
        public async Task<Results<NotFound, Ok<HolderDto>>> Get(int id)
        {
            var response = await _holderService.FindByIdAsync(id);
            return TypedResults.Ok(response);
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(HolderDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorResponse))]

        public async Task<Results<BadRequest, CreatedAtRoute<HolderDto>>> Post([FromBody] HolderSaveDto HolderSaveDto)
        {
            var response = await _holderService.CreateAsync(HolderSaveDto);
            return TypedResults.CreatedAtRoute(response);
        }
        [HttpPut("{id}")]
        public async Task<HolderDto> Put(int id, [FromBody] HolderSaveDto HolderSaveDto)
        {
            return await _holderService.EditAsync(id, HolderSaveDto);
        }
        [HttpDelete("{id}")]
        public async Task<HolderDto> Delete(int id)
        {
            return await _holderService.DisabledAsync(id);
        }
    }
}