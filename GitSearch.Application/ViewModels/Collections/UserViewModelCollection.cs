using System;
using System.Collections.Generic;
using System.Text;

namespace GitSearch.Application.ViewModels.Collections
{
    public class UserViewModelCollection
    {
        public List<UserViewModel> Users { get; set; }

        public int TotalCount { get; set; }
    }
}
