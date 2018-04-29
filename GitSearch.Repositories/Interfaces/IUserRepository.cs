using System.Threading.Tasks;
using GitSearch.Domain.Models;

namespace GitSearch.Repositories.Interfaces
{
    /// <summary>
    /// Interface for <see cref="User"/> entities extending the <see cref="IRepository{TEntity}"/>
    /// </summary>
    public interface IUserRepository : IRepository<User>
    {
        Task<UserSearchResult> GetSearchResult(string searchString, int pageSize, int pageNumber);
    }
}
