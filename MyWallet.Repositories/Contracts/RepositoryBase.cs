using MyWallet.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWallet.Repositories.Contracts
{
    public interface IRepositoryBase<T> where T : class
    {
        Task<T> GetById(Guid id);
        void Update(T entity);
        Task Delete(Guid id);
        Task<IEnumerable<T>> GetAll();
        Task<T> Save(T entity);
    }
}
