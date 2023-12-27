using AutoMapper;
using Microsoft.Extensions.Logging;
using MyWallet.Domain.Models;
using MyWallet.Repositories.Base;
using MyWallet.Repositories.Contracts;
using MyWallet.Repositories.Repositories;
using MyWallet.Services.Contracts;
using MyWallet.Services.Responses;
using MyWallet.Shared.DTO;
using System.Net;

namespace MyWallet.Services.Services
{
    public class HealthService : IHealthService
    {
        private readonly IHealthRepository _healthRepository;
        private readonly IMapper _mapper;
        private readonly IUoW _unitOfWork;
        private readonly ILogger<HealthService> _logger;

        public HealthService(IHealthRepository healthRepository, IMapper mapper, IUoW unitOfWork, ILogger<HealthService> logger)
        {
            _healthRepository = healthRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public async Task DeleteAsync(Guid id)
        {
            try
            {
                await _healthRepository.DeleteAsync(id);
                await _unitOfWork.CommitAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw;
            }
        }

        public async Task<ResponseBase> GetAll(OwnerParametersDTO ownerParameters, CancellationToken cancellationToken)
        {
            try
            {
                var healthSet = await _healthRepository.GetAllAsync(ownerParameters, cancellationToken);

                var response = new SucessResponse<IEnumerable<HealthDTO>>((int)HttpStatusCode.OK, _mapper.Map<IEnumerable<Health>, List<HealthDTO>>(healthSet));

                return response;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return new FailureResponse((int)HttpStatusCode.InternalServerError, "InternalServerError", ex);
            }
        }

        public async Task<ResponseBase> GetEntityAsync(Guid id, CancellationToken cancellationToken)
        {
            var health = await _healthRepository.GetByIdAsync(id, cancellationToken);

            if (health is null)
                return new FailureResponse((int)HttpStatusCode.NotFound, "");

            return new SucessResponse<HealthDTO>((int)HttpStatusCode.OK, _mapper.Map<HealthDTO>(health));
        }

        public async Task<ResponseBase> GetHealthByIntervalAsync(IntervalDTO intervalDTO, CancellationToken cancellationToken)
        {
            var healthSet = await _healthRepository.GetByDateInterval(intervalDTO.Start, intervalDTO.End, cancellationToken);

            if (healthSet is null)
                return new FailureResponse((int)HttpStatusCode.NoContent, "");

            return new SucessResponse<IEnumerable<HealthDTO>>((int)HttpStatusCode.OK, _mapper.Map<IEnumerable<HealthDTO>>(healthSet));
        }

        public async Task<ResponseBase> SaveAsync(HealthDTO dto, CancellationToken cancellationToken)
        {
            try
            {
                var health = _mapper.Map<Health>(dto);

                var obj = await _healthRepository.AddAsync(health, cancellationToken);
                await _unitOfWork.CommitAsync();

                return new SucessResponse<HealthDTO>((int)HttpStatusCode.Created, _mapper.Map<HealthDTO>(obj));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return new FailureResponse((int)HttpStatusCode.InternalServerError, "An error occurred in the HealthDTO registration flow", ex, ex.StackTrace ?? "");
            }
        }

        public async Task UpdateAsync(HealthDTO entity, CancellationToken cancellationToken)
        {
            try
            {
                await _healthRepository.UpdateAsync(_mapper.Map<HealthDTO, Health>(entity), cancellationToken);

                await _unitOfWork.CommitAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw;
            }
        }
    }
}
