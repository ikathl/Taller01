using AutoMapper;
using JazaniTaller.Application.Cores.Exceptions;
using JazaniTaller.Application.MC.Dtos.MiningConcessions;
using JazaniTaller.Domain.MC.Models;
using JazaniTaller.Domain.MC.Repositories;
using Microsoft.Extensions.Logging;

namespace JazaniTaller.Application.MC.Services.Implementations
{
    public class MiningConcessionService : IMiningConcessionService
    {
        private readonly IMiningConcessionRepository _miningConcessionRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<MiningConcessionService> _logger;

        public MiningConcessionService(IMiningConcessionRepository MiningConcessionRepository, IMapper mapper, ILogger<MiningConcessionService> logger)
        {
            _miningConcessionRepository = MiningConcessionRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<MiningConcessionDto> CreateAsync(MiningConcessionSaveDto saveDto)
        {
            MiningConcession MiningConcession = _mapper.Map<MiningConcession>(saveDto);
            MiningConcession.RegistrationDate = DateTime.Now;
            MiningConcession.State = true;

            await _miningConcessionRepository.SaveAsync(MiningConcession);

            return _mapper.Map<MiningConcessionDto>(MiningConcession);
        }

        public async Task<MiningConcessionDto> DisabledAsync(int id)
        {
            MiningConcession? MiningConcession = await _miningConcessionRepository.FindByIdAsync(id);

            if (MiningConcession is null) throw MiningConcessionNotFound(id);

            MiningConcession.State = false;

            await _miningConcessionRepository.SaveAsync(MiningConcession);

            return _mapper.Map<MiningConcessionDto>(MiningConcession);
        }

        public async Task<MiningConcessionDto> EditAsync(int id, MiningConcessionSaveDto saveDto)
        {
            MiningConcession? MiningConcession = await _miningConcessionRepository.FindByIdAsync(id);

            if (MiningConcession is null) throw MiningConcessionNotFound(id);

            _mapper.Map<MiningConcessionSaveDto, MiningConcession>(saveDto, MiningConcession);

            await _miningConcessionRepository.SaveAsync(MiningConcession);

            return _mapper.Map<MiningConcessionDto>(MiningConcession);
        }

        public async Task<IReadOnlyList<MiningConcessionDto>> FindAllAsync()
        {
            IReadOnlyList<MiningConcession> MiningConcessions = await _miningConcessionRepository.FindAllAsync();

            return _mapper.Map<IReadOnlyList<MiningConcessionDto>>(MiningConcessions);
        }

        public async Task<MiningConcessionDto?> FindByIdAsync(int id)
        {
            MiningConcession? MiningConcession = await _miningConcessionRepository.FindByIdAsync(id);

            if (MiningConcession is null)
            {
                _logger.LogWarning("Mining Concession no encontrado para el id: {id}", id);
                throw MiningConcessionNotFound(id);
            }

            _logger.LogInformation("Mining Concession {name}", MiningConcession.Name);

            return _mapper.Map<MiningConcessionDto>(MiningConcession);
        }
        private NotFoundCoreException MiningConcessionNotFound(int id)
        {
            return new NotFoundCoreException(String.Format("Mining Concession no encontrado para el id: {id}", id));
        }
    }
}
