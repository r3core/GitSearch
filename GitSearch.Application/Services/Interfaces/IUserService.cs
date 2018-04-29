using System.Threading.Tasks;
using GitSearch.Application.ViewModels;
using GitSearch.Application.ViewModels.Collections;

namespace GitSearch.Application.Services.Interfaces
{
    /// <summary>
    /// Interface for <see cref="IUserService"/> extenders.
    /// </summary>
    public interface IUserService
    {
        Task<UserViewModel> GetByName(string name);
        Task<UserViewModelCollection> GetSearchResult(string searchQuery, int pageSize, int pageNumber);
    }
}
