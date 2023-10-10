using AutoMapper;
using JazaniTaller.Application.Cores.Exceptions;
using Microsoft.Extensions.Logging;
using JazaniTaller.Domain.MC.Repositories;
using JazaniTaller.Application.MC.Dtos.Investments;
using JazaniTaller.Domain.MC.Models;
using JazaniTaller.Core.Paginations;

namespace JazaniTaller.Application.MC.Services.Implementation
{
    public class InvestmentService : IInvestmentService
    {
        private readonly IInvestmentRepository _InvestmentRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<InvestmentService> _logger;
        public InvestmentService(IInvestmentRepository InvestmentRepository, IMapper mapper, ILogger<InvestmentService> logger)
        {
            _InvestmentRepository = InvestmentRepository;
            _mapper = mapper;
            _logger = logger;
        }
        public async Task<IReadOnlyList<InvestmentDto>> FindAllAsync()
        {
            IReadOnlyList<Investment> Investments = await _InvestmentRepository.FindAllAsync();
            return _mapper.Map<IReadOnlyList<InvestmentDto>>(Investments);

        }
        public async Task<InvestmentDto?> FindByIdAsync(int id)
        {
            Investment? Investment = await _InvestmentRepository.FindByIdAsync(id);
            if (Investment is null)
            {
                _logger.LogWarning("Investment no encontrado para el id: {id}", id);
                throw InvestmentNotFound(id);
            }
            return _mapper.Map<InvestmentDto>(Investment);
        }

        public async Task<InvestmentDto> CreateAsync(InvestmentSaveDto saveDto)
        {
            Investment Investment = _mapper.Map<Investment>(saveDto);
            Investment.RegistrationDate = DateTime.Now;
            Investment.State = true;
            Investment InvestmentSaved = await _InvestmentRepository.SaveAsync(Investment);
            return _mapper.Map<InvestmentDto>(InvestmentSaved);
        }

        public async Task<InvestmentDto> EditAsync(int id, InvestmentSaveDto InvestmentsaveDto)
        {
            Investment Investment = await _InvestmentRepository.FindByIdAsync(id);

            if (Investment is null) throw InvestmentNotFound(id);

            _mapper.Map<InvestmentSaveDto, Investment>(InvestmentsaveDto, Investment);
            Investment InvestmentSaved = await _InvestmentRepository.SaveAsync(Investment);
            return _mapper.Map<InvestmentDto>(InvestmentSaved);
        }

        public async Task<InvestmentDto> DisabledAsync(int id)
        {
            Investment Investment = await _InvestmentRepository.FindByIdAsync(id);

            if (Investment is null) throw InvestmentNotFound(id);

            Investment.State = false;
            Investment InvestmentSaved = await _InvestmentRepository.SaveAsync(Investment);
            return _mapper.Map<InvestmentDto>(InvestmentSaved);
        }
        private NotFoundCoreException InvestmentNotFound(int id)
        {
            return new NotFoundCoreException("Investment no encontrado para el id: " + id);
        }

        public async Task<ResponsePagination<InvestmentDto>> PaginatedSearch(RequestPagination<InvestmentFilterDto> request)
        {
            var entity = _mapper.Map<RequestPagination<Investment>>(request);
            var response=await _InvestmentRepository.PaginatedSearch(entity);
            
            return _mapper.Map<ResponsePagination<InvestmentDto>>(response);
        }
    }
}
