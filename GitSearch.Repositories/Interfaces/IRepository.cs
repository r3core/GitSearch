using System.Threading.Tasks;

namespace GitSearch.Repositories.Interfaces
{
    /// <summary>
    /// Generic Interface for All Repositories.
    /// </summary>
    /// <typeparam name="TEntity">An Entity Type</typeparam>
    public interface IRepository<TEntity>
    {
        Task<TEntity> GetByName(string action, string name);
    }
}
