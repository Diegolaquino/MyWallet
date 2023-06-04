using MyWallet.Services.Responses;
using MyWallet.Shared.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWallet.Services.Contracts
{
    public interface IUserService
    {
        Task<ResponseBase> CreateUser(CreateUserDTO userDTO);
    }
}
