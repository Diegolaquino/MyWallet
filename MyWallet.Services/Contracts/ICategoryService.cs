﻿using MyWallet.Services.Responses;
using MyWallet.Shared.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWallet.Services.Contracts
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryDTO>> GetAll(OwnerParametersDTO ownerParameters);

        Task<ResponseBase> Save(CategoryEntryDTO categoryDTO);
    }
}
