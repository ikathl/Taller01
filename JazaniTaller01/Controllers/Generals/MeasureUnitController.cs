using JazaniTaller.Api.Exceptions;
using JazaniTaller.Application.Generals.Dtos.MesureUnits;
using JazaniTaller.Application.Generals.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace JazaniTaller.Api.Controllers.Generals
{
    [Route("api/[controller]")]
    public class MeasureUnitController : Controller
    {
        private readonly IMeasureUnitService _mesureUnitService;

        public MeasureUnitController(IMeasureUnitService MesureUnitService)
        {
            _mesureUnitService = MesureUnitService;
        }

        // GET: api/<MesureUnitController>
        [HttpGet]
        public async Task<IEnumerable<MeasureUnitDto>> Get()
        {
            return await _mesureUnitService.FindAllAsync();
        }

        // GET api/<MesureUnitController>/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(MeasureUnitDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorModel))]
        public async Task<Results<NotFound, Ok<MeasureUnitDto>>> Get(int id)
        {
            var response = await _mesureUnitService.FindByIdAsync(id);

            return TypedResults.Ok(response);
        }

        // POST api/<MesureUnitController>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(MeasureUnitDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorResponse))]
        public async Task<Results<BadRequest, CreatedAtRoute<MeasureUnitDto>>> Post([FromBody] MeasureUnitSaveDto saveDto)
        {
            var response = await _mesureUnitService.CreateAsync(saveDto);
            return TypedResults.CreatedAtRoute(response);
        }

        // PUT api/<MesureUnitController>/5
        [HttpPut("{id}")]
        public async Task<MeasureUnitDto> Put(int id, [FromBody] MeasureUnitSaveDto saveDto)
        {
            return await _mesureUnitService.EditAsync(id, saveDto);
        }

        // DELETE api/<MesureUnitController>/5
        [HttpDelete("{id}")]
        public async Task<MeasureUnitDto> Delete(int id)
        {
            return await _mesureUnitService.DisabledAsync(id);
        }
    }
}
