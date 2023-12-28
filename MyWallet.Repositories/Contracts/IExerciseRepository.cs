using MyWallet.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWallet.Repositories.Contracts
{
    public interface IExerciseRepository : IRepositoryBase<Exercise>
    {
        Task<IEnumerable<Exercise>> GetByDateInterval(DateTime start, DateTime end, CancellationToken cancellationToken);
    }
}
