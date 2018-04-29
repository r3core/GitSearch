using AutoMapper;
using GitSearch.Application.ViewModels;
using GitSearch.Application.ViewModels.Collections;
using GitSearch.Domain.Models;

namespace GitSearch.Application.AutoMapper
{
    /// <summary>
    /// Class defining the Automapper configurations.
    /// </summary>
    public class MappingProfile : Profile
    {
        /// <summary>
        /// Instantiates a <see cref="MappingProfile"/>.
        /// Proceeds to generated the user-defined mappings.
        /// </summary>
        public MappingProfile()
        {
            CreateMap<UserViewModel, User>(MemberList.Source);
            CreateMap<UserViewModelCollection, UserSearchResult>(MemberList.Source);
        }
    }
}
