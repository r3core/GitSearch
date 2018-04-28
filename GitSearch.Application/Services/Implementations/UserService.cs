﻿using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using GitSearch.Application.Services.Interfaces;
using GitSearch.Application.ViewModels;
using GitSearch.Application.ViewModels.Collections;
using GitSearch.Repositories.Interfaces;

namespace GitSearch.Application.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<UserViewModel> GetByName(string name)
        {
            var user = await _userRepository.GetByName("users", name);
            return _mapper.Map<UserViewModel>(user);
        }

        public async Task<UserViewModelCollection> GetSearchResult(string searchQuery, int pageSize, int pageNumber)
        {
            var searchResult = await _userRepository.GetSearchResult(searchQuery, pageSize, pageNumber);
            return _mapper.Map<UserViewModelCollection>(searchResult);
        }
    }
}
