using System.Threading.Tasks;
using GitSearch.Domain.Models;

namespace GitSearch.Repositories.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        Task<UserSearchResult> GetSearchResult(string searchString, int pageSize, int pageNumber);
    }
}
