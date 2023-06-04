using AutoMapper;
using Microsoft.Extensions.Logging;
using MyWallet.Domain.Models;
using MyWallet.Repositories.Base;
using MyWallet.Repositories.Contracts;
using MyWallet.Services.Contracts;
using MyWallet.Services.Responses;
using MyWallet.Shared.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

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
        public async Task<IEnumerable<CategoryDTO>> GetAll(OwnerParametersDTO ownerParameters)
        {
            var categories = await _categoryRepository.GetAllAsync(ownerParameters);
            return _mapper.Map<IEnumerable<CategoryDTO>>(categories);
        }

        public async Task<ResponseBase> Save(CategoryEntryDTO categoryDTO)
        {
            try
            {
                var category = _mapper.Map<Category>(categoryDTO);

                var obj = await _categoryRepository.AddAsync(category);
                await _unitOfWork.CommitAsync();

                return new SucessResponse<CategoryDTO>((int)HttpStatusCode.Created, _mapper.Map<CategoryDTO>(obj));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return new FailureResponse((int)HttpStatusCode.InternalServerError, "An error occurred in the category registration flow", ex.Message, ex.StackTrace);
            }
        }
    }
}
