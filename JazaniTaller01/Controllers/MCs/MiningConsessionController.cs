using JazaniTaller.Api.Exceptions;
using JazaniTaller.Application.MC.Dtos.MiningConcessions;
using JazaniTaller.Application.MC.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace JazaniTaller.Api.Controllers.MCs
{
    [Route("api/[controller]")]
    public class MiningConsessionController : Controller
    {
        private readonly IMiningConcessionService _miningConcessionService;

        public MiningConsessionController(IMiningConcessionService MiningConcessionService)
        {
            _miningConcessionService = MiningConcessionService;
        }

        // GET: api/<MiningConcessionController>
        [HttpGet]
        public async Task<IEnumerable<MiningConcessionDto>> Get()
        {
            return await _miningConcessionService.FindAllAsync();
        }

        // GET api/<MiningConcessionController>/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(MiningConcessionDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorModel))]
        public async Task<Results<NotFound, Ok<MiningConcessionDto>>> Get(int id)
        {
            var response = await _miningConcessionService.FindByIdAsync(id);

            return TypedResults.Ok(response);
        }

        // POST api/<MiningConcessionController>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(MiningConcessionDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorResponse))]
        public async Task<Results<BadRequest, CreatedAtRoute<MiningConcessionDto>>> Post([FromBody] MiningConcessionSaveDto saveDto)
        {
            var response = await _miningConcessionService.CreateAsync(saveDto);
            return TypedResults.CreatedAtRoute(response);
        }

        // PUT api/<MiningConcessionController>/5
        [HttpPut("{id}")]
        public async Task<MiningConcessionDto> Put(int id, [FromBody] MiningConcessionSaveDto saveDto)
        {
            return await _miningConcessionService.EditAsync(id, saveDto);
        }

        // DELETE api/<MiningConcessionController>/5
        [HttpDelete("{id}")]
        public async Task<MiningConcessionDto> Delete(int id)
        {
            return await _miningConcessionService.DisabledAsync(id);
        }
    }
}