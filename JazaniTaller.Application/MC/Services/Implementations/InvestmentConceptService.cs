using AutoMapper;
using JazaniTaller.Application.Cores.Exceptions;
using JazaniTaller.Application.MC.Dtos.InvestmentsConcepts;
using JazaniTaller.Domain.MC.Models;
using JazaniTaller.Domain.MC.Repositories;
using Microsoft.Extensions.Logging;

namespace JazaniTaller.Application.MC.Services.Implementations
{
    public class InvestmentConceptService : IInvestmentConceptService
    {
        private readonly IInvestmentConceptRepository _InvestmentConceptRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<InvestmentConceptService> _logger;
        public InvestmentConceptService(IInvestmentConceptRepository InvestmentConceptRepository, IMapper mapper, ILogger<InvestmentConceptService> logger)
        {
            _InvestmentConceptRepository = InvestmentConceptRepository;
            _mapper = mapper;
            _logger = logger;
        }
        public async Task<IReadOnlyList<InvestmentConceptDto>> FindAllAsync()
        {
            IReadOnlyList<InvestmentConcept> InvestmentConcepts = await _InvestmentConceptRepository.FindAllAsync();
            return _mapper.Map<IReadOnlyList<InvestmentConceptDto>>(InvestmentConcepts);

        }
        public async Task<InvestmentConceptDto?> FindByIdAsync(int id)
        {
            InvestmentConcept? InvestmentConcept = await _InvestmentConceptRepository.FindByIdAsync(id);
            if (InvestmentConcept is null)
            {
                _logger.LogWarning("InvestmentConcept no encontrado para el id: {id}", id);
                throw InvestmentConceptNotFound(id);
            }
            return _mapper.Map<InvestmentConceptDto>(InvestmentConcept);
        }

        public async Task<InvestmentConceptDto> CreateAsync(InvestmentConceptSaveDto saveDto)
        {
            InvestmentConcept InvestmentConcept = _mapper.Map<InvestmentConcept>(saveDto);
            InvestmentConcept.RegistrationDate = DateTime.Now;
            InvestmentConcept.State = true;
            InvestmentConcept InvestmentConceptSaved = await _InvestmentConceptRepository.SaveAsync(InvestmentConcept);
            return _mapper.Map<InvestmentConceptDto>(InvestmentConceptSaved);
        }

        public async Task<InvestmentConceptDto> EditAsync(int id, InvestmentConceptSaveDto InvestmentConceptsaveDto)
        {
            InvestmentConcept InvestmentConcept = await _InvestmentConceptRepository.FindByIdAsync(id);

            if (InvestmentConcept is null) throw InvestmentConceptNotFound(id);

            _mapper.Map<InvestmentConceptSaveDto, InvestmentConcept>(InvestmentConceptsaveDto, InvestmentConcept);
            InvestmentConcept InvestmentConceptSaved = await _InvestmentConceptRepository.SaveAsync(InvestmentConcept);
            return _mapper.Map<InvestmentConceptDto>(InvestmentConceptSaved);
        }

        public async Task<InvestmentConceptDto> DisableAsync(int id)
        {
            InvestmentConcept InvestmentConcept = await _InvestmentConceptRepository.FindByIdAsync(id);

            if (InvestmentConcept is null) throw InvestmentConceptNotFound(id);

            InvestmentConcept.State = false;
            InvestmentConcept InvestmentConceptSaved = await _InvestmentConceptRepository.SaveAsync(InvestmentConcept);
            return _mapper.Map<InvestmentConceptDto>(InvestmentConceptSaved);
        }
        private NotFoundCoreException InvestmentConceptNotFound(int id)
        {
            return new NotFoundCoreException("InvestmentConcept no encontrado para el id: " + id);
        }
    }
}
