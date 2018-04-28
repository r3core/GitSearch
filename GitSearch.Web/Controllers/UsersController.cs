using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using GitSearch.Application.Services.Interfaces;
using GitSearch.Application.ViewModels;
using Microsoft.AspNetCore.Mvc;
using GitSearch.Web.Models;
using GitSearch.Application.ViewModels.Collections;
using Microsoft.Extensions.Configuration;

namespace GitSearch.Web.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUserService _userService;
        private readonly IConfiguration _configuration;
        private const int DefaultPageSize = 10;

        public UsersController(IUserService userService, IConfiguration configuration)
        {
            _userService = userService;
            _configuration = configuration;
        }

        public async Task<IActionResult> Index(string searchString, int pageNumber = 1)
        {
            if (!string.IsNullOrWhiteSpace(searchString))
            {
                ViewData["searchString"] = searchString;
                var pageSize = int.TryParse(_configuration["Pagination:PageSize"], out var size)
                    ? size
                    : DefaultPageSize;
                return View(await _userService.GetSearchResult(searchString, pageSize, pageNumber));
            }
            return View(new UserViewModelCollection()
            {
                Users = new List<UserViewModel>()
            });
        }

        public async Task<IActionResult> Details(string name)
        {
            //var user = await _userService.GetByName("r3core");

            var users = await _userService.GetSearchResult("Ravindu", 5, 1);
            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
