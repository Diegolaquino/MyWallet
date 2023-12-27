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
    public class ReminderService : IReminderService
    {
        private readonly IReminderRepository _reminderRepository;
        private readonly IMapper _mapper;
        private readonly IUoW _unitOfWork;
        private readonly ILogger<ReminderService> _logger;
        public ReminderService(IReminderRepository reminderRepository, IMapper mapper, IUoW unitOfWork, ILogger<ReminderService> logger)
        {
            _reminderRepository = reminderRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _logger = logger;
        }
        public async Task<ResponseBase> GetAll(OwnerParametersDTO ownerParameters, CancellationToken cancellationToken)
        {
            try
            {
                var reminders = await _reminderRepository.GetAllAsync(ownerParameters, cancellationToken);

                var response = new SucessResponse<IEnumerable<ReminderDTO>>((int)HttpStatusCode.OK, _mapper.Map<IEnumerable<Reminder>, List<ReminderDTO>>(reminders));

                return response;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return new FailureResponse((int)HttpStatusCode.InternalServerError, "InternalServerError", ex);
            }
        }

        public async Task<ResponseBase> SaveAsync(ReminderDTO reminderDTO, CancellationToken cancellationToken)
        {
            try
            {
                var reminder = _mapper.Map<Reminder>(reminderDTO);

                var obj = await _reminderRepository.AddAsync(reminder, cancellationToken);
                await _unitOfWork.CommitAsync();

                return new SucessResponse<ReminderDTO>((int)HttpStatusCode.Created, _mapper.Map<ReminderDTO>(obj));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return new FailureResponse((int)HttpStatusCode.InternalServerError, "An error occurred in the reminder registration flow", ex, ex.StackTrace ?? "");
            }
        }

        public async Task DeleteAsync(Guid id)
        {
            try
            {
                await _reminderRepository.DeleteAsync(id);
                await _unitOfWork.CommitAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw;
            }
        }

        public async Task UpdateAsync(ReminderDTO reminder, CancellationToken cancellationToken)
        {
            try
            {
                await _reminderRepository.UpdateAsync(_mapper.Map<ReminderDTO, Reminder>(reminder), cancellationToken);

                await _unitOfWork.CommitAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw;
            }
        }

        public async Task<ResponseBase> GetEntityAsync(Guid id, CancellationToken cancellationToken)
        {
            var categoy = await _reminderRepository.GetByIdAsync(id, cancellationToken);

            if (categoy is null)
                return new FailureResponse((int)HttpStatusCode.NotFound, "");

            return new SucessResponse<ReminderDTO>((int)HttpStatusCode.OK, _mapper.Map<ReminderDTO>(categoy));
        }

        public async Task<ResponseBase> GetRemindersNoResolvedAsync(CancellationToken cancellationToken)
        {
            try
            {
                var reminders = await _reminderRepository.GetRemindersNoResolvedAsync(cancellationToken);

                var response = new SucessResponse<IEnumerable<ReminderDTO>>((int)HttpStatusCode.OK, _mapper.Map<IEnumerable<Reminder>, List<ReminderDTO>>(reminders));

                return response;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return new FailureResponse((int)HttpStatusCode.InternalServerError, "InternalServerError", ex);
            }
        }
    }
}
