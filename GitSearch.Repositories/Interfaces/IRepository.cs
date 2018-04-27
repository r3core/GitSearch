using System.Collections.Generic;
using System.Threading.Tasks;

namespace GitSearch.Repositories.Interfaces
{
    public interface IRepository<TEntity>
    {
        Task<TEntity> GetByName(string action, string name);
    }
}
