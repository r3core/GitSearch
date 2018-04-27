using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using GitSearch.Application.ViewModels;
using GitSearch.Application.ViewModels.Collections;

namespace GitSearch.Application.Services.Interfaces
{
    public interface IUserService
    {
        Task<UserViewModel> GetByName(string name);
        Task<UserViewModelCollection> GetSearchResult(string searchQuery, int pageSize, int pageNumber);
    }
}
