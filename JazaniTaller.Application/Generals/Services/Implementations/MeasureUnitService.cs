using AutoMapper;
using JazaniTaller.Application.Cores.Exceptions;
using JazaniTaller.Application.Generals.Dtos.MesureUnits;
using JazaniTaller.Domain.Generals.Models;
using JazaniTaller.Domain.Generals.Repositories;
using Microsoft.Extensions.Logging;

namespace JazaniTaller.Application.Generals.Services.Implementations
{
    public class MeasureUnitService : IMeasureUnitService
    {
        private readonly IMeasureUnitRepository _measureUnitRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<MeasureUnitService> _logger;

        public MeasureUnitService(IMeasureUnitRepository MeasureUnitRepository, IMapper mapper, ILogger<MeasureUnitService> logger)
        {
            _measureUnitRepository = MeasureUnitRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<MeasureUnitDto> CreateAsync(MeasureUnitSaveDto saveDto)
        {
            MeasureUnit measureUnit = _mapper.Map<MeasureUnit>(saveDto);
            measureUnit.RegistrationDate = DateTime.Now;
            measureUnit.State = true;

            await _measureUnitRepository.SaveAsync(measureUnit);

            return _mapper.Map<MeasureUnitDto>(measureUnit);
        }

        public async Task<MeasureUnitDto> DisabledAsync(int id)
        {
            MeasureUnit? measureUnit = await _measureUnitRepository.FindByIdAsync(id);

            if (measureUnit is null) throw MeasureUnitNotFound(id);

            measureUnit.State = false;

            await _measureUnitRepository.SaveAsync(measureUnit);

            return _mapper.Map<MeasureUnitDto>(measureUnit);
        }

        public async Task<MeasureUnitDto> EditAsync(int id, MeasureUnitSaveDto saveDto)
        {
            MeasureUnit? measureUnit = await _measureUnitRepository.FindByIdAsync(id);

            if (measureUnit is null) throw MeasureUnitNotFound(id);

            _mapper.Map<MeasureUnitSaveDto, MeasureUnit>(saveDto, measureUnit);

            await _measureUnitRepository.SaveAsync(measureUnit);

            return _mapper.Map<MeasureUnitDto>(measureUnit);
        }

        public async Task<IReadOnlyList<MeasureUnitDto>> FindAllAsync()
        {
            IReadOnlyList<MeasureUnit> measureUnits = await _measureUnitRepository.FindAllAsync();

            return _mapper.Map<IReadOnlyList<MeasureUnitDto>>(measureUnits);
        }

        public async Task<MeasureUnitDto?> FindByIdAsync(int id)
        {
            MeasureUnit? measureUnit = await _measureUnitRepository.FindByIdAsync(id);

            if (measureUnit is null)
            {
                _logger.LogWarning("Measure unit no encontrado para el id: {id}", id);
                throw MeasureUnitNotFound(id);
            }

            _logger.LogInformation("Measure unit {name}", measureUnit.Name);

            return _mapper.Map<MeasureUnitDto>(measureUnit);
        }
        private NotFoundCoreException MeasureUnitNotFound(int id)
        {
            return new NotFoundCoreException(String.Format("Measure unit no encontrado para el id: {id}", id));
        }
    }
}
