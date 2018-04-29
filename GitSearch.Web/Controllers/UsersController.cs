using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using GitSearch.Application.Services.Interfaces;
using GitSearch.Application.ViewModels;
using Microsoft.AspNetCore.Mvc;
using GitSearch.Web.Models;
using GitSearch.Application.ViewModels.Collections;
using Microsoft.Extensions.Configuration;

namespace GitSearch.Web.Controllers
{
    /// <summary>
    /// Class defining the <see cref="UsersController"/>.
    /// </summary>
    public class UsersController : Controller
    {
        private readonly IUserService _userService;
        private readonly IConfiguration _configuration;
        private const int DefaultPageSize = 10;

        /// <summary>
        /// Instantiates the <see cref="UsersController"/>.
        /// </summary>
        /// <param name="userService">The injected <see cref="IUserService"/> implementation.</param>
        /// <param name="configuration">The injected <see cref="IConfiguration"/> implementation.</param>
        public UsersController(IUserService userService, IConfiguration configuration)
        {
            _userService = userService;
            _configuration = configuration;
        }

        public async Task<IActionResult> Index(string searchString, int pageNumber = 1)
        {
            var pageSize = int.TryParse(_configuration["Pagination:PageSize"], out var size) && size > 0
                ? size
                : DefaultPageSize;

            pageNumber = pageNumber > 0 ? pageNumber : 1;

            if (!string.IsNullOrWhiteSpace(searchString))
            {
                var users = await _userService.GetSearchResult(searchString, pageSize, pageNumber);
                var maxPageCount = MaxPageCount(users.TotalCount);
                if (pageNumber > maxPageCount)
                {
                    pageNumber = maxPageCount;
                    users = await _userService.GetSearchResult(searchString, pageSize, pageNumber);
                }

                ViewData["searchString"] = searchString;
                ViewData["pageNumber"] = pageNumber;
                ViewData["hasPrevious"] = HasPrevious();
                ViewData["hasNext"] = HasNext(users.TotalCount);

                return View(users);
            }
            return View(new UserViewModelCollection()
            {
                Users = new List<UserViewModel>()
            });

            bool HasPrevious() => pageNumber > 1;
            bool HasNext(int total) => (pageNumber * pageSize) < total;
            int MaxPageCount(int total) => total % pageSize != 0
                ? total / pageSize + 1
                : total / pageSize;
        }

        public async Task<IActionResult> Details(string username)
        {
            var user = await _userService.GetByName(username);
            return View(user);
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
