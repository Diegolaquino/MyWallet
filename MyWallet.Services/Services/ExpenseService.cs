using AutoMapper;
using Microsoft.Extensions.Logging;
using MyWallet.Domain.Models;
using MyWallet.Repositories.Base;
using MyWallet.Repositories.Contracts;
using MyWallet.Services.Contracts;
using MyWallet.Services.Responses;
using MyWallet.Shared.DTO;
using System.ComponentModel;
using System.Net;

namespace MyWallet.Services.Services
{
    public class ExpenseService : IExpenseService
    {
        private readonly IExpenseRepository _expenseRepository;
        private readonly IMapper _mapper;
        private readonly IUoW _unitOfWork;
        private readonly ILogger<ExpenseService> _logger;
        public ExpenseService(IExpenseRepository expenseRepository, IMapper mapper, IUoW unitOfWork, ILogger<ExpenseService> logger)
        {
            _expenseRepository = expenseRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _logger = logger;
        }
        public async Task<ResponseBase> GetAll(OwnerParametersDTO ownerParameters, CancellationToken cancellationToken)
        {
            try
            {
                var expenses = await _expenseRepository.GetAllAsync(ownerParameters, cancellationToken);

                var response = new SucessResponse<IEnumerable<ExpenseDTO>>((int)HttpStatusCode.OK, _mapper.Map<IEnumerable<Expense>, List<ExpenseDTO>>(expenses));

                return response;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return new FailureResponse((int)HttpStatusCode.InternalServerError, "InternalServerError", ex);
            }
        }

        public async Task<ResponseBase> SaveAsync(ExpenseEntryDTO expenseDTO, CancellationToken cancellationToken)
        {
            try
            {
                var objList = new List<Expense>();
                var installments = expenseDTO.InstallmentsQuantity ?? 1;

                for (int i = 0; i < installments; i++)
                {
                    var clonedExpense = expenseDTO.ShallowCopy();
                    clonedExpense.AddMonth(i);
                    clonedExpense.AddInstallment(i + 1);
                    objList.Add(await _expenseRepository.AddAsync(_mapper.Map<Expense>(clonedExpense), cancellationToken));
                }

                await _unitOfWork.CommitAsync();

                return new SucessResponse<IEnumerable<ExpenseDTO>>((int)HttpStatusCode.Created, Enumerable.Empty<ExpenseDTO>());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return new FailureResponse((int)HttpStatusCode.InternalServerError, "An error occurred in the expense registration flow", ex, ex.StackTrace ?? "");
            }
        }

        public async Task DeleteAsync(Guid id)
        {
            try
            {
                await _expenseRepository.DeleteAsync(id);
                await _unitOfWork.CommitAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw;
            }
        }

        public async Task UpdateAsync(ExpenseEntryDTO expense, CancellationToken cancellationToken)
        {
            try
            {
                await _expenseRepository.UpdateAsync(_mapper.Map<ExpenseEntryDTO, Expense>(expense), cancellationToken);

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
            var expense = await _expenseRepository.GetByIdAsync(id, cancellationToken);

            if (expense is null)
                return new FailureResponse((int)HttpStatusCode.NotFound, "");

            return new SucessResponse<ExpenseDTO>((int)HttpStatusCode.OK, _mapper.Map<ExpenseDTO>(expense));
        }

        public async Task<ResponseBase> GetExpensesByInterval(ExpenseIntervalDTO expenseInterval, CancellationToken cancellationToken)
        {
            var expenses = await _expenseRepository.GetByDateInterval(expenseInterval.Start, expenseInterval.End, cancellationToken);

            if (expenses is null)
                return new FailureResponse((int)HttpStatusCode.NoContent, "");

            return new SucessResponse<IEnumerable<ExpenseDTO>>((int)HttpStatusCode.OK, _mapper.Map<IEnumerable<ExpenseDTO>>(expenses));
        }
    }
}
