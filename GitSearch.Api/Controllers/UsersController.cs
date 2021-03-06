﻿using System.Linq;
using System.Threading.Tasks;
using GitSearch.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace GitSearch.Api.Controllers
{
    /// <summary>
    /// Class defining the <see cref="UsersController"/>.
    /// </summary>
    [Route("api/[controller]")]
    public class UsersController : Controller
    {
        private readonly IUserService _userService;
        private readonly IConfiguration _configuration;
        private const int DefaultResultCount = 5;

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

        // GET api/users/search?name=foo
        [HttpGet("Search")]
        public async Task<IActionResult> Get(string name)
        {
            var resultCount = int.TryParse(_configuration["Results:Count"], out var resultCountSize) && resultCountSize > 0
                ? resultCountSize
                : DefaultResultCount;

            var users = await _userService.GetSearchResult(name, resultCount, 1);
            if (!users.Users.Any())
            {
                return NotFound(name);
            }

            return Ok(users.Users.Select(user => user.Login));
        }
    }
}
