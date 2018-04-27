using System;

namespace GitSearch.Application.ViewModels
{
    public class UserViewModel
    {
        public string Login { get; set; }

        public string AvatarUrl { get; set; }

        public string Url { get; set; }

        public string ReposUrl { get; set; }

        public string Name { get; set; }

        public string Blog { get; set; }

        public string Bio { get; set; }

        public long PublicRepos { get; set; }

        public DateTimeOffset CreatedAt { get; set; }
    }
}
