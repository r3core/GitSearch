using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web;
using GitSearch.Domain.Models;
using GitSearch.Repositories.Interfaces;
using Newtonsoft.Json;

namespace GitSearch.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public async Task<UserSearchResult> GetSearchResult(string searchString, int pageSize, int pageNumber)
        {
            var url = BuildUri($"search/users", new Dictionary<string, string>()
            {
                {"q", searchString },
                {"per_page", pageSize.ToString()},
                {"page", pageNumber.ToString()}
            });

            var jsonUser = await GetResponseString(url);
            return JsonConvert.DeserializeObject<UserSearchResult>(jsonUser);
        }
    }
}
