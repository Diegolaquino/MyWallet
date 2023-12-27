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
    public class WalletService : IWalletService
    {
        private readonly IWalletRepository _walletRepository;
        private readonly IUoW _unitOfWork;
        private readonly ILogger<WalletService> _logger;
        private readonly IMapper _mapper;

        public WalletService(IWalletRepository walletRepository, IUoW unitOfWork, ILogger<WalletService> logger, IMapper mapper)
        {
            _walletRepository = walletRepository;
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task DeleteAsync(Guid id)
        {
            try
            {
                await _walletRepository.DeleteAsync(id);
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
                var wallets = await _walletRepository.GetAllAsync(ownerParameters, cancellationToken);

                var response = new SucessResponse<IEnumerable<WalletDTO>>((int)HttpStatusCode.OK, _mapper.Map<IEnumerable<Wallet>, List<WalletDTO>>(wallets));

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
            var wallet = await _walletRepository.GetByIdAsync(id, cancellationToken);

            if (wallet is null)
                return new FailureResponse((int)HttpStatusCode.NotFound, "");

            return new SucessResponse<WalletDTO>((int)HttpStatusCode.OK, _mapper.Map<WalletDTO>(wallet));
        }

        public async Task<ResponseBase> SaveAsync(WalletDTO dto, CancellationToken cancellationToken)
        {
            try
            {
                var wallet = _mapper.Map<Wallet>(dto);

                var obj = await _walletRepository.AddAsync(wallet, cancellationToken);
                await _unitOfWork.CommitAsync();

                return new SucessResponse<WalletDTO>((int)HttpStatusCode.Created, _mapper.Map<WalletDTO>(obj));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return new FailureResponse((int)HttpStatusCode.InternalServerError, $"An error occurred in the {nameof(Wallet)} registration flow", ex, ex.StackTrace ?? "");
            }
        }

        public async Task UpdateAsync(WalletDTO entity, CancellationToken cancellationToken)
        {
            try
            {
                await _walletRepository.UpdateAsync(_mapper.Map<WalletDTO, Wallet>(entity), cancellationToken);

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
