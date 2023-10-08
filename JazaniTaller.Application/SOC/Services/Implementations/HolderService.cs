using AutoMapper;
using JazaniTaller.Application.Cores.Exceptions;
using JazaniTaller.Application.SOC.Dtos.Holders;
using JazaniTaller.Domain.SOC.Models;
using JazaniTaller.Domain.SOC.Repositories;
using Microsoft.Extensions.Logging;

namespace JazaniTaller.Application.SOC.Services.Implementations
{
    public class HolderService: IHolderService
    {
        private readonly IHolderRepository _holderRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<HolderService> _logger;
        public HolderService(IHolderRepository holderRepository, IMapper mapper, ILogger<HolderService> logger)
        {
            _holderRepository = holderRepository;
            _mapper = mapper;
            _logger = logger;
        }
        public async Task<IReadOnlyList<HolderDto>> FindAllAsync()
        {
            IReadOnlyList<Holder> holders = await _holderRepository.FindAllAsync();
            return _mapper.Map<IReadOnlyList<HolderDto>>(holders);

        }
        public async Task<HolderDto?> FindByIdAsync(int id)
        {
            Holder? holder = await _holderRepository.FindByIdAsync(id);
            if (holder is null)
            {
                _logger.LogWarning("Holder no encontrado para el id: {id}", id);
                throw HolderNotFound(id);
            }
            return _mapper.Map<HolderDto>(holder);
        }

        public async Task<HolderDto> CreateAsync(HolderSaveDto saveDto)
        {
            Holder holder = _mapper.Map<Holder>(saveDto);
            holder.RegistrationDate = DateTime.Now;
            holder.State = true;
            Holder holderSaved = await _holderRepository.SaveAsync(holder);
            return _mapper.Map<HolderDto>(holderSaved);
        }

        public async Task<HolderDto> EditAsync(int id, HolderSaveDto holdersaveDto)
        {
            Holder holder = await _holderRepository.FindByIdAsync(id);

            if (holder is null) throw HolderNotFound(id);

            _mapper.Map<HolderSaveDto, Holder>(holdersaveDto, holder);
            Holder holderSaved = await _holderRepository.SaveAsync(holder);
            return _mapper.Map<HolderDto>(holderSaved);
        }

        private NotFoundCoreException HolderNotFound(int id)
        {
            return new NotFoundCoreException("Holder no encontrado para el id: " + id);
        }

        public async Task<HolderDto> DisabledAsync(int id)
        {
            Holder holder = await _holderRepository.FindByIdAsync(id);

            if (holder is null) throw HolderNotFound(id);

            holder.State = false;
            Holder holderSaved = await _holderRepository.SaveAsync(holder);
            return _mapper.Map<HolderDto>(holderSaved);
        }
    }
}
