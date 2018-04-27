using AutoMapper;
using GitSearch.Application.ViewModels;
using GitSearch.Application.ViewModels.Collections;
using GitSearch.Domain.Models;

namespace GitSearch.Application.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UserViewModel, User>(MemberList.Source);
            CreateMap<UserViewModelCollection, UserSearchResult>(MemberList.Source);
        }
    }
}
