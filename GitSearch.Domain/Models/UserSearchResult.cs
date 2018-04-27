using System.Collections.Generic;
using Newtonsoft.Json;

namespace GitSearch.Domain.Models
{
    public class UserSearchResult : EntityBase
    {
        [JsonProperty("total_count")]
        public int TotalCount { get; set; }

        [JsonProperty("incomplete_results")]
        public bool IncompleteResults { get; set; }
        
        [JsonProperty("items")]
        public List<User> Users { get; set; }
    }
}
