using AutoMapper;
using JazaniTaller.Application.Cores.Exceptions;
using JazaniTaller.Application.Generals.Dtos.PeriodTypes;
using JazaniTaller.Domain.Generals.Models;
using JazaniTaller.Domain.Generals.Repositories;
using Microsoft.Extensions.Logging;

namespace JazaniTaller.Application.Generals.Services.Implementations
{
    internal class PeriodTypeService : IPeriodTypeService
    {
        private readonly IPeriodTypeRepository _periodTypeRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<PeriodTypeService> _logger;

        public PeriodTypeService(IPeriodTypeRepository periodTypeRepository, IMapper mapper, ILogger<PeriodTypeService> logger)
        {
            _periodTypeRepository = periodTypeRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<PeriodTypeDto> CreateAsync(PeriodTypeSaveDto saveDto)
        {
            PeriodType periodType = _mapper.Map<PeriodType>(saveDto);
            periodType.RegistrationDate = DateTime.Now;
            periodType.State = true;

            await _periodTypeRepository.SaveAsync(periodType);

            return _mapper.Map<PeriodTypeDto>(periodType);
        }

        public async Task<PeriodTypeDto> DisabledAsync(int id)
        {
            PeriodType? periodType = await _periodTypeRepository.FindByIdAsync(id);

            if (periodType is null) throw PeriodTypeNotFound(id);

            periodType.State = false;

            await _periodTypeRepository.SaveAsync(periodType);

            return _mapper.Map<PeriodTypeDto>(periodType);
        }

        public async Task<PeriodTypeDto> EditAsync(int id, PeriodTypeSaveDto saveDto)
        {
            PeriodType? periodType = await _periodTypeRepository.FindByIdAsync(id);

            if (periodType is null) throw PeriodTypeNotFound(id);

            _mapper.Map<PeriodTypeSaveDto, PeriodType>(saveDto, periodType);

            await _periodTypeRepository.SaveAsync(periodType);

            return _mapper.Map<PeriodTypeDto>(periodType);
        }

        public async Task<IReadOnlyList<PeriodTypeDto>> FindAllAsync()
        {
            IReadOnlyList<PeriodType> periodTypes = await _periodTypeRepository.FindAllAsync();

            return _mapper.Map<IReadOnlyList<PeriodTypeDto>>(periodTypes);
        }

        public async Task<PeriodTypeDto?> FindByIdAsync(int id)
        {
            PeriodType? periodType = await _periodTypeRepository.FindByIdAsync(id);

            if (periodType is null)
            {
                _logger.LogWarning("Period Type no encontrado para el id: {id}", id);
                throw PeriodTypeNotFound(id);
            }

            _logger.LogInformation("Period Type  {name}", periodType.Name);

            return _mapper.Map<PeriodTypeDto>(periodType);
        }
        private NotFoundCoreException PeriodTypeNotFound(int id)
        {
            return new NotFoundCoreException(String.Format("Period Type  no encontrado para el id: {id}", id));
        }
    }
}
