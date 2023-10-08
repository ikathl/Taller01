using AutoMapper;
using JazaniTaller.Application.Cores.Exceptions;
using JazaniTaller.Application.MC.Dtos.InvestmentTypes;
using JazaniTaller.Domain.MC.Models;
using JazaniTaller.Domain.MC.Repositories;
using Microsoft.Extensions.Logging;

namespace JazaniTaller.Application.MC.Services.Implementations
{
    internal class InvestmentTypeService : IInvestmentTypeService
    {
        private readonly IInvestmentTypeRepository _InvestmentTypeRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<InvestmentTypeService> _logger;

        public InvestmentTypeService(IInvestmentTypeRepository InvestmentTypeRepository, IMapper mapper, ILogger<InvestmentTypeService> logger)
        {
            _InvestmentTypeRepository = InvestmentTypeRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<InvestmentTypeDto> CreateAsync(InvestmentTypeSaveDto saveDto)
        {
            InvestmentType investmentType = _mapper.Map<InvestmentType>(saveDto);
            investmentType.RegistrationDate = DateTime.Now;
            investmentType.State = true;

            await _InvestmentTypeRepository.SaveAsync(investmentType);

            return _mapper.Map<InvestmentTypeDto>(investmentType);
        }

        public async Task<InvestmentTypeDto> DisabledAsync(int id)
        {
            InvestmentType? investmentType = await _InvestmentTypeRepository.FindByIdAsync(id);

            if (investmentType is null) throw InvestmentTypeNotFound(id);

            investmentType.State = false;

            await _InvestmentTypeRepository.SaveAsync(investmentType);

            return _mapper.Map<InvestmentTypeDto>(investmentType);
        }

        public async Task<InvestmentTypeDto> EditAsync(int id, InvestmentTypeSaveDto saveDto)
        {
            InvestmentType? investmentType = await _InvestmentTypeRepository.FindByIdAsync(id);

            if (investmentType is null) throw InvestmentTypeNotFound(id);

            _mapper.Map<InvestmentTypeSaveDto, InvestmentType>(saveDto, investmentType);

            await _InvestmentTypeRepository.SaveAsync(investmentType);

            return _mapper.Map<InvestmentTypeDto>(investmentType);
        }

        public async Task<IReadOnlyList<InvestmentTypeDto>> FindAllAsync()
        {
            IReadOnlyList<InvestmentType> investmentTypes = await _InvestmentTypeRepository.FindAllAsync();

            return _mapper.Map<IReadOnlyList<InvestmentTypeDto>>(investmentTypes);
        }

        public async Task<InvestmentTypeDto?> FindByIdAsync(int id)
        {
            InvestmentType? investmentType = await _InvestmentTypeRepository.FindByIdAsync(id);

            if (investmentType is null)
            {
                _logger.LogWarning("Tipo de investement no encontrado para el id: " + id);
                throw InvestmentTypeNotFound(id);
            }

            _logger.LogInformation("Tipo de investement {name}", investmentType.Name);

            return _mapper.Map<InvestmentTypeDto>(investmentType);
        }
        private NotFoundCoreException InvestmentTypeNotFound(int id)
        {
            return new NotFoundCoreException("Tipo de investement encontrado para el id: " + id);
        }
    }
}