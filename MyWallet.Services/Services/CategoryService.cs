using AutoMapper;
using Microsoft.Extensions.Logging;
using MyWallet.Domain.Models;
using MyWallet.Repositories.Base;
using MyWallet.Repositories.Contracts;
using MyWallet.Services.Contracts;
using MyWallet.Services.Responses;
using MyWallet.Shared.DTO;
using System.Net;

namespace MyWallet.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;
        private readonly IUoW _unitOfWork;
        private readonly ILogger<CategoryService> _logger;
        public CategoryService(ICategoryRepository categoryRepository, IMapper mapper, IUoW unitOfWork, ILogger<CategoryService> logger)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _logger = logger;
        }
        public async Task<ResponseBase> GetAll(OwnerParametersDTO ownerParameters, CancellationToken cancellationToken)
        {
            try
            {
                var categories = await _categoryRepository.GetAllAsync(ownerParameters, cancellationToken);

                var response = new SucessResponse<IEnumerable<CategoryDTO>>((int)HttpStatusCode.OK, _mapper.Map<IEnumerable<Category>, List<CategoryDTO>>(categories));

                return response;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return new FailureResponse((int)HttpStatusCode.InternalServerError, "InternalServerError", ex);
            }
        }

        public async Task<ResponseBase> SaveAsync(CategoryDTO categoryDTO, CancellationToken cancellationToken)
        {
            try
            {
                var category = _mapper.Map<Category>(categoryDTO);

                var obj = await _categoryRepository.AddAsync(category, cancellationToken);
                await _unitOfWork.CommitAsync();

                return new SucessResponse<CategoryDTO>((int)HttpStatusCode.Created, _mapper.Map<CategoryDTO>(obj));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return new FailureResponse((int)HttpStatusCode.InternalServerError, "An error occurred in the category registration flow", ex, ex.StackTrace ?? "");
            }
        }

        public async Task DeleteAsync(Guid id)
        {
            try
            {
                await _categoryRepository.DeleteAsync(id);
                await _unitOfWork.CommitAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw;
            }
        }

        public async Task UpdateAsync(CategoryDTO category, CancellationToken cancellationToken)
        {
            try
            {
                await _categoryRepository.UpdateAsync(_mapper.Map<CategoryDTO, Category>(category), cancellationToken);

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
            var categoy = await _categoryRepository.GetByIdAsync(id, cancellationToken);

            if (categoy is null)
                return new FailureResponse((int)HttpStatusCode.NotFound, "");

            return new SucessResponse<CategoryDTO>((int)HttpStatusCode.OK, _mapper.Map<CategoryDTO>(categoy));
        }
    }
}
