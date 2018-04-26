using System.Collections.Generic;
using Newtonsoft.Json;

namespace GitSearch.Domain.Models
{
    public class SearchResult : EntityBase
    {
        [JsonProperty("total_count")]
        public long TotalCount { get; set; }

        [JsonProperty("incomplete_results")]
        public bool IncompleteResults { get; set; }
        
        [JsonProperty("items")]
        public List<User> Users { get; set; }
    }
}
