using MyWallet.Domain.Models;
using MyWallet.Services.Responses;
using MyWallet.Shared.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWallet.Services.Contracts
{
    public interface IExerciseService : IBaseService<ExerciseDTO>
    {
        Task<ResponseBase> GetExerciseByIntervalAsync(IntervalDTO intervalDTO, CancellationToken cancellationToken);
    }
}
