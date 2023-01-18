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
        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public Task<IEnumerable<CategoryDTO>> GetAll(OwnerParametersDTO ownerParameters)
        {
            return _categoryRepository.GetAll(ownerParameters);
        }
    }
}
