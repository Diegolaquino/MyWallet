using AutoMapper;
using Microsoft.Extensions.Logging;
using MyWallet.Domain.Models;
using MyWallet.Repositories.Base;
using MyWallet.Repositories.Contracts;
using MyWallet.Services.Contracts;
using MyWallet.Services.Responses;
using MyWallet.Shared.DTO;
using System.Net;
namespace MyWallet.Services.Services
{
    public class GoalService : IGoalService
    {
        private readonly IGoalRepository _goalRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<GoalService> _logger;
        private readonly IUoW _unitOfWork;

        public GoalService(IGoalRepository goalRepository, IMapper mapper, ILogger<GoalService> logger, IUoW uoW)
        {
            _goalRepository = goalRepository;
            _mapper = mapper;
            _logger = logger;
            _unitOfWork = uoW;
        }

        public async Task DeleteAsync(Guid id)
        {
            try
            {
                await _goalRepository.DeleteAsync(id);
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
                var goals = await _goalRepository.GetAllAsync(ownerParameters, cancellationToken);

                var response = new SucessResponse<IEnumerable<GoalDTO>>((int)HttpStatusCode.OK, _mapper.Map<IEnumerable<Goal>, List<GoalDTO>>(goals));

                return response;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return new FailureResponse((int)HttpStatusCode.InternalServerError, $"InternalServerError getAll {nameof(GoalService)}", ex);
            }
        }

        public async Task<ResponseBase> GetEntityAsync(Guid id, CancellationToken cancellationToken)
        {
            try
            {
                var goal = await _goalRepository.GetByIdAsync(id, cancellationToken);

                if (goal == null)
                {
                    return new FailureResponse((int)HttpStatusCode.NotFound, $"Goal with ID {id} not found.");
                }

                var goalDto = _mapper.Map<GoalDTO>(goal);

                return new SucessResponse<GoalDTO>((int)HttpStatusCode.OK, goalDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return new FailureResponse((int)HttpStatusCode.InternalServerError, "InternalServerError", ex);
            }
        }

        public async Task<ResponseBase> SaveAsync(GoalDTO dto, CancellationToken cancellationToken)
        {
            try
            {
                var goal = _mapper.Map<Goal>(dto);

                await _goalRepository.AddAsync(goal, cancellationToken);
                await _unitOfWork.CommitAsync(cancellationToken);

                return new SucessResponse<GoalDTO>((int)HttpStatusCode.Created, _mapper.Map<GoalDTO>(goal));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return new FailureResponse((int)HttpStatusCode.InternalServerError, "InternalServerError", ex);
            }
        }

        public async Task UpdateAsync(GoalDTO entity, CancellationToken cancellationToken)
        {
            try
            {
                await _goalRepository.UpdateAsync(_mapper.Map<GoalDTO, Goal>(entity), cancellationToken);

                await _unitOfWork.CommitAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw;
            }
        }

    }
}
