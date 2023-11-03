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
    public class IncomeService : IIncomeService
    {
        private readonly IIncomeRepository _incomeRepository;
        private readonly IUoW _unitOfWork;
        private readonly ILogger<IncomeService> _logger;
        private readonly IMapper _mapper;

        public IncomeService(IIncomeRepository incomeRepository, IUoW unitOfWork, ILogger<IncomeService> logger, IMapper mapper)
        {
            _incomeRepository = incomeRepository;
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
        }
        public async Task DeleteAsync(Guid id)
        {
            try
            {
                await _incomeRepository.DeleteAsync(id);
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
                var incomes = await _incomeRepository.GetAllAsync(ownerParameters, cancellationToken);

                var response = new SucessResponse<IEnumerable<IncomeDTO>>((int)HttpStatusCode.OK, _mapper.Map<IEnumerable<Income>, List<IncomeDTO>>(incomes));

                return response;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return new FailureResponse((int)HttpStatusCode.InternalServerError, "InternalServerError", ex);
            }
        }

        public async Task<ResponseBase> GetEntity(Guid id, CancellationToken cancellationToken)
        {
            var income = await _incomeRepository.GetByIdAsync(id, cancellationToken);

            if (income is null)
                return new FailureResponse((int)HttpStatusCode.NotFound, "");

            return new SucessResponse<IncomeDTO>((int)HttpStatusCode.OK, _mapper.Map<IncomeDTO>(income));
        }

        public async Task<ResponseBase> Save(IncomeEntryDTO dto, CancellationToken cancellationToken)
        {
            try
            {
                var income = _mapper.Map<Income>(dto);

                var obj = await _incomeRepository.AddAsync(income, cancellationToken);
                await _unitOfWork.CommitAsync();

                return new SucessResponse<IncomeDTO>((int)HttpStatusCode.Created, _mapper.Map<IncomeDTO>(obj));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return new FailureResponse((int)HttpStatusCode.InternalServerError, $"An error occurred in the {nameof(Income)} registration flow", ex, ex.StackTrace ?? "");
            }
        }

        public async Task UpdateAsync(IncomeEntryDTO entity, CancellationToken cancellationToken)
        {
            try
            {
                await _incomeRepository.UpdateAsync(_mapper.Map<IncomeEntryDTO, Income>(entity), cancellationToken);

                await _unitOfWork.CommitAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw;
            }
        }

        public async Task<ResponseBase> GetIncomesByInterval(IncomeIntervalDTO incomeInterval, CancellationToken cancellationToken)
        {
            var incomes = await _incomeRepository.GetByDateInterval(incomeInterval.Start, incomeInterval.End, cancellationToken);

            if (incomes is null)
                return new FailureResponse((int)HttpStatusCode.NoContent, "");

            return new SucessResponse<IEnumerable<IncomeDTO>>((int)HttpStatusCode.OK, _mapper.Map<IEnumerable<IncomeDTO>>(incomes));
        }
    }
}
