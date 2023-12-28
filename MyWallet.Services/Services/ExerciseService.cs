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
    public class ExerciseService : IExerciseService
    {
        private readonly IExerciseRepository _exerciseRepository;
        private readonly IMapper _mapper;
        private readonly IUoW _unitOfWork;
        private readonly ILogger<ExerciseService> _logger;

        public ExerciseService(IExerciseRepository exerciseRepository, IMapper mapper, IUoW unitOfWork, ILogger<ExerciseService> logger)
        {
            _exerciseRepository = exerciseRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public async Task DeleteAsync(Guid id)
        {
            try
            {
                await _exerciseRepository.DeleteAsync(id);
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
                var exerciseSet = await _exerciseRepository.GetAllAsync(ownerParameters, cancellationToken);

                var response = new SucessResponse<IEnumerable<ExerciseDTO>>((int)HttpStatusCode.OK, _mapper.Map<IEnumerable<Exercise>, List<ExerciseDTO>>(exerciseSet));

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
            var exercise = await _exerciseRepository.GetByIdAsync(id, cancellationToken);

            if (exercise is null)
                return new FailureResponse((int)HttpStatusCode.NotFound, "");

            return new SucessResponse<ExerciseDTO>((int)HttpStatusCode.OK, _mapper.Map<ExerciseDTO>(exercise));
        }

        public async Task<ResponseBase> GetExerciseByIntervalAsync(IntervalDTO intervalDTO, CancellationToken cancellationToken)
        {
            try
            {
                var exercises = await _exerciseRepository.GetByDateInterval(intervalDTO.Start, intervalDTO.End, cancellationToken);

                if (exercises is null || !exercises.Any())
                    return new FailureResponse((int)HttpStatusCode.NoContent, "");

                return new SucessResponse<IEnumerable<ExerciseDTO>>((int)HttpStatusCode.OK, _mapper.Map<IEnumerable<ExerciseDTO>>(exercises));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return new FailureResponse((int)HttpStatusCode.InternalServerError, "InternalServerError", ex);
            }
        }

        public async Task<ResponseBase> SaveAsync(ExerciseDTO dto, CancellationToken cancellationToken)
        {
            try
            {
                var exercise = _mapper.Map<Exercise>(dto);

                var savedExercise = await _exerciseRepository.AddAsync(exercise, cancellationToken);
                await _unitOfWork.CommitAsync();

                return new SucessResponse<ExerciseDTO>((int)HttpStatusCode.Created, _mapper.Map<ExerciseDTO>(savedExercise));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return new FailureResponse((int)HttpStatusCode.InternalServerError, "An error occurred in the ExerciseDTO registration flow", ex, ex.StackTrace ?? "");
            }
        }


        public async Task UpdateAsync(ExerciseDTO dto, CancellationToken cancellationToken)
        {
            try
            {
                var exercise = _mapper.Map<ExerciseDTO, Exercise>(dto);

                await _exerciseRepository.UpdateAsync(exercise, cancellationToken);
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
