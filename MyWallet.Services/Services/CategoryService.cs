using AutoMapper;
using MyWallet.Domain.Models;
using MyWallet.Repositories.Base;
using MyWallet.Repositories.Contracts;
using MyWallet.Services.Contracts;
using MyWallet.Shared.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWallet.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;
        private readonly IUoW _unitOfWork;
        public CategoryService(ICategoryRepository categoryRepository, IMapper mapper, IUoW unitOfWork)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public async Task<IEnumerable<CategoryDTO>> GetAll(OwnerParametersDTO ownerParameters)
        {
            var categories = await _categoryRepository.GetAllAsync(ownerParameters);
            return _mapper.Map<IEnumerable<CategoryDTO>>(categories);
        }

        public async Task<CategoryDTO> Save(CategoryDTO categoryDTO)
        {
            var category = _mapper.Map<Category>(categoryDTO);

            var obj = await _categoryRepository.AddAsync(category);
            await _unitOfWork.CommitAsync();

            return _mapper.Map<CategoryDTO>(obj);
        }
    }
}
